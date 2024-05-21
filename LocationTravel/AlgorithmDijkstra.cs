using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocationTravel
{
    internal class AlgorithmDijkstra
    {
        private static List<Point> Open = new List<Point>();
        private static List<Point> Close = new List<Point>();
        public static int IndexMinValueOfList(List<Point> Open)
        {
            double min = Open[0].g;
            int indexMin = 0;
            for (int i = 1; i < Open.Count; i++)
            {
                if (Open[i].g < min)
                {
                    min = Open[i].g;
                    indexMin = i;
                }
            }
            return indexMin;
        }
        public static int Member(int node, List<Point> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (node == list[i].name)
                {
                    return i;
                }
            }
            return -1;
        }
        public static List<int> Dijkstra(int S, int G, double[,] matrix)
        {
            Point N = new Point(); ;
            N.name = S;
            N.g = 0;
            N.prev = 0;
            Open.Add(N);
            while (Open.Count != 0)
            {
                int indexMin = IndexMinValueOfList(Open);
                N = Open[indexMin];
                if (N.name == G)
                {
                    Close.Add(N);
                    break;
                }
                else
                {
                    Close.Add(N);
                    for (int node = 0; node < matrix.GetLength(0); node++)
                    {
                        int belong = Member(node, Close);
                        if (belong == -1 && matrix[N.name, node] > 0)
                        {
                            int k = Member(node, Open);
                            if (k >= 0)
                            {
                                Point Q = Open[k];
                                if (N.g + matrix[N.name, Q.name] < Q.g)
                                {
                                    Q.g = N.g + matrix[N.name, Q.name];
                                    Q.prev = N.name;
                                    Open[k] = Q;
                                }
                            }
                            else
                            {
                                Point Q = new Point();
                                Q.name = node;
                                Q.g = N.g + matrix[N.name, Q.name];
                                Q.prev = N.name;
                                Open.Add(Q);
                            }
                        }
                    }
                    Open.RemoveAt(indexMin);
                }
            }
            int indexG = Member(G, Close);
            List<int> list = new List<int>() { G };
            if (indexG >= 0)
            {
                int k = indexG;
                while (Close[k].prev != S)
                {
                    list.Add(Close[k].prev);
                    k = Member(Close[k].prev, Close);
                }
                list.Add(S);
            }
            Console.WriteLine();
            list.Reverse();
            return list;
        }
    }
    struct Point
    {
        public int name;
        public double g;
        public int prev;
    }
}
