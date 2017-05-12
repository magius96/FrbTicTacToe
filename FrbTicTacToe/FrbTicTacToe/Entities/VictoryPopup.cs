namespace FrbTicTacToe.Entities
{
    public delegate void ButtonClickHandler();

	public partial class VictoryPopup
	{
	    public event ButtonClickHandler YesClicked;
	    public event ButtonClickHandler NoClicked;

		private void CustomInitialize()
		{
            YesButton.Click += YesButtonClick;
            NoButton.Click += NoButtonClick;
		}

        void NoButtonClick(FlatRedBall.Gui.IWindow window)
        {
            GlobalContent.ClickWave.Play();
            if (NoClicked != null) NoClicked();
        }

        void YesButtonClick(FlatRedBall.Gui.IWindow window)
        {
            GlobalContent.ClickWave.Play();
            if (YesClicked != null) YesClicked();
        }

		private void CustomActivity() { }

		private void CustomDestroy() { }

        private static void CustomLoadStaticContent(string contentManagerName) { }
	}
}
