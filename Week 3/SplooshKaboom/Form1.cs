/*
 * Matthew Foley
 * CST-201-O500
 * December 2025
 * BattleShips
 */
using BattleShipLibrary.Models;
using BattleShipLibrary.Services.Buisness_Logic;

namespace SplooshKaboom
{
    public partial class frmPlayerForm : Form
    {
        private BoardModel _board;
        private BoardLogic _boardLogic;
        private Button[,] _buttons;
        frmComputerPlacements start;
        int boat = 0;
        string shipSub = "submarineul";
        string shipCruise = "cruiserul";
        string shipDestroy = "destroyerul";

        public frmPlayerForm()
        {
            InitializeComponent();
            _boardLogic = new BoardLogic();
            lblCruiser.Visible = false;
            lblDestroy.Visible = false;
            lblSub.Visible = false;
            start = new frmComputerPlacements(this);

        }

        private void SetUpButton()
        {
            int buttonSize = pnlBoard.Width / _board.Size;
            pnlBoard.Height = pnlBoard.Width;

            for (int row = 0; row < _board.Size; row++)
            {
                for (int col = 0; col < _board.Size; col++)
                {
                    _buttons[row, col] = new Button();
                    Button button = _buttons[row, col];
                    //set the size's
                    button.Width = buttonSize;
                    button.Height = buttonSize;
                    //Set Button Locations
                    button.Left = col * buttonSize;
                    button.Top = row * buttonSize;
                    
                    _board.Grid[row, col].Revealed = false;
                    _board.Grid[row, col].Ship = false;
                    _board.Grid[row, col].ShipType = "";
                    //Set the Click Capeabilities for the buttons
                    button.MouseDown += btnMouseClick;
                    //store button's capeabilites
                    button.Tag = new Point(row, col);
                    button.Text = $"{row}, {col}";
                    pnlBoard.Controls.Add(_buttons[row, col]);

                }
            }
        }//end of the panel setups

        private void btnMouseClick(object sender, MouseEventArgs e)
        {
            Button button = (Button)sender;
            Point point = (Point)button.Tag;
            int row = point.X;
            int col = point.Y;
            if (e.Button == MouseButtons.Left)
            {
                _buttons[row, col].Text = "";
                for (int i = 0; i < _board.Size; i++)
                {
                    for (int j = 0; j < _board.Size; j++)
                    {
                        if (_board.Grid[i, j].Ship == false)
                            _buttons[i, j].Text = $"{i}, {j}";
                        _board.Grid[i, j].ShipType = "";
                    }
                }
                if (boat == 0)
                {
                    _boardLogic.MarkLegalLocation(_board, _board.Grid[row, col], shipSub);
                    for (int i = 0; i < _board.Size; i++)
                    {
                        for (int j = 0; j < _board.Size; j++)
                        {
                            if (_board.Grid[i, j].ShipType == "Sul" || _board.Grid[i, j].ShipType == "Sur")
                            {
                                _buttons[row, col].Text = "";
                                _board.Grid[i, j].Ship = true;
                                _buttons[i, j].BackColor = Color.Brown;
                            }
                        }
                    }
                }
                else if (boat >= 3 && boat < 6)
                {
                    _boardLogic.MarkLegalLocation(_board, _board.Grid[row, col], shipCruise);
                    for (int i = 0; i < _board.Size; i++)
                    {
                        for (int j = 0; j < _board.Size; j++)
                        {
                            if (_board.Grid[i, j].ShipType == "C")
                            {
                                _buttons[row, col].Text = "";
                                _board.Grid[i, j].Ship = true;
                                _buttons[i, j].BackColor = Color.Brown;
                            }
                        }
                    }
                }
                else
                {
                    _boardLogic.MarkLegalLocation(_board, _board.Grid[row, col], shipDestroy);
                    for (int i = 0; i < _board.Size; i++)
                    {
                        for (int j = 0; j < _board.Size; j++)
                        {
                            if (_board.Grid[i, j].ShipType == "D")
                            {
                                _board.Grid[i, j].Ship = true;
                                _buttons[i, j].BackColor = Color.Brown;
                                _buttons[row, col].Text = "";
                            }
                        }
                    }
                }
                _buttons[row, col].Text = "";
                for (int i = 0; i < _board.Size; i++)
                {
                    for (int j = 0; j < _board.Size; j++)
                    {
                        if (_board.Grid[i, j].Ship == true && _board.Grid[i, j].ShipType != "D")
                        {
                            _buttons[i, j].Text = "";
                            boat++;
                        }

                        if (_board.Grid[i, j].Ship == true && _board.Grid[i, j].ShipType == "D")
                        {
                            for (int h = 0; h < _board.Size; h++)
                            {
                                for (int g = 0; g < _board.Size; g++)
                                {
                                    _buttons[h, g].Enabled = false;
                                }
                            }

                            // Show ship labels
                            lblCruiser.Visible = true;
                            lblDestroy.Visible = true;
                            lblSub.Visible = true;
                            lblExplination.Visible = false;

                            // Transition to battle form
                            start.Show();

                            // Delay StartGameplay until after layout
                            start.BeginInvoke(new Action(() =>
                            {
                                start.StartGamePlay(_board); // Pass player's board
                            }));

                            this.Hide();
                        }

                        else
                        {
                            button.Text = $"{row}, {col}";

                        }
                    }
                }
            }//End of Left Click

            if (e.Button == MouseButtons.Right)
            {
                for (int i = 0; i < _board.Size; i++)
                {
                    for (int j = 0; j < _board.Size; j++)
                    {
                        if (_board.Grid[i, j].Ship == false)
                            _buttons[i, j].Text = $"{i}, {j}";
                        _board.Grid[i, j].ShipType = "";
                    }
                }
                if (boat == 0)
                {
                    _boardLogic.MarkLegalLocation(_board, _board.Grid[row, col], shipSub);
                    for (int i = 0; i < _board.Size; i++)
                    {
                        for (int j = 0; j < _board.Size; j++)
                        {
                            if (_board.Grid[i, j].Ship == false && _board.Grid[i, j].ShipType != "")
                                _buttons[i, j].Text = _board.Grid[i, j].ShipType;
                        }
                    }
                }
                else if (boat >= 3 && boat < 6)
                {
                    _boardLogic.MarkLegalLocation(_board, _board.Grid[row, col], shipCruise);
                    for (int i = 0; i < _board.Size; i++)
                    {
                        for (int j = 0; j < _board.Size; j++)
                        {
                            if (_board.Grid[i, j].Ship == false && _board.Grid[i, j].ShipType != "")
                                _buttons[i, j].Text = _board.Grid[i, j].ShipType;
                        }
                    }
                }
                else
                {
                    _boardLogic.MarkLegalLocation(_board, _board.Grid[row, col], shipDestroy);
                    for (int i = 0; i < _board.Size; i++)
                    {
                        for (int j = 0; j < _board.Size; j++)
                        {
                            if (_board.Grid[i, j].Ship == false && _board.Grid[i, j].ShipType != "")
                                _buttons[i, j].Text = _board.Grid[i, j].ShipType;
                        }
                    }

                }
            }//End of Right Click

            if (e.Button == MouseButtons.Middle)
            {
                if (shipSub == "submarineul")
                {
                    shipSub = "submarineur";
                }
                else
                {
                    shipSub = "submarineul";
                }
                if (shipCruise == "cruiserul")
                {
                    shipCruise = "cruiserur";
                }
                else
                {
                    shipCruise = "cruiserul";
                }
                if (shipDestroy == "destroyerul")
                {
                    shipDestroy = "destroyerur";
                }
                else
                {
                    shipDestroy = "destroyerul";
                }
            }

        }//End of the mouse buttons setUp

        private void StartTheProgram(object sender, EventArgs e)
        {
            int size = 0;
            try
            {
                size = 10;

                _board = new BoardModel(size);
                _boardLogic = new BoardLogic();
                _buttons = new Button[size, size];
                SetUpButton();

            }
            catch (Exception) { }
        }

        public static string sharedata;
    }
}
