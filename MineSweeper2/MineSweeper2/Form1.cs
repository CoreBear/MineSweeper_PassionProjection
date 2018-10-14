using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeper2
{
    public partial class Form1 : Form
    {
        Color gridColor;
        Color clickedCellColor;
        Color unclickedCellColor;
        Color flaggedColor;
        Color explodedColor;
        Color wrongColor;
        enum GridState { UNCLICKED, CLICKED, MINED, FLAGGED, SUSPECTED, EXPLODED, WRONG_GUESS };
        enum GameState { WON, PLAYING, LOST, WAITING};
        float cellWidth;
        float cellHeight;
        int[] customDifficulty;
        int oneSecond;
        int gameState;
        int gridXSize;
        int gridYSize;
        int[,] grid;
        int numberOfMines;
        int[] minePositions;
        int numberOfGridSpaces;
        int time;
        Random randomMinePositions;
        Timer timer;

        public Form1()
        {
            InitializeComponent();
            time = 0;
            oneSecond = 1000;
            gameState = (int)GameState.WAITING;
            gridColor = Color.Black;
            clickedCellColor = Color.DarkGray;
            unclickedCellColor = Color.LightGray;
            explodedColor = Color.Red;
            wrongColor = Color.Blue;
            flaggedColor = gridColor;
            gridXSize = 9;
            gridYSize = 9;
            grid = new int[gridXSize, gridYSize];
            numberOfMines = 10;
            minePositions = new int[numberOfMines];
            numberOfGridSpaces = gridXSize * gridYSize;
            randomMinePositions = new Random();
            textBoxFlags.Text = numberOfMines.ToString();
            customDifficulty = new int[3] { 20, 30, 145 };
            timer = new Timer();
            timer.Interval = oneSecond;
            timer.Start();
            timer.Tick += Timer_Tick;
            PlaceMines();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (gameState == (int)GameState.PLAYING)
            {
                ++time;
                graphicsPanel1.Invalidate();
            }
        }

        private void PlaceMines()
        {            
            int gridSpace = 0;
            int x;
            int y;
            int z;

            //Getting random spaces for the mines
            for (x = 0; x < numberOfMines; x++)
            {
                minePositions[x] = randomMinePositions.Next() % numberOfGridSpaces;

                for (y = 0; y < x; y++)
                {
                    while (true)
                    {
                        if (minePositions[x] != minePositions[y])
                            break;
                        else
                            minePositions[x] = randomMinePositions.Next() % numberOfGridSpaces;
                    }                    
                }
            }
            
            //Marking cells with mines
            for (x = 0; x < gridXSize; x++)
            {
                for (y = 0; y < gridYSize; y++)
                {
                    for (z = 0; z < minePositions.Length; z++)
                    {
                        if(gridSpace == minePositions[z])
                        {
                            grid[x, y] = (int)GridState.MINED;
                            break;
                        }
                    }
                    ++gridSpace;
                }
            }
        }
        private void graphicsPanel1_Paint(object sender, PaintEventArgs e)
        {
            int mineCount = 0;

            textBoxFlags.Text = (numberOfMines - CountFlags()).ToString();
            textBoxTimer.Text = time.ToString();

            cellWidth = (float)graphicsPanel1.ClientSize.Width / gridXSize;
            cellHeight = (float)graphicsPanel1.ClientSize.Height / gridYSize;

            Pen gridPen = new Pen(gridColor, 2);
            Brush unclickedBrush = new SolidBrush(unclickedCellColor);
            Brush clickedBrush = new SolidBrush(clickedCellColor);
            Brush flaggedBrush = new SolidBrush(flaggedColor);
            Brush explodedBrush = new SolidBrush(explodedColor);
            Brush wrongBrush = new SolidBrush(wrongColor);

            RectangleF cell;

            for (int x = 0; x < gridXSize; x++)
            {
                for (int y = 0; y < gridYSize; y++)
                {
                    cell = RectangleF.Empty;
                    cell.X = x * cellWidth;
                    cell.Y = y * cellHeight;
                    cell.Width = cellWidth;
                    cell.Height = cellHeight;

                    e.Graphics.DrawRectangle(gridPen, cell.X, cell.Y, cell.Width, cell.Height);

                    if (grid[x, y] == (int)GridState.UNCLICKED || grid[x, y] == (int)GridState.MINED)
                        e.Graphics.FillRectangle(unclickedBrush, cell.X, cell.Y, cell.Width, cell.Height);
                    else if (grid[x, y] == (int)GridState.CLICKED)
                        e.Graphics.FillRectangle(clickedBrush, cell.X, cell.Y, cell.Width, cell.Height);
                    else if (grid[x, y] == (int)GridState.FLAGGED || grid[x, y] == (int)GridState.SUSPECTED)
                        e.Graphics.FillRectangle(flaggedBrush, cell.X, cell.Y, cell.Width, cell.Height);
                    else if (grid[x, y] == (int)GridState.EXPLODED)
                        e.Graphics.FillRectangle(explodedBrush, cell.X, cell.Y, cell.Width, cell.Height);
                    else
                        e.Graphics.FillRectangle(wrongBrush, cell.X, cell.Y, cell.Width, cell.Height);

                    Font font = new Font("Arial", 20f);
                    StringFormat stringFormat = new StringFormat();
                    stringFormat.Alignment = StringAlignment.Center;
                    stringFormat.LineAlignment = StringAlignment.Center;
                    float fontSize = cellHeight / 2;
                    mineCount = CountSurroundingMines(x, y);

                    if (grid[x, y] == (int)GridState.CLICKED)
                    {
                        switch (mineCount)
                        {
                            case 1:
                                e.Graphics.DrawString(mineCount.ToString(), font, Brushes.Blue, cell, stringFormat);
                                break;
                            case 2:
                                e.Graphics.DrawString(mineCount.ToString(), font, Brushes.Green, cell, stringFormat);
                                break;
                            case 3:
                                e.Graphics.DrawString(mineCount.ToString(), font, Brushes.Red, cell, stringFormat);
                                break;
                            case 4:
                                e.Graphics.DrawString(mineCount.ToString(), font, Brushes.Purple, cell, stringFormat);
                                break;
                            case 5:
                                e.Graphics.DrawString(mineCount.ToString(), font, Brushes.Maroon, cell, stringFormat);
                                break;
                            case 6:
                                e.Graphics.DrawString(mineCount.ToString(), font, Brushes.Turquoise, cell, stringFormat);
                                break;
                            case 7:
                                e.Graphics.DrawString(mineCount.ToString(), font, Brushes.Black, cell, stringFormat);
                                break;
                            case 8:
                                e.Graphics.DrawString(mineCount.ToString(), font, Brushes.Gray, cell, stringFormat);
                                break;
                            default:
                                break;
                        }                       
                    }
                }
            }
        }
        private void graphicsPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (gameState == (int)GameState.PLAYING || gameState == (int)GameState.WAITING)
            {
                float mouseX = e.X / cellWidth;
                float mouseY = e.Y / cellHeight;

                if (e.Button == MouseButtons.Left)
                {
                    if (grid[(int)mouseX, (int)mouseY] == (int)GridState.UNCLICKED)
                    {
                        grid[(int)mouseX, (int)mouseY] = (int)GridState.CLICKED;

                        EnableNeighbors((int)mouseX, (int)mouseY);
                        
                        if (CheckForWin())
                        {
                            gameState = (int)GameState.WON;
                            Win();
                        }

                        if (gameState == (int)GameState.WAITING)
                            gameState = (int)GameState.PLAYING;
                    }
                    else if (grid[(int)mouseX, (int)mouseY] == (int)GridState.CLICKED)
                    {
                        if (MinesMissed((int)mouseX, (int)mouseY) == 0)
                            EnableNeighbors((int)mouseX, (int)mouseY);

                        else if (MinesMissed((int)mouseX, (int)mouseY) == 1)
                        {
                            EnableAllMines();
                            EnableWrongs((int)mouseX, (int)mouseY);
                            gameState = (int)GameState.LOST;
                        }

                        if (CheckForWin())
                        {
                            gameState = (int)GameState.WON;
                            Win();
                        }
                    }
                    else if (grid[(int)mouseX, (int)mouseY] == (int)GridState.MINED)
                    {
                        EnableAllMines();
                        gameState = (int)GameState.LOST;
                    }
                }
                else if (e.Button == MouseButtons.Right)
                {
                    if (grid[(int)mouseX, (int)mouseY] == (int)GridState.UNCLICKED)
                    {
                        if (numberOfMines - CountFlags() > 0)
                            grid[(int)mouseX, (int)mouseY] = (int)GridState.SUSPECTED;
                    }
                    else if (grid[(int)mouseX, (int)mouseY] == (int)GridState.MINED)
                    {
                        if (numberOfMines - CountFlags() > 0)
                            grid[(int)mouseX, (int)mouseY] = (int)GridState.FLAGGED;
                    }
                    else if (grid[(int)mouseX, (int)mouseY] == (int)GridState.SUSPECTED)
                        grid[(int)mouseX, (int)mouseY] = (int)GridState.UNCLICKED;
                    else if (grid[(int)mouseX, (int)mouseY] == (int)GridState.FLAGGED)
                        grid[(int)mouseX, (int)mouseY] = (int)GridState.MINED;
                }
                graphicsPanel1.Invalidate();
            }
        }
        private void EnableNeighbors(int cellX, int cellY)
        {
            int searchX_Cells = cellX + 2;
            int searchY_Cells = cellY + 2;

            for (int x = cellX - 1; x < searchX_Cells; x++)
            {
                for (int y = cellY - 1; y < searchY_Cells; y++)
                {
                    if ((x >= 0 && x <= gridXSize - 1) && (y >= 0 && y <= gridYSize - 1))
                    {
                        if (!(x == cellX && y == cellY))
                        {
                            if (grid[x, y] == (int)GridState.UNCLICKED && CountSurroundingMines(x, y) > 0)
                                grid[x, y] = (int)GridState.CLICKED;

                            else if (grid[x, y] == (int)GridState.UNCLICKED && CountSurroundingMines(x, y) == 0)
                            {
                                grid[x, y] = (int)GridState.CLICKED;
                                EnableNeighbors(x, y);
                            }
                        }
                    }
                }
            }
        }
        private void EnableAllMines()
        {
            for (int x = 0; x < gridXSize; x++)
            {
                for (int y = 0; y < gridYSize; y++)
                {
                    if (grid[x, y] == (int)GridState.MINED || grid[x, y] == (int)GridState.FLAGGED)
                        grid[x, y] = (int)GridState.EXPLODED;
                }
            }
        }
        private void EnableWrongs(int cellX, int cellY)
        {
            int searchX_Cells = cellX + 2;
            int searchY_Cells = cellY + 2;

            for (int x = cellX - 1; x < searchX_Cells; x++)
            {
                for (int y = cellY - 1; y < searchY_Cells; y++)
                {
                    if ((x >= 0 && x <= gridXSize - 1) && (y >= 0 && y <= gridYSize - 1))
                    {
                        if (!(x == cellX && y == cellY))
                        {
                            if (grid[x, y] == (int)GridState.SUSPECTED)
                                grid[x, y] = (int)GridState.WRONG_GUESS;
                        }
                    }
                }
            }
        }
        private int CountSurroundingMines(int cellX, int cellY)
        {
            int searchX_Cells = cellX + 2;
            int searchY_Cells = cellY + 2;
            int mineCount = 0;

            for (int x = cellX - 1; x < searchX_Cells; x++)
            {
                for (int y = cellY - 1; y < searchY_Cells; y++)
                {
                    if ((x >= 0 && x <= gridXSize - 1) && (y >= 0 && y <= gridYSize - 1))
                    {
                        if (!(x == cellX && y == cellY))
                        {
                            if (grid[x, y] == (int)GridState.MINED || grid[x, y] == (int)GridState.FLAGGED || grid[x, y] == (int)GridState.EXPLODED)
                            {
                                ++mineCount;
                            }
                        }
                    }
                }
            }
            return mineCount;
        }
        private int CountFlags()
        {
            int flags = 0;

            for (int x = 0; x < gridXSize; x++)
            {
                for (int y = 0; y < gridYSize; y++)
                {
                    if (grid[x, y] == (int)GridState.FLAGGED || grid[x, y] == (int)GridState.SUSPECTED)
                        ++flags;
                }
            }
            return flags;
        }
        private int MinesMissed(int cellX, int cellY)
        {
            int searchX_Cells = cellX + 2;
            int searchY_Cells = cellY + 2;
            int mines = 0;
            int suspects = 0;

            for (int x = cellX - 1; x < searchX_Cells; x++)
            {
                for (int y = cellY - 1; y < searchY_Cells; y++)
                {
                    if ((x >= 0 && x <= gridXSize - 1) && (y >= 0 && y <= gridYSize - 1))
                    {
                        if (!(x == cellX && y == cellY))
                        {
                            if (grid[x, y] == (int)GridState.MINED)
                            {
                                ++mines;
                            }
                            else if (grid[x, y] == (int)GridState.SUSPECTED)
                            {
                                ++suspects;
                            }
                        }
                    }
                }
            }

            if (mines == 0)
            {
                if (mines == suspects)
                    return 0;
                else
                    return -1;
            }
            else
            {
                if (mines == suspects)
                    return 1;
                else
                    return -1;
            }
        }
        private bool CheckForWin()
        {
            bool won = true;

            for (int x = 0; x < gridXSize; x++)
            {
                for (int y = 0; y < gridYSize; y++)
                {
                    if (grid[x, y] == (int)GridState.UNCLICKED)
                    
                        won = false;
                    
                }
            }

            return won;
        }
        private void Win()
        {
            for (int x = 0; x < gridXSize; x++)
            {
                for (int y = 0; y < gridYSize; y++)
                {
                    grid[x, y] = (int)GridState.WRONG_GUESS;
                }
            }
        }
        private void ResetEverything()
        {
            ResetAllToUnclicked();
            PlaceMines();
            textBoxFlags.Text = numberOfMines.ToString();
            gameState = (int)GameState.WAITING;
            time = 0;
        }
        private void ResetAllToUnclicked()
        {
            for (int x = 0; x < gridXSize; x++)
            {
                for (int y = 0; y < gridYSize; y++)
                {
                    grid[x, y] = (int)GridState.UNCLICKED;
                }
            }
        }

        private void buttonSmiley_Click(object sender, EventArgs e)
        {
            ResetEverything();
            graphicsPanel1.Invalidate();
        }

        private void difficultyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form2 diffSets = new Form2();

            diffSets.SetCustomDifficulty(customDifficulty[0], customDifficulty[1], customDifficulty[2]);
            
            if (diffSets.ShowDialog() == DialogResult.OK)
            {
                int difficulty = diffSets.GetDifficultyLevel();

                switch (difficulty)
                {
                    case 0:
                        gridYSize = diffSets.GetBeginnerDimensions()[0];
                        gridXSize = diffSets.GetBeginnerDimensions()[1];
                        numberOfMines = diffSets.GetBeginnerDimensions()[2];
                        break;
                    case 1:
                        gridYSize = diffSets.GetIntermediateDimensions()[0];
                        gridXSize = diffSets.GetIntermediateDimensions()[1];
                        numberOfMines = diffSets.GetIntermediateDimensions()[2];
                        break;
                    case 2:
                        gridYSize = diffSets.GetExpertDimensions()[0];
                        gridXSize = diffSets.GetExpertDimensions()[1];
                        numberOfMines = diffSets.GetExpertDimensions()[2];
                        break;
                    default:
                        gridYSize = diffSets.GetCustomDimensions()[0];
                        gridXSize = diffSets.GetCustomDimensions()[1];
                        numberOfMines = diffSets.GetCustomDimensions()[2];
                        break;
                }

                grid = new int[gridXSize, gridYSize];
                gameState = (int)GameState.WAITING;
                numberOfGridSpaces = gridXSize * gridYSize;
                minePositions = new int[numberOfMines];
                ResetEverything();
                graphicsPanel1.Invalidate();
            }
        }
    }
}
