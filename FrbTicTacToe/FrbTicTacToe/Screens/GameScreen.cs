using System;
using System.Collections.Generic;
using System.Linq;
using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using FrbTicTacToe.Entities;
using FrbTicTacToe.Unmanaged_Code;
using Microsoft.Xna.Framework.Media;
using GuiManager = FlatRedBall.Gui.GuiManager;
#if FRB_XNA || SILVERLIGHT
using Keys = Microsoft.Xna.Framework.Input.Keys;
#endif

namespace FrbTicTacToe.Screens
{
	public partial class GameScreen
	{
        public List<TicTacToeLine> TicTacToeLines = new List<TicTacToeLine>
        {
            // Verticles
            new TicTacToeLine(new GridSpace(0, 0), new GridSpace(0, 1), new GridSpace(0, 2)),
            new TicTacToeLine(new GridSpace(1, 0), new GridSpace(1, 1), new GridSpace(1, 2)),
            new TicTacToeLine(new GridSpace(2, 0), new GridSpace(2, 1), new GridSpace(2, 2)),
            // Horizontals
            new TicTacToeLine(new GridSpace(0, 0), new GridSpace(1, 0), new GridSpace(2, 0)),
            new TicTacToeLine(new GridSpace(0, 1), new GridSpace(1, 1), new GridSpace(2, 1)),
            new TicTacToeLine(new GridSpace(0, 2), new GridSpace(1, 2), new GridSpace(2, 2)),
            // Diagonals
            new TicTacToeLine(new GridSpace(0, 0), new GridSpace(1, 1), new GridSpace(2, 2)),
            new TicTacToeLine(new GridSpace(0, 2), new GridSpace(1, 1), new GridSpace(2, 0))
        };

	    readonly BoardTile[,] _tiles = new BoardTile[3,3];
	    private bool _aiCallPlaced = false;
         
		void CustomInitialize()
		{
            // Initialize the grid array
		    _tiles[0, 0] = BoardTile11;
		    _tiles[0, 1] = BoardTile12;
		    _tiles[0, 2] = BoardTile13;

		    _tiles[1, 0] = BoardTile21;
		    _tiles[1, 1] = BoardTile22;
		    _tiles[1, 2] = BoardTile23;

		    _tiles[2, 0] = BoardTile31;
		    _tiles[2, 1] = BoardTile32;
		    _tiles[2, 2] = BoardTile33;

            for (var i = 0; i < 3;i++)
            {
                for(var j=0;j<3;j++)
                {
                    _tiles[i,j].CurrentState = BoardTile.VariableState.None;
                    _tiles[i, j].Click += TileClick;
                }
            }
            // offset the camera
            Camera.Main.X = Camera.Main.OrthogonalWidth / 2.0f;
		    Camera.Main.Y = Camera.Main.OrthogonalHeight/2.0f;

		    Player1WinCount.Text = string.Format("{0} Wins", Globals.PlayerXWins);
		    Player2WinCount.Text = string.Format("{0} Wins", Globals.PlayerOWins);

            Player1TypeLabel.CurrentPlayerTypeState = Globals.PlayerXType == PlayerType.Human 
                ? Icon.PlayerType.Human 
                : Icon.PlayerType.Computer;
		    Player1TypeLabel.Size = 30;

            Player2TypeLabel.CurrentPlayerTypeState = Globals.PlayerOType == PlayerType.Human 
                ? Icon.PlayerType.Human 
                : Icon.PlayerType.Computer;
		    Player2TypeLabel.Size = 30;

            VictoryPopupWindow.YesClicked += VictoryPopupWindowYesButtonClick;
            VictoryPopupWindow.NoClicked += VictoryPopupWindowNoButtonClick;
		    VictoryPopupWindow.Visible = false;

		    PlayerXAiLevelText.Visible = Globals.PlayerXType == PlayerType.Computer;
		    switch (Globals.PlayerXAiLevel)
		    {
		        case AiLevel.Easy:
		            PlayerXAiLevelText.Text = "Easy";
                    break;
                case AiLevel.Hard:
                    PlayerXAiLevelText.Text = "Hard";
                    break;
                case AiLevel.NormalDefensive:
                    PlayerXAiLevelText.Text = "Defensive";
                    break;
                case AiLevel.NormalOffensive:
                    PlayerXAiLevelText.Text = "Offensive";
                    break;
            }
		    PlayerOAiLevelText.Visible = Globals.PlayerOType == PlayerType.Computer;
            switch (Globals.PlayerOAiLevel)
            {
                case AiLevel.Easy:
                    PlayerOAiLevelText.Text = "Easy";
                    break;
                case AiLevel.Hard:
                    PlayerOAiLevelText.Text = "Hard";
                    break;
                case AiLevel.NormalDefensive:
                    PlayerOAiLevelText.Text = "Defensive";
                    break;
                case AiLevel.NormalOffensive:
                    PlayerOAiLevelText.Text = "Offensive";
                    break;
            }
        }

		void CustomActivity(bool firstTimeCalled)
		{
            if(FlatRedBall.Audio.AudioManager.CurrentlyPlayingSong == GlobalContent.MenuMusic)
                FlatRedBall.Audio.AudioManager.StopSong();

            if (Microsoft.Xna.Framework.Media.MediaPlayer.State == MediaState.Stopped)
                StartMusic();

		    var currentPlayer = CurrentPlayerIndicatorState;
		    GuiManager.SortZAndLayerBased();
            if(firstTimeCalled)
            {
                CurrentPlayerIndicatorState = FlatRedBallServices.Random.Next(100) > 50 
                    ? PlayerIndicator.PlayerXMove 
                    : PlayerIndicator.PlayerOMove;
            }

		    Player1WinCount.Text = string.Format("Wins {0}", Globals.PlayerXWins);
		    Player2WinCount.Text = string.Format("{0} Wins", Globals.PlayerOWins);
            // Don't want to do the rest if the pop up is visible
		    if (VictoryPopupWindow.Visible)
		    {
		        if(_aiCallPlaced)
		        {
		            this.Instructions.Clear();
		            _aiCallPlaced = false;
		        }
                return;
		    }

            CurrentPlayerIndicator.CurrentState = CurrentPlayerIndicatorState == PlayerIndicator.PlayerXMove 
                ? BoardTile.VariableState.X 
                : BoardTile.VariableState.O;

		    if(InputManager.Keyboard.KeyTyped(Keys.Escape))
		    {
		        InputManager.Keyboard.IgnoreKeyForOneFrame(Keys.Escape);
		        MoveToScreen(typeof (Screens.TitleMenu));
		    }

		    CheckForWins();

		    if(_aiCallPlaced) return;

            if ((currentPlayer == PlayerIndicator.PlayerXMove && Globals.PlayerXType == PlayerType.Computer)
               || (currentPlayer == PlayerIndicator.PlayerOMove && Globals.PlayerOType == PlayerType.Computer))
		    {
		        _aiCallPlaced = true;
		        var pause = Math.Min(Math.Max(1, FlatRedBallServices.Random.NextDouble() * 2), 2);
		        this.Call(DoComputerMove).After(pause);
		    }

		}

		void CustomDestroy() { }

        static void CustomLoadStaticContent(string contentManagerName) { }

        #region Events
        void VictoryPopupWindowNoButtonClick()
        {
            GlobalContent.ClickWave.Play();
            MoveToScreen(typeof(Screens.TitleMenu));
        }

        void VictoryPopupWindowYesButtonClick()
        {
            GlobalContent.ClickWave.Play();
            VictoryPopupWindow.Visible = false;
            ResetBoard();
        }

        void TileClick(FlatRedBall.Gui.IWindow window)
        {
            if(VictoryPopupWindow.Visible) return;
            // If the current player is a computer, get out
            if(CurrentPlayerIndicatorState == PlayerIndicator.PlayerXMove && Globals.PlayerXType == PlayerType.Computer) return;
            if(CurrentPlayerIndicatorState == PlayerIndicator.PlayerOMove && Globals.PlayerOType == PlayerType.Computer) return;

            // if the tile is already set, get out
            var tile = (BoardTile) window;
            if(tile.CurrentState != BoardTile.VariableState.None) return;

            switch (CurrentPlayerIndicatorState)
            {
                case PlayerIndicator.PlayerOMove:
                    GlobalContent.ScrapeWave.Play();
                    tile.CurrentState = BoardTile.VariableState.O;
                    CurrentPlayerIndicatorState = PlayerIndicator.PlayerXMove;
                    break;
                case PlayerIndicator.PlayerXMove:
                    GlobalContent.ScrapeWave.Play();
                    tile.CurrentState = BoardTile.VariableState.X;
                    CurrentPlayerIndicatorState = PlayerIndicator.PlayerOMove;
                    break;
            }
        }
        #endregion

        #region Utils
        private int SpacesLeft()
        {
            var ct = 0;
            for(var i=0;i<3;i++)
            {
                for(var j=0;j<3;j++)
                {
                    if (_tiles[i, j].CurrentState == BoardTile.VariableState.None) ct++;
                }
            }
            return ct;
        }

        private List<GridSpace> GetAvailableSpaces()
        {
            var toReturn = new List<GridSpace>();
            for(var i=0;i<3;i++)
            {
                for(var j=0;j<3;j++)
                {
                    if(_tiles[i,j].CurrentState == BoardTile.VariableState.None) toReturn.Add(new GridSpace(i,j));
                }
            }
            return toReturn;
        } 

        private void CheckForWins()
        {
            BoardTile.VariableState winner = BoardTile.VariableState.None;

            foreach (var ticTacToeLine in TicTacToeLines)
            {
                if (IsVictoryLine(ticTacToeLine)) winner = _tiles[ticTacToeLine.Cells[0].X, ticTacToeLine.Cells[0].Y].CurrentState;
            }

            if(winner != BoardTile.VariableState.None)
            {
                if(Globals.PlayerXType == PlayerType.Computer && Globals.PlayerOType == PlayerType.Computer)
                {
                    CurrentPlayerIndicatorState = PlayerIndicator.Unknown;
                    if (winner == BoardTile.VariableState.X)
                        Globals.PlayerXWins++;
                    else
                        Globals.PlayerOWins++;
                    ResetBoard();
                }
                else
                {
                    VictoryPopupWindow.Winner = string.Format("Player {0} Wins!", winner == BoardTile.VariableState.X ? "X" : "O");
                    VictoryPopupWindow.Visible = true;
                    GlobalContent.TaDa.Play();
                    CurrentPlayerIndicatorState = PlayerIndicator.Unknown;
                    if (winner == BoardTile.VariableState.X)
                        Globals.PlayerXWins++;
                    else
                        Globals.PlayerOWins++;
                    return;
                }
            }
            if(SpacesLeft() == 0)
            {
                if(Globals.PlayerXType == PlayerType.Computer && Globals.PlayerOType == PlayerType.Computer)
                {
                    CurrentPlayerIndicatorState = PlayerIndicator.Unknown;
                    ResetBoard();
                }
                else
                {
                    VictoryPopupWindow.Winner = "It was a tie!";
                    VictoryPopupWindow.Visible = true;
                    GlobalContent.Sad.Play();
                    CurrentPlayerIndicatorState = PlayerIndicator.Unknown;
                }
            }
        }

        private bool IsVictoryLine(TicTacToeLine line)
        {
            if (line.Cells.Any(cell => _tiles[cell.X, cell.Y].CurrentState == BoardTile.VariableState.None)) {
                return false;
            }

            return _tiles[line.Cells[0].X, line.Cells[0].Y].CurrentState == _tiles[line.Cells[1].X, line.Cells[1].Y].CurrentState
                   && _tiles[line.Cells[1].X, line.Cells[1].Y].CurrentState == _tiles[line.Cells[2].X, line.Cells[2].Y].CurrentState;
        }

        private void ResetBoard()
        {
            // Reset the tiles
            for(var i=0;i<3;i++)
            {
                for(var j=0;j<3;j++)
                {
                    _tiles[i,j].CurrentState = BoardTile.VariableState.None;

                }
            }
            // Set who goes first
            CurrentPlayerIndicatorState = FlatRedBallServices.Random.Next(100) > 50 
                ? PlayerIndicator.PlayerXMove 
                : PlayerIndicator.PlayerOMove;

            // Change the background
            BackgroundImage.ChangeBackground();
        }

	    private int _lastPlayed = -1;
        private void StartMusic()
        {
            var lst = new List<int>();
            for(var i=1;i<6;i++)
            {
                if (i != _lastPlayed) lst.Add(i);
            }
            var index = FlatRedBallServices.Random.Next(lst.Count);
            var toPlay = lst[index];
            _lastPlayed = toPlay;

            switch (toPlay)
            {
                case 1:
                    FlatRedBall.Audio.AudioManager.PlaySong(GlobalContent.GameMusic1, true, true);
                    break;
                case 2:
                    FlatRedBall.Audio.AudioManager.PlaySong(GlobalContent.GameMusic2, true, true);
                    break;
                case 3:
                    FlatRedBall.Audio.AudioManager.PlaySong(GlobalContent.GameMusic3, true, true);
                    break;
                case 4:
                    FlatRedBall.Audio.AudioManager.PlaySong(GlobalContent.GameMusic4, true, true);
                    break;
                case 5:
                    FlatRedBall.Audio.AudioManager.PlaySong(GlobalContent.GameMusic5, true, true);
                    break;
                default:
                    _lastPlayed = 1;
                    FlatRedBall.Audio.AudioManager.PlaySong(GlobalContent.GameMusic1, true, true);
                    break;
            }
        }
        #endregion

        #region AI
        private int[,] _availableMoves = {{0, 0, 0}, {0, 0, 0}, {0, 0, 0}};

        private void PerformComputerMove(int x, int y)
        {
            var playingX = CurrentPlayerIndicatorState == PlayerIndicator.PlayerXMove;
            _tiles[x, y].CurrentState = playingX ? BoardTile.VariableState.X : BoardTile.VariableState.O;
            GlobalContent.ScrapeWave.Play();
            CurrentPlayerIndicatorState = CurrentPlayerIndicatorState == PlayerIndicator.PlayerOMove 
                ? PlayerIndicator.PlayerXMove 
                : PlayerIndicator.PlayerOMove;
            _aiCallPlaced = false;
        }

        private void DoComputerMove()
        {
            var playingX = CurrentPlayerIndicatorState == PlayerIndicator.PlayerXMove;
            var aiLevel = playingX ? Globals.PlayerXAiLevel : Globals.PlayerOAiLevel;

            switch (aiLevel)
            {
                case AiLevel.Easy:
                    DoEasyComputerMove();
                    break;
                case AiLevel.NormalOffensive:
                    DoNormalOffensiveComputerMove();
                    break;
                case AiLevel.NormalDefensive:
                    DoNormalDefensiveComputerMove();
                    break;
                case AiLevel.Hard:
                    DoHardComputerMove();
                    break;
                default:
                    DoEasyComputerMove();
                    break;
            }
        }

        private void DoEasyComputerMove()
        {
            var availableGrid = GetAvailableSpaces();
            if(availableGrid.Count == 0) return;
            var index = FlatRedBallServices.Random.Next(availableGrid.Count);

            PerformComputerMove(availableGrid[index].X, availableGrid[index].Y);
        }

        private void DoNormalOffensiveComputerMove()
        {
            _availableMoves = new int[,] {{0, 0, 0}, {0, 0, 0}, {0, 0, 0}};
            for(var i=0;i<3;i++)
            {
                for(var j=0;j<3;j++)
                {
                    if(_tiles[i,j].CurrentState == BoardTile.VariableState.None)
                    {
                        CalculateCompletions(i, j);
                        CalculatePairs(i, j);
                    }
                }
            }
            CalculateSingles();
            var available = GetHighestMoves();
            if(available.Count == 1)
            {
                PerformComputerMove(available[0].X, available[0].Y);
            }
            else
            {
                var index = FlatRedBallServices.Random.Next(available.Count);
                PerformComputerMove(available[index].X, available[index].Y);
            }
        }

        private void DoNormalDefensiveComputerMove()
        {
            _availableMoves = new int[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    if (_tiles[i, j].CurrentState == BoardTile.VariableState.None)
                    {
                        CalculateBlocks(i, j);
                        CalculatePairs(i, j);
                    }
                }
            }
            CalculateSingles();
            var available = GetHighestMoves();
            if (available.Count == 1)
            {
                PerformComputerMove(available[0].X, available[0].Y);
            }
            else
            {
                var index = FlatRedBallServices.Random.Next(available.Count);
                PerformComputerMove(available[index].X, available[index].Y);
            }
        }

        private void DoHardComputerMove()
        {
            _availableMoves = new int[,] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    // Don't want to do any calculations on cells that are already used
                    if (_tiles[i, j].CurrentState == BoardTile.VariableState.None)
                    {
                        CalculateCompletions(i, j);
                        CalculateBlocks(i, j);
                        CalculatePairs(i, j);
                    }
                }
            }
            CalculateSingles();
            var available = GetHighestMoves();
            if (available.Count == 1)
            {
                PerformComputerMove(available[0].X, available[0].Y);
            }
            else
            {
                var index = FlatRedBallServices.Random.Next(available.Count);
                PerformComputerMove(available[index].X, available[index].Y);
            }
        }

        private void CalculateBlocks(int x, int y)
        {
            var playingX = CurrentPlayerIndicatorState == PlayerIndicator.PlayerXMove;
            var searchingFor = playingX ? BoardTile.VariableState.O : BoardTile.VariableState.X;
            // Check all lines continaing this cell to see if the other two cells contain enemy moves
            foreach (var ticTacToeLine in TicTacToeLines)
            {
                var index = ticTacToeLine.FindCellIndex(x, y);
                switch (index)
                {
                    case 0:
                        if (_tiles[ticTacToeLine.Cells[1].X, ticTacToeLine.Cells[1].Y].CurrentState == searchingFor &&
                            _tiles[ticTacToeLine.Cells[2].X, ticTacToeLine.Cells[2].Y].CurrentState == searchingFor)
                            _availableMoves[x, y] += BlockingWeight;
                        break;
                    case 1:
                        if (_tiles[ticTacToeLine.Cells[0].X, ticTacToeLine.Cells[0].Y].CurrentState == searchingFor &&
                            _tiles[ticTacToeLine.Cells[2].X, ticTacToeLine.Cells[2].Y].CurrentState == searchingFor)
                            _availableMoves[x, y] += BlockingWeight;
                        break;
                    case 2:
                        if (_tiles[ticTacToeLine.Cells[0].X, ticTacToeLine.Cells[0].Y].CurrentState == searchingFor &&
                            _tiles[ticTacToeLine.Cells[1].X, ticTacToeLine.Cells[1].Y].CurrentState == searchingFor)
                            _availableMoves[x, y] += BlockingWeight;
                        break;
                    default: // We should get this if the index was -1
                        break;
                }
            }
        }

        private void CalculateCompletions(int x, int y)
        {
            var playingX = CurrentPlayerIndicatorState == PlayerIndicator.PlayerXMove;
            var searchingFor = playingX ? BoardTile.VariableState.X : BoardTile.VariableState.O;
            // Check all lines continaing this cell to see if the other two cells contain enemy moves
            foreach (var ticTacToeLine in TicTacToeLines)
            {
                var index = ticTacToeLine.FindCellIndex(x, y);
                switch (index)
                {
                    case 0:
                        if (_tiles[ticTacToeLine.Cells[1].X, ticTacToeLine.Cells[1].Y].CurrentState == searchingFor &&
                            _tiles[ticTacToeLine.Cells[2].X, ticTacToeLine.Cells[2].Y].CurrentState == searchingFor)
                            _availableMoves[x, y] += CompletionWeight;
                        break;
                    case 1:
                        if (_tiles[ticTacToeLine.Cells[0].X, ticTacToeLine.Cells[0].Y].CurrentState == searchingFor &&
                            _tiles[ticTacToeLine.Cells[2].X, ticTacToeLine.Cells[2].Y].CurrentState == searchingFor)
                            _availableMoves[x, y] += CompletionWeight;
                        break;
                    case 2:
                        if (_tiles[ticTacToeLine.Cells[0].X, ticTacToeLine.Cells[0].Y].CurrentState == searchingFor &&
                            _tiles[ticTacToeLine.Cells[1].X, ticTacToeLine.Cells[1].Y].CurrentState == searchingFor)
                            _availableMoves[x, y] += CompletionWeight;
                        break;
                }
            }
        }

        private void CalculatePairs(int x, int y)
        {
            var playingX = CurrentPlayerIndicatorState == PlayerIndicator.PlayerXMove;
            var searchingFor = playingX ? BoardTile.VariableState.X : BoardTile.VariableState.O;
            // Check all lines continaing this cell to see if the other two cells contain enemy moves
            foreach (var ticTacToeLine in TicTacToeLines)
            {
                var index = ticTacToeLine.FindCellIndex(x, y);
                switch (index)
                {
                    case 0:
                        if (_tiles[ticTacToeLine.Cells[1].X, ticTacToeLine.Cells[1].Y].CurrentState == searchingFor &&
                            _tiles[ticTacToeLine.Cells[2].X, ticTacToeLine.Cells[2].Y].CurrentState == BoardTile.VariableState.None)
                            _availableMoves[x, y] += PairWeight;
                            if (_tiles[ticTacToeLine.Cells[1].X, ticTacToeLine.Cells[1].Y].CurrentState == BoardTile.VariableState.None &&
                            _tiles[ticTacToeLine.Cells[2].X, ticTacToeLine.Cells[2].Y].CurrentState == searchingFor)
                            _availableMoves[x, y] += PairWeight;
                        break;
                    case 1:
                        if (_tiles[ticTacToeLine.Cells[0].X, ticTacToeLine.Cells[0].Y].CurrentState == searchingFor &&
                            _tiles[ticTacToeLine.Cells[2].X, ticTacToeLine.Cells[2].Y].CurrentState == BoardTile.VariableState.None)
                            _availableMoves[x, y] += PairWeight;
                        if (_tiles[ticTacToeLine.Cells[0].X, ticTacToeLine.Cells[0].Y].CurrentState == BoardTile.VariableState.None &&
                            _tiles[ticTacToeLine.Cells[2].X, ticTacToeLine.Cells[2].Y].CurrentState == searchingFor)
                            _availableMoves[x, y] += PairWeight;
                        break;
                    case 2:
                        if (_tiles[ticTacToeLine.Cells[0].X, ticTacToeLine.Cells[0].Y].CurrentState == searchingFor &&
                            _tiles[ticTacToeLine.Cells[1].X, ticTacToeLine.Cells[1].Y].CurrentState == BoardTile.VariableState.None)
                            _availableMoves[x, y] += PairWeight;
                        if (_tiles[ticTacToeLine.Cells[0].X, ticTacToeLine.Cells[0].Y].CurrentState == BoardTile.VariableState.None &&
                            _tiles[ticTacToeLine.Cells[1].X, ticTacToeLine.Cells[1].Y].CurrentState == searchingFor)
                            _availableMoves[x, y] += PairWeight;
                        break;
                }
            }
        }

        private void CalculateSingles()
        {
            // Adds one to every unoccupied cell.  This prevents the random selection code from selecting
            // a cell that's already used, since all those cells will be 0
            for(var i=0;i<3;i++)
            {
                for(var j=0;j<3;j++)
                {
                    if (_tiles[i, j].CurrentState == BoardTile.VariableState.None) _availableMoves[i, j] += SingleWeight;
                }
            }
        }

        private List<GridSpace> GetHighestMoves()
        {
            var topVal = 0;
            for(var i=0;i<3;i++)
            {
                for(var j=0;j<3;j++)
                {
                    if (_availableMoves[i, j] > topVal) topVal = _availableMoves[i, j];
                }
            }

            var toReturn = new List<GridSpace>();
            for(var i=0;i<3;i++)
            {
                for(var j=0;j<3;j++)
                {
                    if(_availableMoves[i,j] == topVal) toReturn.Add(new GridSpace(i, j));
                }
            }
            return toReturn;
        } 
        #endregion
    }
}
