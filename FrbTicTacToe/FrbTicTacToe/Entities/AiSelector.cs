namespace FrbTicTacToe.Entities
{
	public partial class AiSelector
	{
		private void CustomInitialize()
		{
            EasySelection.Click += EasySelectionClick;
            NormalDefensiveSelection.Click += NormalDefensiveSelectionClick;
            NormalOffensiveSelection.Click += NormalOffensiveSelectionClick;
            HardSelection.Click += HardSelectionClick;
		}

        void HardSelectionClick(FlatRedBall.Gui.IWindow window)
        {
            CurrentState = VariableState.Hard;
        }

        void NormalOffensiveSelectionClick(FlatRedBall.Gui.IWindow window)
        {
            CurrentState = VariableState.NormalOffensive;
        }

        void NormalDefensiveSelectionClick(FlatRedBall.Gui.IWindow window)
        {
            CurrentState = VariableState.NormalDefensive;
        }

        void EasySelectionClick(FlatRedBall.Gui.IWindow window)
        {
            CurrentState = VariableState.Easy;
        }

		private void CustomActivity()
		{


		}

		private void CustomDestroy()
		{


		}

        private static void CustomLoadStaticContent(string contentManagerName)
        {


        }
	}
}
