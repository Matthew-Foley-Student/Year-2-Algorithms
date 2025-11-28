/*
 * Matthew Foley
 * CST-201-O500
 * November 2025
 * Activity 1
 */
using System.Text;
using static TowereOfHanoi.Form1;

namespace TowereOfHanoi
{
    public partial class Form1 : Form
    {  
        public Form1()
        {
            InitializeComponent();
            lblNumMoves.Visible = false;
          
        }

        private void btnStartTowerClick(object sender, EventArgs e)
        {
            int towerRings;
            int ringName = 0;
            try
            {
                towerRings = Convert.ToInt32(txtTowerNumber.Text);
                if (towerRings <= 0)
                {

                }
                else
                {
                    var towerOfHanoi = new TowerOfHanoi();
                    while (ringName < towerRings)
                    {
                    string movements = towerOfHanoi.Solve(towerRings, 'A', 'B', 'C',ringName);
                        ringName++;                    
                        rtxtInfoDump.Text = movements;                

                    }

                    int numLines = rtxtInfoDump.Lines.Length - 1;
                    string numberMove = numLines.ToString();
                    lblNumMoves.Text = numberMove;
                    lblNumMoves.Visible = true;
                }
            }
            catch
            {

            }
        }


        public class TowerOfHanoi
        {
            private StringBuilder movements;
            public TowerOfHanoi()
            {
                movements = new StringBuilder();
            }

            public string Solve(int numDisks, char startingDisk, char middleDisk, char destinationDisk,int diskName)
            {

                var stack = new Stack<Move>();
                stack.Push(new Move(numDisks, startingDisk, middleDisk, destinationDisk,diskName));

                while (stack.Count > 0)
                {
                    var move = stack.Pop();

                    if (move.NumDisks == 1)
                    {
                        movements.AppendLine($"getting disk {move.DiskName} to the end. A disk from {move.StartingDisk} to {move.DestinationDisk}");
                    }
                    else
                    {
                        stack.Push(new Move(move.NumDisks - 1, move.MiddleDisk, move.StartingDisk, move.DestinationDisk,move.DiskName));
                        stack.Push(new Move(1, move.StartingDisk, move.MiddleDisk, move.DestinationDisk, move.DiskName));
                        stack.Push(new Move(move.NumDisks - 1, move.StartingDisk, move.DestinationDisk, move.MiddleDisk, move.DiskName));
                    }
                }

                return movements.ToString();
            }
            private class Move
            {
                public int NumDisks { get; }
                public char StartingDisk { get; }
                public char MiddleDisk { get; }
                public char DestinationDisk { get; }
                public int DiskName { get; }

                public Move(int numDisks, char startingDisk, char middleDisk, char destinationDisk, int diskName)
                {
                    NumDisks = numDisks;
                    StartingDisk = startingDisk;
                    MiddleDisk = middleDisk;
                    DestinationDisk = destinationDisk;
                    DiskName = diskName;
                }
            }
        }

    }
}


