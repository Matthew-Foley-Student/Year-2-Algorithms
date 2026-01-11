/*
 * Matthew Foley
 * CST-201-O500
 * January 2025
 * Activity 7
 */
using System.Linq.Expressions;
using System.Text;

namespace ColorAlgorithm
{
    public partial class Form1 : Form
    {
       public StringBuilder AllInformation = new StringBuilder();
        public Form1()
        {
            InitializeComponent();
            bool[,] graph = {
            { false, true, true, false, true, false, false },
            { true, false, true, true, false, true, false },
            { true, true, false, true, false, true, true },
            { false, true, true, false,false, true, true },
            {true, false, false, false, false, true, true},
            {false, true, true, true, true, false, false },
            {false, false, true, true, true, false, false }
        };
            //-----------------------------------------------------------------------------------------------


            // Number of colors (change to attempt to increase or decreese the allowed number of cloros it will still try to use the least amount)
            int m = 10;
            //-----------------------------------------------------------------------------------------------

            // Function call
            AllInformation.AppendLine(SolveGraphColoring(graph, m));

            rtxtAnswers.Text = AllInformation.ToString();

        }


        // Number of vertices in the graph
        const int V = 7;

        // A utility function to check if the current color assignment is safe for vertex v
        static bool IsSafe(int v, bool[,] graph, int[] color, int c)
        {
            for (int i = 0; i < V; i++)
            {
                if (graph[v, i] && c == color[i])
                    return false;
            }
            return true;
        }

        // A recursive utility function to solve m coloring problem
        static bool GraphColoringUtil(bool[,] graph, int m, int[] color, int v)
        {
            if (v == V)
                return true;

            for (int c = 1; c <= m; c++)
            {
                if (IsSafe(v, graph, color, c))
                {
                    color[v] = c;

                    if (GraphColoringUtil(graph, m, color, v + 1))
                        return true;

                    color[v] = 0;
                }
            }
            return false;
        }

        // This function solves the m Coloring problem using Backtracking
        static string SolveGraphColoring(bool[,] graph, int m)
        {
            int[] color = new int[V];
            for (int i = 0; i < V; i++)
                color[i] = 0;

            if (!GraphColoringUtil(graph, m, color, 0))
            {
                return "Solution does not exist";
            }

            ;
            return PrintSolution(color);
        }

        // A utility function to print solution
        static string PrintSolution(int[] color)
        {
            StringBuilder AllInformation = new StringBuilder();

            AllInformation.Append("Solution Exists: Following are the assigned colors");
            for (int i = 0; i < V; i++)
                AllInformation.Append(" " + color[i] + " ");
           AllInformation.AppendLine();
            return AllInformation.ToString();
        }
    }
}
