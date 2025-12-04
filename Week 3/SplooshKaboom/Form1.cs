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
        private int placementStage = 0;
        private int? lastPreviewRow = null;
        private int? lastPreviewCol = null;

        frmComputerPlacements start;
        int boat = 0;
        string shipSub = "submarineul";
        string shipCruise = "cruiserul";
        string shipDestroy = "destroyerul";

        public frmPlayerForm()
        {
            InitializeComponent();
            _boardLogic = new BoardLogic();
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
                    button.BackColor = Color.LightBlue;
                    pnlBoard.Controls.Add(_buttons[row, col]);

                }
            }
        }//end of the panel setups

        private void btnMouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            var btn = (Button)sender;
            var point = (Point)btn.Tag;
            int row = point.X;
            int col = point.Y;

            // Save last anchor and render preview
            lastPreviewRow = row;
            lastPreviewCol = col;

            RenderPreviewForStage(row, col);
        }

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
                placementStage = 0;
                UpdatePlacementUI();

            }
            catch (Exception) { }
        }

        private void UpdatePlacementUI()
        {
            switch (placementStage)
            {
                case 0:
                    lblShipType.Text = "Submarine";
                    btnPlay.Visible = false;
                    break;
                case 1:
                    lblShipType.Text = "Cruiser";
                    btnPlay.Visible = false;
                    break;
                case 2:
                    lblShipType.Text = "Destroyer";
                    // still not visible until confirmed
                    btnPlay.Visible = false;
                    break;
                default:
                    lblShipType.Text = "All ships placed";
                    btnPlay.Visible = true; // enable Play after all are placed
                    break;
            }
        }

        public static string sharedata;


        private void RenderPreviewForStage(int row, int col)
        {
            for (int i = 0; i < _board.Size; i++)
            {
                for (int j = 0; j < _board.Size; j++)
                {
                    if (_board.Grid[i, j].Ship == false)
                    {
                        _board.Grid[i, j].ShipType = "";
                        _buttons[i, j].BackColor = Color.LightBlue;

                    }
                }
            }

            if (placementStage == 0)
            {
                _boardLogic.MarkLegalLocation(_board, _board.Grid[row, col], shipSub);
            }
            else if (placementStage == 1)
            {
                _boardLogic.MarkLegalLocation(_board, _board.Grid[row, col], shipCruise);
            }
            else if (placementStage == 2)
            {
                _boardLogic.MarkLegalLocation(_board, _board.Grid[row, col], shipDestroy);
            }
            else
            {
                // All ships placed; no preview
                return;
            }

            for (int i = 0; i < _board.Size; i++)
            {
                for (int j = 0; j < _board.Size; j++)
                {
                    if (_board.Grid[i, j].Ship == false && _board.Grid[i, j].ShipType != "")
                    {
                        _buttons[i, j].Text = ""; // no letters
                        _buttons[i, j].BackColor = Color.Gray;
                    }
                }
            }
        }

        private void ResetFormState()
        {
            if (pnlBoard != null)
            {
                foreach (Control ctl in pnlBoard.Controls.Cast<Control>().ToArray())
                    ctl.Dispose();
                pnlBoard.Controls.Clear();
            }

            int size = 10;
            _board = new BoardModel(size);
            _boardLogic = new BoardLogic();

            _buttons = new Button[size, size];
            SetUpButton();

            placementStage = 0;
            shipSub = "submarineul";
            shipCruise = "cruiserul";
            shipDestroy = "destroyerul";

            lastPreviewRow = null;
            lastPreviewCol = null;

            btnPlay.Visible = false;
            UpdatePlacementUI();

            for (int r = 0; r < _board.Size; r++)
                for (int c = 0; c < _board.Size; c++)
                    _buttons[r, c].Enabled = true;

            if (start != null && !start.IsDisposed)
                start.Close();
            start = new frmComputerPlacements(this);
        }


        private void btnRotateShip_ClickEH(object sender, EventArgs e)
        {
            if (placementStage == 0)        // Submarine
                shipSub = (shipSub == "submarineul") ? "submarineur" : "submarineul";
            else if (placementStage == 1)   // Cruiser
                shipCruise = (shipCruise == "cruiserul") ? "cruiserur" : "cruiserul";
            else if (placementStage == 2)   // Destroyer
                shipDestroy = (shipDestroy == "destroyerul") ? "destroyerur" : "destroyerul";

            if (lastPreviewRow.HasValue && lastPreviewCol.HasValue && placementStage <= 2)
            {
                RenderPreviewForStage(lastPreviewRow.Value, lastPreviewCol.Value);
            }

            UpdatePlacementUI();
        }

        private void btnConfirm_ClickEH(object sender, EventArgs e)
        {
            bool committed = false;

            if (placementStage == 0) // Submarine
            {
                int count = 0;
                for (int i = 0; i < _board.Size; i++)
                {
                    for (int j = 0; j < _board.Size; j++)
                    {
                        var t = _board.Grid[i, j].ShipType;
                        if (t == "Sul" || t == "Sur" || t == "Sdl" || t == "Sdr")
                            count++;
                    }
                }

                if (count == 3)
                {
                    // Commit submarine marks
                    for (int i = 0; i < _board.Size; i++)
                    {
                        for (int j = 0; j < _board.Size; j++)
                        {
                            var cell = _board.Grid[i, j];
                            if (cell.ShipType == "Sul" || cell.ShipType == "Sur" || cell.ShipType == "Sdl" || cell.ShipType == "Sdr")
                            {
                                cell.Ship = true;
                                _buttons[i, j].BackColor = Color.Brown;
                                _buttons[i, j].Text = "";
                            }
                        }
                    }
                    committed = true;
                    placementStage = 1;   // move to Cruiser
                }
                else
                {
                    MessageBox.Show("Submarine preview is invalid or incomplete.", "Cannot confirm");
                }
            }
            else if (placementStage == 1) // Cruiser
            {
                int count = 0;
                for (int i = 0; i < _board.Size; i++)
                    for (int j = 0; j < _board.Size; j++)
                        if (_board.Grid[i, j].ShipType == "C")
                            count++;

                if (count == 3)
                {
                    for (int i = 0; i < _board.Size; i++)
                    {
                        for (int j = 0; j < _board.Size; j++)
                        {
                            var cell = _board.Grid[i, j];
                            if (cell.ShipType == "C")
                            {
                                cell.Ship = true;
                                _buttons[i, j].BackColor = Color.Brown;
                                _buttons[i, j].Text = "";
                            }
                        }
                    }
                    committed = true;
                    placementStage = 2;   // move to Destroyer
                }
                else
                {
                    MessageBox.Show("Cruiser preview is invalid or incomplete.", "Cannot confirm");
                }
            }
            else if (placementStage == 2) // Destroyer
            {
                int count = 0;
                for (int i = 0; i < _board.Size; i++)
                    for (int j = 0; j < _board.Size; j++)
                        if (_board.Grid[i, j].ShipType == "D")
                            count++;

                if (count == 4)
                {
                    for (int i = 0; i < _board.Size; i++)
                    {
                        for (int j = 0; j < _board.Size; j++)
                        {
                            var cell = _board.Grid[i, j];
                            if (cell.ShipType == "D")
                            {
                                cell.Ship = true;
                                _buttons[i, j].BackColor = Color.Brown;
                                _buttons[i, j].Text = "";
                            }
                        }
                    }
                    committed = true;
                    placementStage = 3;   // all ships placed
                }
                else
                {
                    MessageBox.Show("Destroyer preview is invalid or incomplete.", "Cannot confirm");
                }
            }

            // After any confirm attempt:
            if (committed)
            {
                // Clear previews on empty cells to avoid leftover letters
                for (int i = 0; i < _board.Size; i++)
                {
                    for (int j = 0; j < _board.Size; j++)
                    {
                        if (_board.Grid[i, j].Ship == false)
                        {
                            _board.Grid[i, j].ShipType = "";
                            
                        }
                    }
                }
            }

            UpdatePlacementUI();

            // If everything placed, you may optionally disable further clicks on the board
            if (placementStage >= 3)
            {
                for (int h = 0; h < _board.Size; h++)
                    for (int g = 0; g < _board.Size; g++)
                        _buttons[h, g].Enabled = true; // keep enabled if you want to review; or set false to lock
            }
        }

        private void btnPlay_ClickEH(object sender, EventArgs e)
        {
            for (int h = 0; h < _board.Size; h++)
                for (int g = 0; g < _board.Size; g++)
                    _buttons[h, g].Enabled = false;

            start.Show();
            start.BeginInvoke(new Action(() =>
            {
                start.StartGamePlay(_board);
            }));
            this.Hide();
        }

        private void btnReset_ClickEH(object sender, EventArgs e)
        {
            ResetFormState();
        }
    }
}
