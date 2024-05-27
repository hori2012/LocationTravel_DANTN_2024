using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace LocationTravel
{
    internal class AntAlgorithm
    {
        private static double[,] matrix; //matrix distance
        private static int N; // pass through N locations
        private static int M = 9999999; //infinity number
        private static double[,] T; // store the pheromone
        private static double[,] Delta;// save the update of pheromone

        private static int[] w; //save the ant's trip 
        private static int[] ht;

        private static int[] Mark; // if( M[i]==1) -> location i has been visited, else -> not yet visited
        private static int[] UV; // locations the ant has not yet visited

        private static int N_loop = 200; // number of times for the ant colony to run, each run has AntNumb ants - release one by one
        private static int AntNumb = 25; //number of ants running
        private static double N_best; // save the shortest distance run by the ant

        private static double sum = 0; // total probability
        private static double L = 0; // distance run by the ant

        private static double alpha = 0.2; // factor affecting the pheromone
        private static double beta = 0.3;  // factor affecting the path alpha < beta : ant prioritizes the shortest path
        private static int Q = 500; // constant Q

        /// <summary>
        /// Initialize the initial values
        /// </summary>
        public static void Init()
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    T[i, j] = 0.5;
                    Delta[i, j] = 0;
                }
            }
            for (int i = 0; i < N; i++)
            {
                Mark[i] = 0;
            }
            N_best = M;
        }
        /// <summary>
        /// Probability of going from location u to location v (not yet visited)
        /// </summary>
        /// <returns></returns>
        public static double p(int u, int v)
        {
            double a = Math.Pow(T[u, v], alpha) * Math.Pow(1 / matrix[u, v], beta);
            double b = 0;
            for (int w = 0; w < N; w++)
            {
                if (w != u)
                {
                    if (Mark[w] == 0)
                    {
                        b += Math.Pow(T[u, w], alpha) * Math.Pow(1 / matrix[u, w], beta);
                    }
                }
            }
            return a / b;
        }
        /// <summary>
        /// Determine the next location to go after arriving at location u - Lottery Wheel
        /// </summary>
        /// <returns></returns>
        public static int PointNext(int u)
        {
            sum = 0;
            int dem = 0;
            for (int i = 0; i < N; i++)
            {
                if (Mark[i] == 0)
                {
                    sum += p(w[u], i);
                    UV[dem] = i; // cac dia diem co the den
                    dem++;
                }
            }
            double k = 0;
            Random random = new Random();
            do
            {
                k = (random.NextDouble() * sum);
            } while (k == 0);
            int j = 0;
            double t = p(w[u], UV[j]);
            while (t < k)
            {
                j++;
                t += p(w[u], UV[j]);
            }
            return UV[j];
        }
        /// <summary>
        /// Update the pheromone
        /// </summary>
        public static void Update()
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = i + 1; j < N; j++)
                {
                    T[i, j] = 0.8 * T[i, j] + Delta[i, j];
                }
            }
        }
        /// <summary>
        /// Algorithm ACO - Ant Colony Optimization
        /// </summary>
        public static int[] Ant_ACO(double[,] matrixs)
        {
            matrix = matrixs;
            N = matrix.GetLength(0);
            T = new double[N, N];
            Delta = new double[N, N];
            w = new int[N];
            ht = new int[N];
            Mark = new int[N];
            UV = new int[N];
            int i = 0, j = 0;
            Init();
            do
            {
                N_loop--;
                for (i = 0; i < AntNumb; i++)
                {
                    for (j = 0; j < N; j++)
                    {
                        Mark[j] = 0;
                    }
                    Mark[0] = 1;
                    w[0] = 0;
                    L = 0;
                    for (j = 1; j < N; j++)
                    {
                        w[j] = PointNext(j - 1);
                        L += matrix[w[j - 1], w[j]];
                        Mark[w[j]] = 1;
                    }
                    L += matrix[N - 1, w[0]];
                    if (L < N_best)
                    {
                        N_best = L;
                        for (i = 0; i < N; i++)
                        {
                            ht[i] = w[i];
                        }
                    }
                    for (int k = 0; k < N; k++)
                    {
                        for (j = i + 1; j < N; j++)
                        {
                            Delta[k, j] = Delta[k, j] + (Q / L);
                        }
                    }
                    Update();
                }
            } while (N_loop > 0);
            //for (int k = 0; k < N; k++)
            //{
            //    Debug.Write(ht[k] + " -> ");
            //}
            //Debug.Write(ht[0]);
            return ht;
        }
    }
}
