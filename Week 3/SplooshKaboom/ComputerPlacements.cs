/*
 * Matthew Foley and Justin Albecker
 * CST-201-O500
 * December 2025
 * BattleShips
 */
using BattleShipLibrary.Models;
using BattleShipLibrary.Services.Buisness_Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace SplooshKaboom
{
    /// <summary>
    /// Handles the computer's ship placements and gameplay loop
    /// </summary>

    public partial class frmComputerPlacements : Form
    {
        // Boards for player and enemy
        private BoardModel playerBoard;
        private BoardModel enemyBoard;

        // Buttons for player and enemy boards
        private Button[,] playerButtons;
        private Button[,] enemyButtons;

        // Random number generator for ship placement and targeting
        private Random _rand = new Random();

        // Queue for computer targeting logic
        private Queue<Point> targetQueue = new Queue<Point>();

        // Track hits for each enemy ship type
        private int hitsSubEnemy = 0;
        private int hitsCruEnemy = 0;
        private int hitsDesEnemy = 0;

        // Reference to the ship placing form.
        private frmPlayerForm playerForm;

        // Preloaded images for hits, misses, and aiming
        private static Image hitIMG = Image.FromFile(Path.Combine(Application.StartupPath, "PNG_Assets", "explosion.png"));
        private static Image missIMG = Image.FromFile(Path.Combine(Application.StartupPath, "PNG_Assets", "buoy.png"));
        private static Image aimIMG = Image.FromFile(Path.Combine(Application.StartupPath, "PNG_Assets", "crosshair.png"));

        /// <summary>
        /// initializes the form with a reference to the parent ship placing form
        /// </summary>
        /// <param name="parent"></param>
        public frmComputerPlacements(frmPlayerForm parent)
        {
            InitializeComponent();
            playerForm = parent;
        }

        /// <summary>
        /// Starts the gameplay by setting up boards and placing enemy ships
        /// </summary>
        /// <param name="placedPlayerBoard"></param>
        public void StartGamePlay(BoardModel placedPlayerBoard)
        {
            playerBoard = placedPlayerBoard;
            enemyBoard = new BoardModel(playerBoard.Size);

            // Initialize button arrays
            playerButtons = new Button[playerBoard.Size, playerBoard.Size];
            enemyButtons = new Button[enemyBoard.Size, enemyBoard.Size];

            // Create both boards
            SetupBoard(pnlPlayerBoard, playerBoard, playerButtons, false);
            SetupBoard(pnlEnemyBoard, enemyBoard, enemyButtons, true);

            // Place enemy ships and paint player ships
            PlaceEnemyShips();
            PaintPlayerShips();
        }

        /// <summary>
        /// Creates a board of buttons within the specified panel and attaches event handlers
        /// </summary>
        /// <param name="panel"></param>
        /// <param name="board"></param>
        /// <param name="buttons"></param>
        /// <param name="isEnemy"></param>
        /// <exception cref="ArgumentNullException"></exception>
        private void SetupBoard(Panel panel, BoardModel board, Button[,] buttons, bool isEnemy)
        {

            if (panel == null) throw new ArgumentNullException(nameof(panel));
            if (board == null) throw new ArgumentNullException(nameof(board));
            if (buttons == null) throw new ArgumentNullException(nameof(buttons));

            // Clear old controls to avoid memory leaks
            foreach (Control ctl in panel.Controls.Cast<Control>().ToArray())
                ctl.Dispose();
            panel.Controls.Clear();

            // Calculate button size (minimum 18px)
            int buttonSize = Math.Max(18, panel.Width / board.Size);
            panel.Height = panel.Width; // keep square

            panel.SuspendLayout();
            try
            {
                for (int row = 0; row < board.Size; row++)
                {
                    for (int col = 0; col < board.Size; col++)
                    {
                        var btn = new Button
                        {
                            Width = buttonSize,
                            Height = buttonSize,
                            Left = col * buttonSize,
                            Top = row * buttonSize,
                            Tag = new Point(row, col),
                            BackColor = Color.LightBlue
                        };

                        // Hover effect that shows a crosshair when hovering over buttons
                        btn.MouseEnter += (s, e) =>
                        {
                            if (btn.BackgroundImage == null)
                            {
                                btn.BackgroundImage = aimIMG;
                                btn.BackgroundImageLayout = ImageLayout.Zoom;
                            }
                        };
                        btn.MouseLeave += (s, e) =>
                        {
                            if (btn.BackgroundImage == aimIMG)
                                btn.BackgroundImage = null;
                        };

                        // Attach click event for enemy board buttons
                        if (isEnemy)
                            btn.Click += EnemyBoard_Click;

                        panel.Controls.Add(btn);
                        buttons[row, col] = btn;
                    }
                }
            }
            finally
            {
                panel.ResumeLayout(false);
            }
        }

        /// <summary>
        ///  Randomly places enemy ships on the enemy board
        /// </summary>
        private void PlaceEnemyShips()
        {
            BoardLogic logic = new BoardLogic();

            PlaceBoat(new[] { "destroyerul", "destroyerur", "destroyerdl", "destroyerdr" },
                      cell => cell.ShipType.StartsWith("D"),
                      (r, c, o) => logic.MarkLegalLocation(enemyBoard, enemyBoard.Grid[r, c], o));

            PlaceBoat(new[] { "cruiserul", "cruiserur", "cruiserdl", "cruiserdr" },
                      cell => cell.ShipType.StartsWith("C"),
                      (r, c, o) => logic.MarkLegalLocation(enemyBoard, enemyBoard.Grid[r, c], o));

            PlaceBoat(new[] { "submarineul", "submarineur", "submarinedl", "submarinedr" },
                      cell => cell.ShipType.StartsWith("S"),
                      (r, c, o) => logic.MarkLegalLocation(enemyBoard, enemyBoard.Grid[r, c], o));

            foreach (var cell in enemyBoard.Grid)
                if (!string.IsNullOrEmpty(cell.ShipType)) cell.Ship = true;
        }

        /// <summary>
        /// Attempts to place a boat until a valid position is found
        /// </summary>
        /// <param name="orientations"></param>
        /// <param name="isValid"></param>
        /// <param name="placeAction"></param>
        private void PlaceBoat(string[] orientations, Func<CellModel, bool> isValid, Action<int, int, string> placeAction)
        {
            bool placed = false;
            while (!placed)
            {
                int r = _rand.Next(enemyBoard.Size);
                int c = _rand.Next(enemyBoard.Size);
                string o = orientations[_rand.Next(orientations.Length)];
                placeAction(r, c, o);
                if (isValid(enemyBoard.Grid[r, c])) placed = true;
            }
        }

        /// <summary>
        /// Paints the player's ships on their board
        /// </summary>
        private void PaintPlayerShips()
        {
            for (int r = 0; r < playerBoard.Size; r++)
                for (int c = 0; c < playerBoard.Size; c++)
                    if (playerBoard.Grid[r, c].Ship)
                        playerButtons[r, c].BackColor = Color.Gray;
        }

        /// <summary>
        /// Handles player clicks on the enemy board
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnemyBoard_Click(object sender, EventArgs e)
        {
            if (IsGameOver()) return;

            Button btn = (Button)sender;
            Point p = (Point)btn.Tag;
            var cell = enemyBoard.Grid[p.X, p.Y];

            if (cell.Revealed) return;

            cell.Revealed = true;

            // Hit
            if (cell.Ship)
            {
                btn.BackColor = Color.LightBlue;
                btn.BackgroundImage = hitIMG;
                btn.BackgroundImageLayout = ImageLayout.Zoom;
                btn.Text = "";

                if (cell.ShipType.StartsWith("S")) hitsSubEnemy++;
                else if (cell.ShipType.StartsWith("C")) hitsCruEnemy++;
                else if (cell.ShipType.StartsWith("D")) hitsDesEnemy++;

                UpdateShipLabels();
            }
            //Miss
            else
            {
                btn.BackColor = Color.LightBlue;
                btn.BackgroundImage = missIMG;
                btn.BackgroundImageLayout = ImageLayout.Zoom;
                btn.Text = "";
            }

            if (IsGameOver()) 
            { 
                ShowWinOrLose();
                return;
            }

            //Computer's turn
            ComputerTurn();
        }

        /// <summary>
        /// Executes the computer's turn by selecting a target and updating the player's board
        /// </summary>
        private void ComputerTurn()
        {
            if (IsGameOver())
                return;

            Point target = targetQueue.Count > 0 ? targetQueue.Dequeue() : PickRandomUnrevealed(playerBoard);
            var cell = playerBoard.Grid[target.X, target.Y];

            if (cell.Revealed) 
                return;

            cell.Revealed = true;

            if (cell.Ship)
            {
                playerButtons[target.X, target.Y].BackColor = Color.Gray;
                playerButtons[target.X, target.Y].BackgroundImage = hitIMG;
                playerButtons[target.X, target.Y].BackgroundImageLayout = ImageLayout.Zoom;
                playerButtons[target.X, target.Y].Text = "";

                // If hit, enqueue neighboring cells for next turn
                EnqueueNeighbors(target.X, target.Y, playerBoard);
            }
            else
            {
                // Miss
                playerButtons[target.X, target.Y].BackColor = Color.LightBlue;
                playerButtons[target.X, target.Y].BackgroundImage = missIMG;
                playerButtons[target.X, target.Y].BackgroundImageLayout = ImageLayout.Zoom;
                playerButtons[target.X, target.Y].Text = "";
            }

            if (IsGameOver()) ShowWinOrLose();
        }

        /// <summary>
        /// Picks a random unrevealed cell on the board for AI targeting
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        private Point PickRandomUnrevealed(BoardModel board)
        {
            for (int i = 0; i < 500; i++)
            {
                int r = _rand.Next(board.Size);
                int c = _rand.Next(board.Size);
                if (!board.Grid[r, c].Revealed) return new Point(r, c);
            }
            return new Point(0, 0);
        }

        /// <summary>
        /// Adds neighboring cells to the target queue for focused attacks.
        /// </summary>
        /// <param name="r"></param>
        /// <param name="c"></param>
        /// <param name="board"></param>
        private void EnqueueNeighbors(int r, int c, BoardModel board)
        {
            TryQueue(r - 1, c, board);
            TryQueue(r + 1, c, board);
            TryQueue(r, c - 1, board);
            TryQueue(r, c + 1, board);
        }

        /// <summary>
        /// Attempts to enqueue a cell if it's valid and unrevealed
        /// </summary>
        /// <param name="r"></param>
        /// <param name="c"></param>
        /// <param name="board"></param>
        private void TryQueue(int r, int c, BoardModel board)
        {
            if (r >= 0 && c >= 0 && r < board.Size && c < board.Size && !board.Grid[r, c].Revealed)
                targetQueue.Enqueue(new Point(r, c));
        }

        /// <summary>
        /// Updates the enemy ship labels to reflect sunk ships
        /// </summary>
        private void UpdateShipLabels()
        {
            if (hitsSubEnemy >= 3) { lblSub.Font = new Font(lblSub.Font, FontStyle.Strikeout); lblSub.ForeColor = Color.Red; }
            if (hitsCruEnemy >= 3) { lblCruis.Font = new Font(lblCruis.Font, FontStyle.Strikeout); lblCruis.ForeColor = Color.Red; }
            if (hitsDesEnemy >= 4) { lblDestroy.Font = new Font(lblDestroy.Font, FontStyle.Strikeout); lblDestroy.ForeColor = Color.Red; }

        }

        /// <summary>
        /// Checks if the game is over by verifying if all ships are sunk
        /// </summary>
        /// <returns></returns>
        private bool IsGameOver()
        {
            bool playerLost = playerBoard.Grid.Cast<CellModel>().All(c => !c.Ship || c.Revealed);
            bool enemyLost = enemyBoard.Grid.Cast<CellModel>().All(c => !c.Ship || c.Revealed);
            return playerLost || enemyLost;
        }

        /// <summary>
        /// Displays the win or lose message and disables further interaction
        /// </summary>
        private void ShowWinOrLose()
        {
            string condition = enemyBoard.Grid.Cast<CellModel>().All(c => !c.Ship || c.Revealed) ? "win" : "lose";

            frmWinOrLost resultForm = new frmWinOrLost(condition);
            resultForm.ShowDialog();
            this.Close();

            // Disable enemy buttons after game ends
            for (int r = 0; r < enemyBoard.Size; r++)
                for (int c = 0; c < enemyBoard.Size; c++)
                    enemyButtons[r, c].Enabled = false;
        }
    }
}