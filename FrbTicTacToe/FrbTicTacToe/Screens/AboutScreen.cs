using Microsoft.Xna.Framework.Media;

namespace FrbTicTacToe.Screens
{
	public partial class AboutScreen
	{
		void CustomInitialize()
		{
            BackButton.Click += new FlatRedBall.Gui.WindowEvent(BackButton_Click);
		}

        void BackButton_Click(FlatRedBall.Gui.IWindow window)
        {
            GlobalContent.ClickWave.Play();
            MoveToScreen(typeof (Screens.TitleMenu));
        }

		void CustomActivity(bool firstTimeCalled)
		{
            if (Microsoft.Xna.Framework.Media.MediaPlayer.State == MediaState.Stopped)
                FlatRedBall.Audio.AudioManager.PlaySong(GlobalContent.MenuMusic, true, true);

            if (FlatRedBall.Audio.AudioManager.CurrentlyPlayingSong != GlobalContent.MenuMusic)
                FlatRedBall.Audio.AudioManager.StopSong();
        }

		void CustomDestroy() { }

        static void CustomLoadStaticContent(string contentManagerName) { }
	}
}
