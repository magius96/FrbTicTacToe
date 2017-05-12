using FlatRedBall;
using FlatRedBall.Input;
using Microsoft.Xna.Framework.Media;
#if FRB_XNA || SILVERLIGHT
using Keys = Microsoft.Xna.Framework.Input.Keys;
#endif

namespace FrbTicTacToe.Screens
{
	public partial class TitleMenu
	{
        void CustomInitialize()
        {
            MenuItemPlay.Click += MenuItemPlayClick;
            MenuItemExit.Click += MenuItemExitClick;
            MenuItemAbout.Click += MenuItemAboutClick;
        }

		void CustomActivity(bool firstTimeCalled)
		{
            if (MediaPlayer.State == MediaState.Stopped)
                FlatRedBall.Audio.AudioManager.PlaySong(GlobalContent.MenuMusic, true, true);

            if(FlatRedBall.Audio.AudioManager.CurrentlyPlayingSong != GlobalContent.MenuMusic)
                FlatRedBall.Audio.AudioManager.StopSong();

            if (InputManager.Keyboard.KeyTyped(Keys.Enter))
            {
                GlobalContent.ClickWave.Play();
                InputManager.Keyboard.IgnoreKeyForOneFrame(Keys.Enter);
                MoveToScreen(typeof(Screens.PlayerSelectionScreen));
            }

            if(InputManager.Keyboard.KeyTyped(Keys.Escape))
            {
                GlobalContent.ClickWave.Play();
                InputManager.Keyboard.IgnoreKeyForOneFrame(Keys.Escape);
                FlatRedBallServices.Game.Exit();
            }
		}

		void CustomDestroy() { }

        static void CustomLoadStaticContent(string contentManagerName) { }

        void MenuItemPlayClick(FlatRedBall.Gui.IWindow window)
        {
            GlobalContent.ClickWave.Play();
            MoveToScreen(typeof(Screens.PlayerSelectionScreen));
        }

        void MenuItemExitClick(FlatRedBall.Gui.IWindow window)
        {
            GlobalContent.ClickWave.Play();
            FlatRedBall.Audio.AudioManager.StopSong();
            FlatRedBallServices.Game.Exit();
        }

        void MenuItemAboutClick(FlatRedBall.Gui.IWindow window)
        {
            GlobalContent.ClickWave.Play();
            MoveToScreen(typeof (Screens.AboutScreen));
        }
	}
}
