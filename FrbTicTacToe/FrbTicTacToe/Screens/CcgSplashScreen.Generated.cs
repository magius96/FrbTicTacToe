#if ANDROID
#define REQUIRES_PRIMARY_THREAD_LOADING
#endif


using BitmapFont = FlatRedBall.Graphics.BitmapFont;

using Cursor = FlatRedBall.Gui.Cursor;
using GuiManager = FlatRedBall.Gui.GuiManager;

#if XNA4 || WINDOWS_8
using Color = Microsoft.Xna.Framework.Color;
#elif FRB_MDX
using Color = System.Drawing.Color;
#else
using Color = Microsoft.Xna.Framework.Graphics.Color;
#endif

#if FRB_XNA || SILVERLIGHT
using Keys = Microsoft.Xna.Framework.Input.Keys;
using Vector3 = Microsoft.Xna.Framework.Vector3;
using Texture2D = Microsoft.Xna.Framework.Graphics.Texture2D;
using Microsoft.Xna.Framework.Media;
#endif

// Generated Usings
using FrbTicTacToe.Entities;
using FlatRedBall;
using FlatRedBall.Screens;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace FrbTicTacToe.Screens
{
	public partial class CcgSplashScreen : Screen
	{
		// Generated Fields
		#if DEBUG
		static bool HasBeenLoadedWithGlobalContentManager = false;
		#endif
		public enum VariableState
		{
			Uninitialized = 0, //This exists so that the first set call actually does something
			Unknown = 1, //This exists so that if the entity is actually a child entity and has set a child state, you will get this
			Opaque = 2, 
			Transparent = 3
		}
		protected int mCurrentState = 0;
		public Screens.CcgSplashScreen.VariableState CurrentState
		{
			get
			{
				if (Enum.IsDefined(typeof(VariableState), mCurrentState))
				{
					return (VariableState)mCurrentState;
				}
				else
				{
					return VariableState.Unknown;
				}
			}
			set
			{
				mCurrentState = (int)value;
				switch(CurrentState)
				{
					case  VariableState.Uninitialized:
						break;
					case  VariableState.Unknown:
						break;
					case  VariableState.Opaque:
						CcgLogoAlpha = 1f;
						break;
					case  VariableState.Transparent:
						CcgLogoAlpha = 0f;
						break;
				}
			}
		}
		protected static Microsoft.Xna.Framework.Graphics.Texture2D CcgSplash;
		
		private FlatRedBall.Sprite CcgLogo;
		private FrbTicTacToe.Entities.Label CreatedByLabel;
		private FrbTicTacToe.Entities.Label CCGLabel;
		public float CcgLogoAlpha
		{
			get
			{
				return CcgLogo.Alpha;
			}
			set
			{
				CcgLogo.Alpha = value;
			}
		}

		public CcgSplashScreen()
			: base("CcgSplashScreen")
		{
		}

        public override void Initialize(bool addToManagers)
        {
			// Generated Initialize
			LoadStaticContent(ContentManagerName);
			CcgLogo = new FlatRedBall.Sprite();
			CcgLogo.Name = "CcgLogo";
			CreatedByLabel = new FrbTicTacToe.Entities.Label(ContentManagerName, false);
			CreatedByLabel.Name = "CreatedByLabel";
			CCGLabel = new FrbTicTacToe.Entities.Label(ContentManagerName, false);
			CCGLabel.Name = "CCGLabel";
			
			this.NextScreen = typeof(FrbTicTacToe.Screens.TitleMenu).FullName;
			
			PostInitialize();
			base.Initialize(addToManagers);
			if (addToManagers)
			{
				AddToManagers();
			}

        }
        
// Generated AddToManagers
		public override void AddToManagers ()
		{
			SpriteManager.AddSprite(CcgLogo);
			CreatedByLabel.AddToManagers(mLayer);
			CCGLabel.AddToManagers(mLayer);
			base.AddToManagers();
			AddToManagersBottomUp();
			CustomInitialize();
		}


		public override void Activity(bool firstTimeCalled)
		{
			// Generated Activity
			if (!IsPaused)
			{
				
				CreatedByLabel.Activity();
				CCGLabel.Activity();
			}
			else
			{
			}
			base.Activity(firstTimeCalled);
			if (!IsActivityFinished)
			{
				CustomActivity(firstTimeCalled);
			}


				// After Custom Activity
				
            
		}

		public override void Destroy()
		{
			// Generated Destroy
			CcgSplash = null;
			
			if (CcgLogo != null)
			{
				SpriteManager.RemoveSprite(CcgLogo);
			}
			if (CreatedByLabel != null)
			{
				CreatedByLabel.Destroy();
				CreatedByLabel.Detach();
			}
			if (CCGLabel != null)
			{
				CCGLabel.Destroy();
				CCGLabel.Detach();
			}

			base.Destroy();

			CustomDestroy();

		}

		// Generated Methods
		public virtual void PostInitialize ()
		{
			bool oldShapeManagerSuppressAdd = FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue;
			FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = true;
			CcgLogo.Texture = CcgSplash;
			CcgLogo.TextureScale = 1f;
			if (CreatedByLabel.Parent == null)
			{
				CreatedByLabel.Y = 300f;
			}
			else
			{
				CreatedByLabel.RelativeY = 300f;
			}
			CreatedByLabel.Text = "Created By";
			CreatedByLabel.FontSize = 40;
			CreatedByLabel.Red = 1f;
			CreatedByLabel.Green = 1f;
			CreatedByLabel.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Center;
			CreatedByLabel.VerticalAlignment = FlatRedBall.Graphics.VerticalAlignment.Top;
			if (CCGLabel.Parent == null)
			{
				CCGLabel.Y = -300f;
			}
			else
			{
				CCGLabel.RelativeY = -300f;
			}
			CCGLabel.Text = "CupCode Gamers";
			CCGLabel.FontSize = 40;
			CCGLabel.Red = 1f;
			CCGLabel.Green = 1f;
			CCGLabel.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Center;
			CCGLabel.VerticalAlignment = FlatRedBall.Graphics.VerticalAlignment.Bottom;
			FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = oldShapeManagerSuppressAdd;
		}
		public virtual void AddToManagersBottomUp ()
		{
			CameraSetup.ResetCamera(SpriteManager.Camera);
			AssignCustomVariables(false);
		}
		public virtual void RemoveFromManagers ()
		{
			if (CcgLogo != null)
			{
				SpriteManager.RemoveSpriteOneWay(CcgLogo);
			}
			CreatedByLabel.RemoveFromManagers();
			CCGLabel.RemoveFromManagers();
		}
		public virtual void AssignCustomVariables (bool callOnContainedElements)
		{
			if (callOnContainedElements)
			{
				CreatedByLabel.AssignCustomVariables(true);
				CCGLabel.AssignCustomVariables(true);
			}
			CcgLogo.Texture = CcgSplash;
			CcgLogo.TextureScale = 1f;
			if (CreatedByLabel.Parent == null)
			{
				CreatedByLabel.Y = 300f;
			}
			else
			{
				CreatedByLabel.RelativeY = 300f;
			}
			CreatedByLabel.Text = "Created By";
			CreatedByLabel.FontSize = 40;
			CreatedByLabel.Red = 1f;
			CreatedByLabel.Green = 1f;
			CreatedByLabel.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Center;
			CreatedByLabel.VerticalAlignment = FlatRedBall.Graphics.VerticalAlignment.Top;
			if (CCGLabel.Parent == null)
			{
				CCGLabel.Y = -300f;
			}
			else
			{
				CCGLabel.RelativeY = -300f;
			}
			CCGLabel.Text = "CupCode Gamers";
			CCGLabel.FontSize = 40;
			CCGLabel.Red = 1f;
			CCGLabel.Green = 1f;
			CCGLabel.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Center;
			CCGLabel.VerticalAlignment = FlatRedBall.Graphics.VerticalAlignment.Bottom;
			CcgLogoAlpha = 1f;
		}
		public virtual void ConvertToManuallyUpdated ()
		{
			SpriteManager.ConvertToManuallyUpdated(CcgLogo);
			CreatedByLabel.ConvertToManuallyUpdated();
			CCGLabel.ConvertToManuallyUpdated();
		}
		public static void LoadStaticContent (string contentManagerName)
		{
			if (string.IsNullOrEmpty(contentManagerName))
			{
				throw new ArgumentException("contentManagerName cannot be empty or null");
			}
			#if DEBUG
			if (contentManagerName == FlatRedBallServices.GlobalContentManager)
			{
				HasBeenLoadedWithGlobalContentManager = true;
			}
			else if (HasBeenLoadedWithGlobalContentManager)
			{
				throw new Exception("This type has been loaded with a Global content manager, then loaded with a non-global.  This can lead to a lot of bugs");
			}
			#endif
			if (!FlatRedBallServices.IsLoaded<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/screens/ccgsplashscreen/ccgsplash.png", contentManagerName))
			{
			}
			CcgSplash = FlatRedBallServices.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/screens/ccgsplashscreen/ccgsplash.png", contentManagerName);
			FrbTicTacToe.Entities.Label.LoadStaticContent(contentManagerName);
			CustomLoadStaticContent(contentManagerName);
		}
		static VariableState mLoadingState = VariableState.Uninitialized;
		public static VariableState LoadingState
		{
			get
			{
				return mLoadingState;
			}
			set
			{
				mLoadingState = value;
			}
		}
		public FlatRedBall.Instructions.Instruction InterpolateToState (VariableState stateToInterpolateTo, double secondsToTake)
		{
			switch(stateToInterpolateTo)
			{
				case  VariableState.Opaque:
					CcgLogo.AlphaRate = (1f - CcgLogo.Alpha) / (float)secondsToTake;
					break;
				case  VariableState.Transparent:
					CcgLogo.AlphaRate = (0f - CcgLogo.Alpha) / (float)secondsToTake;
					break;
			}
			var instruction = new FlatRedBall.Instructions.DelegateInstruction<VariableState>(StopStateInterpolation, stateToInterpolateTo);
			instruction.TimeToExecute = FlatRedBall.TimeManager.CurrentTime + secondsToTake;
			FlatRedBall.Instructions.InstructionManager.Add(instruction);
			return instruction;
		}
		public void StopStateInterpolation (VariableState stateToStop)
		{
			switch(stateToStop)
			{
				case  VariableState.Opaque:
					CcgLogo.AlphaRate =  0;
					break;
				case  VariableState.Transparent:
					CcgLogo.AlphaRate =  0;
					break;
			}
			CurrentState = stateToStop;
		}
		public void InterpolateBetween (VariableState firstState, VariableState secondState, float interpolationValue)
		{
			#if DEBUG
			if (float.IsNaN(interpolationValue))
			{
				throw new Exception("interpolationValue cannot be NaN");
			}
			#endif
			bool setCcgLogoAlpha = true;
			float CcgLogoAlphaFirstValue= 0;
			float CcgLogoAlphaSecondValue= 0;
			switch(firstState)
			{
				case  VariableState.Opaque:
					CcgLogoAlphaFirstValue = 1f;
					break;
				case  VariableState.Transparent:
					CcgLogoAlphaFirstValue = 0f;
					break;
			}
			switch(secondState)
			{
				case  VariableState.Opaque:
					CcgLogoAlphaSecondValue = 1f;
					break;
				case  VariableState.Transparent:
					CcgLogoAlphaSecondValue = 0f;
					break;
			}
			if (setCcgLogoAlpha)
			{
				CcgLogoAlpha = CcgLogoAlphaFirstValue * (1 - interpolationValue) + CcgLogoAlphaSecondValue * interpolationValue;
			}
			if (interpolationValue < 1)
			{
				mCurrentState = (int)firstState;
			}
			else
			{
				mCurrentState = (int)secondState;
			}
		}
		[System.Obsolete("Use GetFile instead")]
		public static object GetStaticMember (string memberName)
		{
			switch(memberName)
			{
				case  "CcgSplash":
					return CcgSplash;
			}
			return null;
		}
		public static object GetFile (string memberName)
		{
			switch(memberName)
			{
				case  "CcgSplash":
					return CcgSplash;
			}
			return null;
		}
		object GetMember (string memberName)
		{
			switch(memberName)
			{
				case  "CcgSplash":
					return CcgSplash;
			}
			return null;
		}


	}
}
