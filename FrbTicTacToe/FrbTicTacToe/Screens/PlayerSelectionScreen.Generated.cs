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

namespace FrbTicTacToe.Screens
{
	public partial class PlayerSelectionScreen : Screen
	{
		// Generated Fields
		#if DEBUG
		static bool HasBeenLoadedWithGlobalContentManager = false;
		#endif
		
		private FrbTicTacToe.Entities.Label Player1Label;
		private FrbTicTacToe.Entities.Label Player2Label;
		private FrbTicTacToe.Entities.Label PlayButton;
		private FrbTicTacToe.Entities.Label BackButton;
		private FrbTicTacToe.Entities.Background BackgroundImage;
		private FrbTicTacToe.Entities.Icon Player1HumanIcon;
		private FrbTicTacToe.Entities.Icon Player2HumanIcon;
		private FrbTicTacToe.Entities.Icon Player1ComputerIcon;
		private FrbTicTacToe.Entities.Icon Player2ComputerIcon;
		private FrbTicTacToe.Entities.BoardTile Player1Tile;
		private FrbTicTacToe.Entities.BoardTile Player2Tile;
		private FrbTicTacToe.Entities.AiSelector Player1AiSelector;
		private FrbTicTacToe.Entities.AiSelector Player2AiSelector;

		public PlayerSelectionScreen()
			: base("PlayerSelectionScreen")
		{
		}

        public override void Initialize(bool addToManagers)
        {
			// Generated Initialize
			LoadStaticContent(ContentManagerName);
			Player1Label = new FrbTicTacToe.Entities.Label(ContentManagerName, false);
			Player1Label.Name = "Player1Label";
			Player2Label = new FrbTicTacToe.Entities.Label(ContentManagerName, false);
			Player2Label.Name = "Player2Label";
			PlayButton = new FrbTicTacToe.Entities.Label(ContentManagerName, false);
			PlayButton.Name = "PlayButton";
			BackButton = new FrbTicTacToe.Entities.Label(ContentManagerName, false);
			BackButton.Name = "BackButton";
			BackgroundImage = new FrbTicTacToe.Entities.Background(ContentManagerName, false);
			BackgroundImage.Name = "BackgroundImage";
			Player1HumanIcon = new FrbTicTacToe.Entities.Icon(ContentManagerName, false);
			Player1HumanIcon.Name = "Player1HumanIcon";
			Player2HumanIcon = new FrbTicTacToe.Entities.Icon(ContentManagerName, false);
			Player2HumanIcon.Name = "Player2HumanIcon";
			Player1ComputerIcon = new FrbTicTacToe.Entities.Icon(ContentManagerName, false);
			Player1ComputerIcon.Name = "Player1ComputerIcon";
			Player2ComputerIcon = new FrbTicTacToe.Entities.Icon(ContentManagerName, false);
			Player2ComputerIcon.Name = "Player2ComputerIcon";
			Player1Tile = new FrbTicTacToe.Entities.BoardTile(ContentManagerName, false);
			Player1Tile.Name = "Player1Tile";
			Player2Tile = new FrbTicTacToe.Entities.BoardTile(ContentManagerName, false);
			Player2Tile.Name = "Player2Tile";
			Player1AiSelector = new FrbTicTacToe.Entities.AiSelector(ContentManagerName, false);
			Player1AiSelector.Name = "Player1AiSelector";
			Player2AiSelector = new FrbTicTacToe.Entities.AiSelector(ContentManagerName, false);
			Player2AiSelector.Name = "Player2AiSelector";
			
			
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
			Player1Label.AddToManagers(mLayer);
			Player2Label.AddToManagers(mLayer);
			PlayButton.AddToManagers(mLayer);
			BackButton.AddToManagers(mLayer);
			BackgroundImage.AddToManagers(mLayer);
			Player1HumanIcon.AddToManagers(mLayer);
			Player2HumanIcon.AddToManagers(mLayer);
			Player1ComputerIcon.AddToManagers(mLayer);
			Player2ComputerIcon.AddToManagers(mLayer);
			Player1Tile.AddToManagers(mLayer);
			Player2Tile.AddToManagers(mLayer);
			Player1AiSelector.AddToManagers(mLayer);
			Player2AiSelector.AddToManagers(mLayer);
			base.AddToManagers();
			AddToManagersBottomUp();
			CustomInitialize();
		}


		public override void Activity(bool firstTimeCalled)
		{
			// Generated Activity
			if (!IsPaused)
			{
				
				Player1Label.Activity();
				Player2Label.Activity();
				PlayButton.Activity();
				BackButton.Activity();
				BackgroundImage.Activity();
				Player1HumanIcon.Activity();
				Player2HumanIcon.Activity();
				Player1ComputerIcon.Activity();
				Player2ComputerIcon.Activity();
				Player1Tile.Activity();
				Player2Tile.Activity();
				Player1AiSelector.Activity();
				Player2AiSelector.Activity();
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
			
			if (Player1Label != null)
			{
				Player1Label.Destroy();
				Player1Label.Detach();
			}
			if (Player2Label != null)
			{
				Player2Label.Destroy();
				Player2Label.Detach();
			}
			if (PlayButton != null)
			{
				PlayButton.Destroy();
				PlayButton.Detach();
			}
			if (BackButton != null)
			{
				BackButton.Destroy();
				BackButton.Detach();
			}
			if (BackgroundImage != null)
			{
				BackgroundImage.Destroy();
				BackgroundImage.Detach();
			}
			if (Player1HumanIcon != null)
			{
				Player1HumanIcon.Destroy();
				Player1HumanIcon.Detach();
			}
			if (Player2HumanIcon != null)
			{
				Player2HumanIcon.Destroy();
				Player2HumanIcon.Detach();
			}
			if (Player1ComputerIcon != null)
			{
				Player1ComputerIcon.Destroy();
				Player1ComputerIcon.Detach();
			}
			if (Player2ComputerIcon != null)
			{
				Player2ComputerIcon.Destroy();
				Player2ComputerIcon.Detach();
			}
			if (Player1Tile != null)
			{
				Player1Tile.Destroy();
				Player1Tile.Detach();
			}
			if (Player2Tile != null)
			{
				Player2Tile.Destroy();
				Player2Tile.Detach();
			}
			if (Player1AiSelector != null)
			{
				Player1AiSelector.Destroy();
				Player1AiSelector.Detach();
			}
			if (Player2AiSelector != null)
			{
				Player2AiSelector.Destroy();
				Player2AiSelector.Detach();
			}

			base.Destroy();

			CustomDestroy();

		}

		// Generated Methods
		public virtual void PostInitialize ()
		{
			bool oldShapeManagerSuppressAdd = FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue;
			FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = true;
			if (Player1Label.Parent == null)
			{
				Player1Label.X = -125f;
			}
			else
			{
				Player1Label.RelativeX = -125f;
			}
			if (Player1Label.Parent == null)
			{
				Player1Label.Y = 250f;
			}
			else
			{
				Player1Label.RelativeY = 250f;
			}
			Player1Label.Text = "Player 1";
			Player1Label.FontSize = 20;
			Player1Label.Red = 1f;
			if (Player2Label.Parent == null)
			{
				Player2Label.X = -125f;
			}
			else
			{
				Player2Label.RelativeX = -125f;
			}
			if (Player2Label.Parent == null)
			{
				Player2Label.Y = 50f;
			}
			else
			{
				Player2Label.RelativeY = 50f;
			}
			Player2Label.Text = "Player 2";
			Player2Label.FontSize = 20;
			Player2Label.Red = 0f;
			Player2Label.Green = 0f;
			Player2Label.Blue = 1f;
			if (PlayButton.Parent == null)
			{
				PlayButton.X = 200f;
			}
			else
			{
				PlayButton.RelativeX = 200f;
			}
			if (PlayButton.Parent == null)
			{
				PlayButton.Y = -240f;
			}
			else
			{
				PlayButton.RelativeY = -240f;
			}
			PlayButton.Text = "Play";
			PlayButton.FontSize = 40;
			PlayButton.Green = 1f;
			if (BackButton.Parent == null)
			{
				BackButton.X = -380f;
			}
			else
			{
				BackButton.RelativeX = -380f;
			}
			if (BackButton.Parent == null)
			{
				BackButton.Y = -240f;
			}
			else
			{
				BackButton.RelativeY = -240f;
			}
			BackButton.Text = "Back";
			BackButton.FontSize = 40;
			BackButton.Red = 1f;
			BackgroundImage.RandomImage = false;
			if (Player1HumanIcon.Parent == null)
			{
				Player1HumanIcon.X = -100f;
			}
			else
			{
				Player1HumanIcon.RelativeX = -100f;
			}
			if (Player1HumanIcon.Parent == null)
			{
				Player1HumanIcon.Y = 170f;
			}
			else
			{
				Player1HumanIcon.RelativeY = 170f;
			}
			Player1HumanIcon.CurrentPlayerTypeState = Icon.PlayerType.Human;
			Player1HumanIcon.CurrentIconStateState = Icon.IconState.Selected;
			Player1HumanIcon.Size = 64f;
			if (Player2HumanIcon.Parent == null)
			{
				Player2HumanIcon.X = -100f;
			}
			else
			{
				Player2HumanIcon.RelativeX = -100f;
			}
			if (Player2HumanIcon.Parent == null)
			{
				Player2HumanIcon.Y = -40f;
			}
			else
			{
				Player2HumanIcon.RelativeY = -40f;
			}
			Player2HumanIcon.CurrentPlayerTypeState = Icon.PlayerType.Human;
			Player2HumanIcon.CurrentIconStateState = Icon.IconState.Selected;
			Player2HumanIcon.Size = 64f;
			if (Player1ComputerIcon.Parent == null)
			{
				Player1ComputerIcon.X = 100f;
			}
			else
			{
				Player1ComputerIcon.RelativeX = 100f;
			}
			if (Player1ComputerIcon.Parent == null)
			{
				Player1ComputerIcon.Y = 170f;
			}
			else
			{
				Player1ComputerIcon.RelativeY = 170f;
			}
			Player1ComputerIcon.CurrentPlayerTypeState = Icon.PlayerType.Computer;
			Player1ComputerIcon.CurrentIconStateState = Icon.IconState.NotSelected;
			Player1ComputerIcon.Size = 64f;
			if (Player2ComputerIcon.Parent == null)
			{
				Player2ComputerIcon.X = 100f;
			}
			else
			{
				Player2ComputerIcon.RelativeX = 100f;
			}
			if (Player2ComputerIcon.Parent == null)
			{
				Player2ComputerIcon.Y = -40f;
			}
			else
			{
				Player2ComputerIcon.RelativeY = -40f;
			}
			Player2ComputerIcon.CurrentPlayerTypeState = Icon.PlayerType.Computer;
			Player2ComputerIcon.CurrentIconStateState = Icon.IconState.NotSelected;
			Player2ComputerIcon.Size = 64f;
			if (Player1Tile.Parent == null)
			{
				Player1Tile.X = 100f;
			}
			else
			{
				Player1Tile.RelativeX = 100f;
			}
			if (Player1Tile.Parent == null)
			{
				Player1Tile.Y = 247f;
			}
			else
			{
				Player1Tile.RelativeY = 247f;
			}
			Player1Tile.PlayerSpriteHeight = 50f;
			Player1Tile.PlayerSpriteWidth = 50f;
			Player1Tile.CurrentState = BoardTile.VariableState.X;
			if (Player2Tile.Parent == null)
			{
				Player2Tile.X = 100f;
			}
			else
			{
				Player2Tile.RelativeX = 100f;
			}
			if (Player2Tile.Parent == null)
			{
				Player2Tile.Y = 50f;
			}
			else
			{
				Player2Tile.RelativeY = 50f;
			}
			Player2Tile.PlayerSpriteHeight = 50f;
			Player2Tile.PlayerSpriteWidth = 50f;
			Player2Tile.CurrentState = BoardTile.VariableState.O;
			if (Player1AiSelector.Parent == null)
			{
				Player1AiSelector.X = 150f;
			}
			else
			{
				Player1AiSelector.RelativeX = 150f;
			}
			if (Player1AiSelector.Parent == null)
			{
				Player1AiSelector.Y = 210f;
			}
			else
			{
				Player1AiSelector.RelativeY = 210f;
			}
			if (Player2AiSelector.Parent == null)
			{
				Player2AiSelector.X = 150f;
			}
			else
			{
				Player2AiSelector.RelativeX = 150f;
			}
			FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = oldShapeManagerSuppressAdd;
		}
		public virtual void AddToManagersBottomUp ()
		{
			CameraSetup.ResetCamera(SpriteManager.Camera);
			AssignCustomVariables(false);
		}
		public virtual void RemoveFromManagers ()
		{
			Player1Label.RemoveFromManagers();
			Player2Label.RemoveFromManagers();
			PlayButton.RemoveFromManagers();
			BackButton.RemoveFromManagers();
			BackgroundImage.RemoveFromManagers();
			Player1HumanIcon.RemoveFromManagers();
			Player2HumanIcon.RemoveFromManagers();
			Player1ComputerIcon.RemoveFromManagers();
			Player2ComputerIcon.RemoveFromManagers();
			Player1Tile.RemoveFromManagers();
			Player2Tile.RemoveFromManagers();
			Player1AiSelector.RemoveFromManagers();
			Player2AiSelector.RemoveFromManagers();
		}
		public virtual void AssignCustomVariables (bool callOnContainedElements)
		{
			if (callOnContainedElements)
			{
				Player1Label.AssignCustomVariables(true);
				Player2Label.AssignCustomVariables(true);
				PlayButton.AssignCustomVariables(true);
				BackButton.AssignCustomVariables(true);
				BackgroundImage.AssignCustomVariables(true);
				Player1HumanIcon.AssignCustomVariables(true);
				Player2HumanIcon.AssignCustomVariables(true);
				Player1ComputerIcon.AssignCustomVariables(true);
				Player2ComputerIcon.AssignCustomVariables(true);
				Player1Tile.AssignCustomVariables(true);
				Player2Tile.AssignCustomVariables(true);
				Player1AiSelector.AssignCustomVariables(true);
				Player2AiSelector.AssignCustomVariables(true);
			}
			if (Player1Label.Parent == null)
			{
				Player1Label.X = -125f;
			}
			else
			{
				Player1Label.RelativeX = -125f;
			}
			if (Player1Label.Parent == null)
			{
				Player1Label.Y = 250f;
			}
			else
			{
				Player1Label.RelativeY = 250f;
			}
			Player1Label.Text = "Player 1";
			Player1Label.FontSize = 20;
			Player1Label.Red = 1f;
			if (Player2Label.Parent == null)
			{
				Player2Label.X = -125f;
			}
			else
			{
				Player2Label.RelativeX = -125f;
			}
			if (Player2Label.Parent == null)
			{
				Player2Label.Y = 50f;
			}
			else
			{
				Player2Label.RelativeY = 50f;
			}
			Player2Label.Text = "Player 2";
			Player2Label.FontSize = 20;
			Player2Label.Red = 0f;
			Player2Label.Green = 0f;
			Player2Label.Blue = 1f;
			if (PlayButton.Parent == null)
			{
				PlayButton.X = 200f;
			}
			else
			{
				PlayButton.RelativeX = 200f;
			}
			if (PlayButton.Parent == null)
			{
				PlayButton.Y = -240f;
			}
			else
			{
				PlayButton.RelativeY = -240f;
			}
			PlayButton.Text = "Play";
			PlayButton.FontSize = 40;
			PlayButton.Green = 1f;
			if (BackButton.Parent == null)
			{
				BackButton.X = -380f;
			}
			else
			{
				BackButton.RelativeX = -380f;
			}
			if (BackButton.Parent == null)
			{
				BackButton.Y = -240f;
			}
			else
			{
				BackButton.RelativeY = -240f;
			}
			BackButton.Text = "Back";
			BackButton.FontSize = 40;
			BackButton.Red = 1f;
			BackgroundImage.RandomImage = false;
			if (Player1HumanIcon.Parent == null)
			{
				Player1HumanIcon.X = -100f;
			}
			else
			{
				Player1HumanIcon.RelativeX = -100f;
			}
			if (Player1HumanIcon.Parent == null)
			{
				Player1HumanIcon.Y = 170f;
			}
			else
			{
				Player1HumanIcon.RelativeY = 170f;
			}
			Player1HumanIcon.CurrentPlayerTypeState = Icon.PlayerType.Human;
			Player1HumanIcon.CurrentIconStateState = Icon.IconState.Selected;
			Player1HumanIcon.Size = 64f;
			if (Player2HumanIcon.Parent == null)
			{
				Player2HumanIcon.X = -100f;
			}
			else
			{
				Player2HumanIcon.RelativeX = -100f;
			}
			if (Player2HumanIcon.Parent == null)
			{
				Player2HumanIcon.Y = -40f;
			}
			else
			{
				Player2HumanIcon.RelativeY = -40f;
			}
			Player2HumanIcon.CurrentPlayerTypeState = Icon.PlayerType.Human;
			Player2HumanIcon.CurrentIconStateState = Icon.IconState.Selected;
			Player2HumanIcon.Size = 64f;
			if (Player1ComputerIcon.Parent == null)
			{
				Player1ComputerIcon.X = 100f;
			}
			else
			{
				Player1ComputerIcon.RelativeX = 100f;
			}
			if (Player1ComputerIcon.Parent == null)
			{
				Player1ComputerIcon.Y = 170f;
			}
			else
			{
				Player1ComputerIcon.RelativeY = 170f;
			}
			Player1ComputerIcon.CurrentPlayerTypeState = Icon.PlayerType.Computer;
			Player1ComputerIcon.CurrentIconStateState = Icon.IconState.NotSelected;
			Player1ComputerIcon.Size = 64f;
			if (Player2ComputerIcon.Parent == null)
			{
				Player2ComputerIcon.X = 100f;
			}
			else
			{
				Player2ComputerIcon.RelativeX = 100f;
			}
			if (Player2ComputerIcon.Parent == null)
			{
				Player2ComputerIcon.Y = -40f;
			}
			else
			{
				Player2ComputerIcon.RelativeY = -40f;
			}
			Player2ComputerIcon.CurrentPlayerTypeState = Icon.PlayerType.Computer;
			Player2ComputerIcon.CurrentIconStateState = Icon.IconState.NotSelected;
			Player2ComputerIcon.Size = 64f;
			if (Player1Tile.Parent == null)
			{
				Player1Tile.X = 100f;
			}
			else
			{
				Player1Tile.RelativeX = 100f;
			}
			if (Player1Tile.Parent == null)
			{
				Player1Tile.Y = 247f;
			}
			else
			{
				Player1Tile.RelativeY = 247f;
			}
			Player1Tile.PlayerSpriteHeight = 50f;
			Player1Tile.PlayerSpriteWidth = 50f;
			Player1Tile.CurrentState = BoardTile.VariableState.X;
			if (Player2Tile.Parent == null)
			{
				Player2Tile.X = 100f;
			}
			else
			{
				Player2Tile.RelativeX = 100f;
			}
			if (Player2Tile.Parent == null)
			{
				Player2Tile.Y = 50f;
			}
			else
			{
				Player2Tile.RelativeY = 50f;
			}
			Player2Tile.PlayerSpriteHeight = 50f;
			Player2Tile.PlayerSpriteWidth = 50f;
			Player2Tile.CurrentState = BoardTile.VariableState.O;
			if (Player1AiSelector.Parent == null)
			{
				Player1AiSelector.X = 150f;
			}
			else
			{
				Player1AiSelector.RelativeX = 150f;
			}
			if (Player1AiSelector.Parent == null)
			{
				Player1AiSelector.Y = 210f;
			}
			else
			{
				Player1AiSelector.RelativeY = 210f;
			}
			if (Player2AiSelector.Parent == null)
			{
				Player2AiSelector.X = 150f;
			}
			else
			{
				Player2AiSelector.RelativeX = 150f;
			}
		}
		public virtual void ConvertToManuallyUpdated ()
		{
			Player1Label.ConvertToManuallyUpdated();
			Player2Label.ConvertToManuallyUpdated();
			PlayButton.ConvertToManuallyUpdated();
			BackButton.ConvertToManuallyUpdated();
			BackgroundImage.ConvertToManuallyUpdated();
			Player1HumanIcon.ConvertToManuallyUpdated();
			Player2HumanIcon.ConvertToManuallyUpdated();
			Player1ComputerIcon.ConvertToManuallyUpdated();
			Player2ComputerIcon.ConvertToManuallyUpdated();
			Player1Tile.ConvertToManuallyUpdated();
			Player2Tile.ConvertToManuallyUpdated();
			Player1AiSelector.ConvertToManuallyUpdated();
			Player2AiSelector.ConvertToManuallyUpdated();
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
			FrbTicTacToe.Entities.Label.LoadStaticContent(contentManagerName);
			FrbTicTacToe.Entities.Background.LoadStaticContent(contentManagerName);
			FrbTicTacToe.Entities.Icon.LoadStaticContent(contentManagerName);
			FrbTicTacToe.Entities.BoardTile.LoadStaticContent(contentManagerName);
			FrbTicTacToe.Entities.AiSelector.LoadStaticContent(contentManagerName);
			CustomLoadStaticContent(contentManagerName);
		}
		[System.Obsolete("Use GetFile instead")]
		public static object GetStaticMember (string memberName)
		{
			return null;
		}
		public static object GetFile (string memberName)
		{
			return null;
		}
		object GetMember (string memberName)
		{
			return null;
		}


	}
}
