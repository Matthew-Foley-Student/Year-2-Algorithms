/*
 * Matthew Foley
 * CST-201-O500
 * December 2025
 * Activity 5
 */
using System.Collections.Generic;
using System.Text;

namespace Graph_Weight_Algorithms
{
    public partial class Form1 : Form
    {
        const int positiveInfinity = 1000000;
        //const int positiveInfinity = int.MaxValue;
        private StringBuilder AllInformation;
        public Form1()
        {
            InitializeComponent();
            AllInformation = new StringBuilder();

            List<int> arr = new List<int> { 0, 3, positiveInfinity, positiveInfinity, 1 };
            foreach (int i in arr)
            {
                if (i == int.MaxValue || i == 1000000)
                {
                    AllInformation.Append("INF" + ",");
                }
                else
                {
                    AllInformation.Append(i + ",");
                }

            } 
            AllInformation.AppendLine();
           arr = new List<int> { positiveInfinity, 0, 6, positiveInfinity, 3 };
            foreach (int i in arr)
            {
                if (i == int.MaxValue|| i == 1000000)
                {
                    AllInformation.Append("INF" + ",");
                }
                else
                {
                    AllInformation.Append(i + ",");
                }

            }
            AllInformation.AppendLine();
            arr = new List<int> { 1, positiveInfinity, 0, positiveInfinity, positiveInfinity };
            foreach (int i in arr)
            {
                if (i == int.MaxValue || i == 1000000)
                {
                    AllInformation.Append("INF" + ",");
                }
                else
                {
                    AllInformation.Append(i + ",");
                }

            }

            AllInformation.AppendLine();
            arr = new List<int> { -4, positiveInfinity, 5, 0, positiveInfinity };
            foreach (int i in arr)
            {
                if (i == int.MaxValue || i == 1000000)
                {
                    AllInformation.Append("INF" + ",");
                }
                else
                {
                    AllInformation.Append(i + ",");
                }

            }
            AllInformation.AppendLine();
            arr = new List<int> { positiveInfinity, positiveInfinity, 2, 2, 0 };
            foreach (int i in arr)
            {
                if (i == int.MaxValue || i == 1000000)
                {
                    AllInformation.Append("INF" + ",");
                }
                else
                {
                    AllInformation.Append(i + ",");
                }

            }
            AllInformation.AppendLine();            
            AllInformation.AppendLine("The Min Cycle Of The Supplied Graph Above Is :");
            //End of The List Print---------------------------------------------
            int[,] edge = {
                {0, 3, positiveInfinity, positiveInfinity, 1},
                {positiveInfinity, 0, 6, positiveInfinity, 3},
                {1, positiveInfinity,0,positiveInfinity, positiveInfinity},
                {4, positiveInfinity,5,0,positiveInfinity},
                {positiveInfinity,positiveInfinity,2,2,0}
            };
            floydWarshall(edge);
            for (int i = 0; i < edge.GetLength(0); i++)
            {
                for (int j = 0; j < edge.GetLength(1); j++)
                {
                    AllInformation.Append(edge[i, j] + " ");
                }
                AllInformation.AppendLine();
            }


        }
        static void floydWarshall(int[,] dist)
        {
            int V = dist.GetLength(0);

            for (int k = 0; k < V; k++)
            {
                for (int i = 0; i < V; i++)
                {
                    for (int j = 0; j < V; j++)
                    {
                        // shortest path from
                        // i to j 
                        if (dist[i, k] != 1e8 && dist[k, j] != 1e8)
                            dist[i, j] = Math.Min(dist[i, j], dist[i, k] + dist[k, j]);
                    }
                }
            }
        }

        private void VisibleLbl(object sender, EventArgs e)
        {
            rchTxtSolution.Text = AllInformation.ToString();
        }
    }
}
