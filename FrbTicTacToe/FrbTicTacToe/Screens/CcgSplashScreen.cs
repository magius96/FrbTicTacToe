using System;
using FlatRedBall;
using FlatRedBall.Content.Scene;
using FlatRedBall.Input;
using Microsoft.Xna.Framework;
#if FRB_XNA || SILVERLIGHT
using Keys = Microsoft.Xna.Framework.Input.Keys;
#endif

namespace FrbTicTacToe.Screens
{
	public partial class CcgSplashScreen
	{
        enum LogicState
        {
            Uninitialized,
            FadingIn,
            Showing,
            FadingOut
        }

        double _mLastStateChange = 0;
        LogicState _mCurrentLogicState = LogicState.Uninitialized;
        Color _mOldBackgroundColor;
        CameraSave _mOldCameraSetup;
        TimeSpan _mOldTimeSpan;
	    private bool _exitCalled = false;

        public void CustomInitialize()
        {
            _mOldCameraSetup = CameraSave.FromCamera(SpriteManager.Camera);
            _mOldBackgroundColor = SpriteManager.Camera.BackgroundColor;
            SpriteManager.Camera.UsePixelCoordinates();
            SpriteManager.Camera.BackgroundColor = Color.Black;
            CurrentState = VariableState.Transparent;

            _mOldTimeSpan = FlatRedBallServices.Game.TargetElapsedTime;
            // Go to 10 fps to make loading go faster
            FlatRedBallServices.Game.TargetElapsedTime = new TimeSpan(0, 0, 0, 0, 100);
            CCGLabel.Visible = false;
            CreatedByLabel.Visible = false;
        }

        public void CustomActivity(bool firstTimeCalled)
        {
            if (firstTimeCalled)
            {
                StartAsyncLoad(NextScreen);
            }

            LogicStateActivity();

            if (InputManager.Keyboard.KeyTyped(Keys.Escape))
            {
                InputManager.Keyboard.IgnoreKeyForOneFrame(Keys.Escape);
                _exitCalled = true;
            }

            if (_exitCalled && AsyncLoadingState == FlatRedBall.Screens.AsyncLoadingState.Done) IsActivityFinished = true;
        }

        public void CustomDestroy()
        {

            FlatRedBallServices.Game.TargetElapsedTime = _mOldTimeSpan;
            _mOldCameraSetup.SetCamera(SpriteManager.Camera);
            SpriteManager.Camera.BackgroundColor = _mOldBackgroundColor;
        }

        private static void CustomLoadStaticContent(string contentManagerName)
        {


        }

        private void LogicStateActivity()
        {
            const double fadeTime = 0.5;
            const double showTime = 1.8;

            /////////////////////EARLY OUT////////////////////////
            // This guaranteees a few frames have passed before we start logic
            if (this.ActivityCallCount < 3)
            {
                return;
            }
            ///////////////////END EARLY OUT/////////////////////

            switch (_mCurrentLogicState)
            {
                case LogicState.Uninitialized:
                    CCGLabel.Visible = false;
                    CreatedByLabel.Visible = false;
                    InterpolateToState(VariableState.Opaque, fadeTime);
                    _mCurrentLogicState = LogicState.FadingIn;
                    break;
                case LogicState.FadingIn:
                    CCGLabel.Visible = false;
                    CreatedByLabel.Visible = false;
                    if (CurrentState == VariableState.Opaque)
                    {
                        _mCurrentLogicState = LogicState.Showing;
                        _mLastStateChange = TimeManager.CurrentTime;
                    }
                    break;
                case LogicState.Showing:
                    CCGLabel.Visible = true;
                    CreatedByLabel.Visible = true;
                    if (TimeManager.SecondsSince(_mLastStateChange) > showTime)
                    {
                        InterpolateToState(VariableState.Transparent, fadeTime);
                        _mCurrentLogicState = LogicState.FadingOut;
                    }
                    break;
                case LogicState.FadingOut:
                    CCGLabel.Visible = false;
                    CreatedByLabel.Visible = false;
                    if (CurrentState == VariableState.Transparent && AsyncLoadingState == FlatRedBall.Screens.AsyncLoadingState.Done)
                    {
                        IsActivityFinished = true;
                        // NextScreen should be set through the Glue UI
                    }
                    break;
            }
        }
    }
}
