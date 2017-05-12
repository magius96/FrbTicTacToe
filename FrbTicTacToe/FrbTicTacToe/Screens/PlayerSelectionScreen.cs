using FlatRedBall.Input;
using FrbTicTacToe.Entities;
using Microsoft.Xna.Framework.Media;
#if FRB_XNA || SILVERLIGHT
using Keys = Microsoft.Xna.Framework.Input.Keys;
#endif

namespace FrbTicTacToe.Screens
{
	public partial class PlayerSelectionScreen
	{
		void CustomInitialize()
		{
            Player1ComputerIcon.Click += Player1ComputerIconClick;
            Player1HumanIcon.Click += Player1HumanIconClick;
            Player2ComputerIcon.Click += Player2ComputerIconClick;
            Player2HumanIcon.Click += Player2HumanIconClick;
            BackButton.Click += BackButtonClick;
		    PlayButton.Click += PlayButtonClick;
            
            // Set player 1 type visual based upon global value
            if(Globals.PlayerXType == PlayerType.Human)
            {
                Player1HumanIcon.CurrentIconStateState = Icon.IconState.Selected;
                Player1ComputerIcon.CurrentIconStateState = Icon.IconState.NotSelected;
                Player1AiSelector.Visible = false;
            }
            else
            {
                Player1HumanIcon.CurrentIconStateState = Icon.IconState.NotSelected;
                Player1ComputerIcon.CurrentIconStateState = Icon.IconState.Selected;
                Player1AiSelector.Visible = true;
                switch (Globals.PlayerXAiLevel)
                {
                    case AiLevel.Easy:
                        Player1AiSelector.CurrentState = AiSelector.VariableState.Easy;
                        break;
                    case AiLevel.Hard:
                        Player1AiSelector.CurrentState = AiSelector.VariableState.Hard;
                        break;
                    case AiLevel.NormalDefensive:
                        Player1AiSelector.CurrentState = AiSelector.VariableState.NormalDefensive;
                        break;
                    case AiLevel.NormalOffensive:
                        Player1AiSelector.CurrentState = AiSelector.VariableState.NormalOffensive;
                        break;
                }
            }

            // Set player 2 type visual based upon global value
            if(Globals.PlayerOType == PlayerType.Human)
            {
                Player2HumanIcon.CurrentIconStateState = Icon.IconState.Selected;
                Player2ComputerIcon.CurrentIconStateState = Icon.IconState.NotSelected;
                Player2AiSelector.Visible = false;
            }
            else
            {
                Player2HumanIcon.CurrentIconStateState = Icon.IconState.NotSelected;
                Player2ComputerIcon.CurrentIconStateState = Icon.IconState.Selected;
                Player2AiSelector.Visible = true;
                switch (Globals.PlayerOAiLevel)
                {
                    case AiLevel.Easy:
                        Player2AiSelector.CurrentState = AiSelector.VariableState.Easy;
                        break;
                    case AiLevel.Hard:
                        Player2AiSelector.CurrentState = AiSelector.VariableState.Hard;
                        break;
                    case AiLevel.NormalDefensive:
                        Player2AiSelector.CurrentState = AiSelector.VariableState.NormalDefensive;
                        break;
                    case AiLevel.NormalOffensive:
                        Player2AiSelector.CurrentState = AiSelector.VariableState.NormalOffensive;
                        break;
                }
            }

		    Globals.PlayerXWins = 0;
		    Globals.PlayerOWins = 0;
		}

		void CustomActivity(bool firstTimeCalled)
		{
            if (MediaPlayer.State == MediaState.Stopped)
                FlatRedBall.Audio.AudioManager.PlaySong(GlobalContent.MenuMusic, true, true);

            if (FlatRedBall.Audio.AudioManager.CurrentlyPlayingSong != GlobalContent.MenuMusic)
                FlatRedBall.Audio.AudioManager.StopSong();
            
            if (InputManager.Keyboard.KeyTyped(Keys.Escape))
		    {
		        GlobalContent.ClickWave.Play();
		        InputManager.Keyboard.IgnoreKeyForOneFrame(Keys.Escape);
		        MoveToScreen(typeof (Screens.TitleMenu));
		    }

            if(InputManager.Keyboard.KeyTyped(Keys.Enter))
            {
                GlobalContent.ClickWave.Play();
                InputManager.Keyboard.IgnoreKeyForOneFrame(Keys.Enter);
                MoveToScreen(typeof (Screens.GameScreen));
            }
		}

		void CustomDestroy() { }

        static void CustomLoadStaticContent(string contentManagerName) { }

        void Player1HumanIconClick(FlatRedBall.Gui.IWindow window)
        {
            GlobalContent.PopWave.Play();
            Player1HumanIcon.CurrentIconStateState = Icon.IconState.Selected;
            Player1ComputerIcon.CurrentIconStateState = Icon.IconState.NotSelected;
            Globals.PlayerXType = PlayerType.Human;
            Player1AiSelector.Visible = false;
        }

        void Player1ComputerIconClick(FlatRedBall.Gui.IWindow window)
        {
            GlobalContent.PopWave.Play();
            Player1HumanIcon.CurrentIconStateState = Icon.IconState.NotSelected;
            Player1ComputerIcon.CurrentIconStateState = Icon.IconState.Selected;
            Globals.PlayerXType = PlayerType.Computer;
            Player1AiSelector.Visible = true;
        }

        void Player2HumanIconClick(FlatRedBall.Gui.IWindow window)
        {
            GlobalContent.PopWave.Play();
            Player2HumanIcon.CurrentIconStateState = Icon.IconState.Selected;
            Player2ComputerIcon.CurrentIconStateState = Icon.IconState.NotSelected;
            Globals.PlayerOType = PlayerType.Human;
            Player2AiSelector.Visible = false;
        }

        void Player2ComputerIconClick(FlatRedBall.Gui.IWindow window)
        {
            GlobalContent.PopWave.Play();
            Player2HumanIcon.CurrentIconStateState = Icon.IconState.NotSelected;
            Player2ComputerIcon.CurrentIconStateState = Icon.IconState.Selected;
            Globals.PlayerOType = PlayerType.Computer;
            Player2AiSelector.Visible = true;
        }

        void BackButtonClick(FlatRedBall.Gui.IWindow window)
        {
            GlobalContent.ClickWave.Play();
            MoveToScreen(typeof(Screens.TitleMenu));
        }

        void PlayButtonClick(FlatRedBall.Gui.IWindow window)
        {
            GlobalContent.ClickWave.Play();

            if(Globals.PlayerXType == PlayerType.Computer)
            {
                switch (Player1AiSelector.CurrentState)
                {
                    case AiSelector.VariableState.Easy: 
                        Globals.PlayerXAiLevel = AiLevel.Easy;
                        break;
                    case AiSelector.VariableState.Hard:
                        Globals.PlayerXAiLevel = AiLevel.Hard;
                        break;
                    case AiSelector.VariableState.NormalDefensive:
                        Globals.PlayerXAiLevel = AiLevel.NormalDefensive;
                        break;
                    case AiSelector.VariableState.NormalOffensive:
                        Globals.PlayerXAiLevel = AiLevel.NormalOffensive;
                        break;
                }
            }
            if(Globals.PlayerOType == PlayerType.Computer)
            {
                switch (Player2AiSelector.CurrentState)
                {
                    case AiSelector.VariableState.Easy:
                        Globals.PlayerOAiLevel = AiLevel.Easy;
                        break;
                    case AiSelector.VariableState.Hard:
                        Globals.PlayerOAiLevel = AiLevel.Hard;
                        break;
                    case AiSelector.VariableState.NormalDefensive:
                        Globals.PlayerOAiLevel = AiLevel.NormalDefensive;
                        break;
                    case AiSelector.VariableState.NormalOffensive:
                        Globals.PlayerOAiLevel = AiLevel.NormalOffensive;
                        break;
                }
            }
            MoveToScreen(typeof(Screens.GameScreen));
        }
	}
}
