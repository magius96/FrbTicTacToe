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
	public partial class TitleMenu : Screen
	{
		// Generated Fields
		#if DEBUG
		static bool HasBeenLoadedWithGlobalContentManager = false;
		#endif
		
		private FrbTicTacToe.Entities.Label MenuItemPlay;
		private FrbTicTacToe.Entities.Label MenuItemExit;
		private FrbTicTacToe.Entities.Label TitleTextLabel;
		private FrbTicTacToe.Entities.Background BackgroundImage;
		private FrbTicTacToe.Entities.GridBackground GridBackgroundInstance;
		private FrbTicTacToe.Entities.BoardTile BoardTileO1;
		private FrbTicTacToe.Entities.BoardTile BoardTileO2;
		private FrbTicTacToe.Entities.BoardTile BoardTileX1;
		private FrbTicTacToe.Entities.BoardTile BoardTileX2;
		private FrbTicTacToe.Entities.BoardTile BoardTileX3;
		private FrbTicTacToe.Entities.Label MenuItemAbout;

		public TitleMenu()
			: base("TitleMenu")
		{
		}

        public override void Initialize(bool addToManagers)
        {
			// Generated Initialize
			LoadStaticContent(ContentManagerName);
			MenuItemPlay = new FrbTicTacToe.Entities.Label(ContentManagerName, false);
			MenuItemPlay.Name = "MenuItemPlay";
			MenuItemExit = new FrbTicTacToe.Entities.Label(ContentManagerName, false);
			MenuItemExit.Name = "MenuItemExit";
			TitleTextLabel = new FrbTicTacToe.Entities.Label(ContentManagerName, false);
			TitleTextLabel.Name = "TitleTextLabel";
			BackgroundImage = new FrbTicTacToe.Entities.Background(ContentManagerName, false);
			BackgroundImage.Name = "BackgroundImage";
			GridBackgroundInstance = new FrbTicTacToe.Entities.GridBackground(ContentManagerName, false);
			GridBackgroundInstance.Name = "GridBackgroundInstance";
			BoardTileO1 = new FrbTicTacToe.Entities.BoardTile(ContentManagerName, false);
			BoardTileO1.Name = "BoardTileO1";
			BoardTileO2 = new FrbTicTacToe.Entities.BoardTile(ContentManagerName, false);
			BoardTileO2.Name = "BoardTileO2";
			BoardTileX1 = new FrbTicTacToe.Entities.BoardTile(ContentManagerName, false);
			BoardTileX1.Name = "BoardTileX1";
			BoardTileX2 = new FrbTicTacToe.Entities.BoardTile(ContentManagerName, false);
			BoardTileX2.Name = "BoardTileX2";
			BoardTileX3 = new FrbTicTacToe.Entities.BoardTile(ContentManagerName, false);
			BoardTileX3.Name = "BoardTileX3";
			MenuItemAbout = new FrbTicTacToe.Entities.Label(ContentManagerName, false);
			MenuItemAbout.Name = "MenuItemAbout";
			
			
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
			MenuItemPlay.AddToManagers(mLayer);
			MenuItemExit.AddToManagers(mLayer);
			TitleTextLabel.AddToManagers(mLayer);
			BackgroundImage.AddToManagers(mLayer);
			GridBackgroundInstance.AddToManagers(mLayer);
			BoardTileO1.AddToManagers(mLayer);
			BoardTileO2.AddToManagers(mLayer);
			BoardTileX1.AddToManagers(mLayer);
			BoardTileX2.AddToManagers(mLayer);
			BoardTileX3.AddToManagers(mLayer);
			MenuItemAbout.AddToManagers(mLayer);
			base.AddToManagers();
			AddToManagersBottomUp();
			CustomInitialize();
		}


		public override void Activity(bool firstTimeCalled)
		{
			// Generated Activity
			if (!IsPaused)
			{
				
				MenuItemPlay.Activity();
				MenuItemExit.Activity();
				TitleTextLabel.Activity();
				BackgroundImage.Activity();
				GridBackgroundInstance.Activity();
				BoardTileO1.Activity();
				BoardTileO2.Activity();
				BoardTileX1.Activity();
				BoardTileX2.Activity();
				BoardTileX3.Activity();
				MenuItemAbout.Activity();
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
			
			if (MenuItemPlay != null)
			{
				MenuItemPlay.Destroy();
				MenuItemPlay.Detach();
			}
			if (MenuItemExit != null)
			{
				MenuItemExit.Destroy();
				MenuItemExit.Detach();
			}
			if (TitleTextLabel != null)
			{
				TitleTextLabel.Destroy();
				TitleTextLabel.Detach();
			}
			if (BackgroundImage != null)
			{
				BackgroundImage.Destroy();
				BackgroundImage.Detach();
			}
			if (GridBackgroundInstance != null)
			{
				GridBackgroundInstance.Destroy();
				GridBackgroundInstance.Detach();
			}
			if (BoardTileO1 != null)
			{
				BoardTileO1.Destroy();
				BoardTileO1.Detach();
			}
			if (BoardTileO2 != null)
			{
				BoardTileO2.Destroy();
				BoardTileO2.Detach();
			}
			if (BoardTileX1 != null)
			{
				BoardTileX1.Destroy();
				BoardTileX1.Detach();
			}
			if (BoardTileX2 != null)
			{
				BoardTileX2.Destroy();
				BoardTileX2.Detach();
			}
			if (BoardTileX3 != null)
			{
				BoardTileX3.Destroy();
				BoardTileX3.Detach();
			}
			if (MenuItemAbout != null)
			{
				MenuItemAbout.Destroy();
				MenuItemAbout.Detach();
			}

			base.Destroy();

			CustomDestroy();

		}

		// Generated Methods
		public virtual void PostInitialize ()
		{
			bool oldShapeManagerSuppressAdd = FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue;
			FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = true;
			if (MenuItemPlay.Parent == null)
			{
				MenuItemPlay.X = 200f;
			}
			else
			{
				MenuItemPlay.RelativeX = 200f;
			}
			if (MenuItemPlay.Parent == null)
			{
				MenuItemPlay.Y = -250f;
			}
			else
			{
				MenuItemPlay.RelativeY = -250f;
			}
			MenuItemPlay.Text = "Play";
			MenuItemPlay.FontSize = 40;
			MenuItemPlay.Red = 0f;
			MenuItemPlay.Green = 1f;
			MenuItemPlay.Blue = 0f;
			if (MenuItemExit.Parent == null)
			{
				MenuItemExit.X = -380f;
			}
			else
			{
				MenuItemExit.RelativeX = -380f;
			}
			if (MenuItemExit.Parent == null)
			{
				MenuItemExit.Y = -240f;
			}
			else
			{
				MenuItemExit.RelativeY = -240f;
			}
			MenuItemExit.Text = "Exit";
			MenuItemExit.FontSize = 40;
			MenuItemExit.Red = 1f;
			MenuItemExit.Green = 0f;
			MenuItemExit.Blue = 0f;
			if (TitleTextLabel.Parent == null)
			{
				TitleTextLabel.X = -350f;
			}
			else
			{
				TitleTextLabel.RelativeX = -350f;
			}
			if (TitleTextLabel.Parent == null)
			{
				TitleTextLabel.Y = 240f;
			}
			else
			{
				TitleTextLabel.RelativeY = 240f;
			}
			TitleTextLabel.Text = "Tic-Tac-Toe";
			TitleTextLabel.FontSize = 60;
			TitleTextLabel.Red = 1f;
			TitleTextLabel.Green = 1f;
			TitleTextLabel.Blue = 0f;
			BackgroundImage.RandomImage = false;
			if (GridBackgroundInstance.Parent == null)
			{
				GridBackgroundInstance.Y = -30f;
			}
			else
			{
				GridBackgroundInstance.RelativeY = -30f;
			}
			GridBackgroundInstance.Height = 300f;
			GridBackgroundInstance.Width = 300f;
			if (BoardTileO1.Parent == null)
			{
				BoardTileO1.X = 100f;
			}
			else
			{
				BoardTileO1.RelativeX = 100f;
			}
			if (BoardTileO1.Parent == null)
			{
				BoardTileO1.Y = -130f;
			}
			else
			{
				BoardTileO1.RelativeY = -130f;
			}
			BoardTileO1.PlayerSpriteHeight = 80f;
			BoardTileO1.PlayerSpriteWidth = 80f;
			BoardTileO1.CurrentState = BoardTile.VariableState.O;
			if (BoardTileO2.Parent == null)
			{
				BoardTileO2.Y = -30f;
			}
			else
			{
				BoardTileO2.RelativeY = -30f;
			}
			BoardTileO2.PlayerSpriteHeight = 80f;
			BoardTileO2.PlayerSpriteWidth = 80f;
			BoardTileO2.CurrentState = BoardTile.VariableState.O;
			if (BoardTileX1.Parent == null)
			{
				BoardTileX1.X = -100f;
			}
			else
			{
				BoardTileX1.RelativeX = -100f;
			}
			if (BoardTileX1.Parent == null)
			{
				BoardTileX1.Y = 70f;
			}
			else
			{
				BoardTileX1.RelativeY = 70f;
			}
			BoardTileX1.PlayerSpriteHeight = 80f;
			BoardTileX1.PlayerSpriteWidth = 80f;
			BoardTileX1.CurrentState = BoardTile.VariableState.X;
			if (BoardTileX2.Parent == null)
			{
				BoardTileX2.X = 100f;
			}
			else
			{
				BoardTileX2.RelativeX = 100f;
			}
			if (BoardTileX2.Parent == null)
			{
				BoardTileX2.Y = 70f;
			}
			else
			{
				BoardTileX2.RelativeY = 70f;
			}
			BoardTileX2.PlayerSpriteHeight = 80f;
			BoardTileX2.PlayerSpriteWidth = 80f;
			BoardTileX2.CurrentState = BoardTile.VariableState.X;
			if (BoardTileX3.Parent == null)
			{
				BoardTileX3.X = -100f;
			}
			else
			{
				BoardTileX3.RelativeX = -100f;
			}
			if (BoardTileX3.Parent == null)
			{
				BoardTileX3.Y = -130f;
			}
			else
			{
				BoardTileX3.RelativeY = -130f;
			}
			BoardTileX3.PlayerSpriteHeight = 80f;
			BoardTileX3.PlayerSpriteWidth = 80f;
			BoardTileX3.CurrentState = BoardTile.VariableState.X;
			if (MenuItemAbout.Parent == null)
			{
				MenuItemAbout.Y = -250f;
			}
			else
			{
				MenuItemAbout.RelativeY = -250f;
			}
			MenuItemAbout.Text = "About";
			MenuItemAbout.FontSize = 40;
			MenuItemAbout.Green = 1f;
			MenuItemAbout.Blue = 1f;
			MenuItemAbout.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Center;
			FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = oldShapeManagerSuppressAdd;
		}
		public virtual void AddToManagersBottomUp ()
		{
			CameraSetup.ResetCamera(SpriteManager.Camera);
			AssignCustomVariables(false);
		}
		public virtual void RemoveFromManagers ()
		{
			MenuItemPlay.RemoveFromManagers();
			MenuItemExit.RemoveFromManagers();
			TitleTextLabel.RemoveFromManagers();
			BackgroundImage.RemoveFromManagers();
			GridBackgroundInstance.RemoveFromManagers();
			BoardTileO1.RemoveFromManagers();
			BoardTileO2.RemoveFromManagers();
			BoardTileX1.RemoveFromManagers();
			BoardTileX2.RemoveFromManagers();
			BoardTileX3.RemoveFromManagers();
			MenuItemAbout.RemoveFromManagers();
		}
		public virtual void AssignCustomVariables (bool callOnContainedElements)
		{
			if (callOnContainedElements)
			{
				MenuItemPlay.AssignCustomVariables(true);
				MenuItemExit.AssignCustomVariables(true);
				TitleTextLabel.AssignCustomVariables(true);
				BackgroundImage.AssignCustomVariables(true);
				GridBackgroundInstance.AssignCustomVariables(true);
				BoardTileO1.AssignCustomVariables(true);
				BoardTileO2.AssignCustomVariables(true);
				BoardTileX1.AssignCustomVariables(true);
				BoardTileX2.AssignCustomVariables(true);
				BoardTileX3.AssignCustomVariables(true);
				MenuItemAbout.AssignCustomVariables(true);
			}
			if (MenuItemPlay.Parent == null)
			{
				MenuItemPlay.X = 200f;
			}
			else
			{
				MenuItemPlay.RelativeX = 200f;
			}
			if (MenuItemPlay.Parent == null)
			{
				MenuItemPlay.Y = -250f;
			}
			else
			{
				MenuItemPlay.RelativeY = -250f;
			}
			MenuItemPlay.Text = "Play";
			MenuItemPlay.FontSize = 40;
			MenuItemPlay.Red = 0f;
			MenuItemPlay.Green = 1f;
			MenuItemPlay.Blue = 0f;
			if (MenuItemExit.Parent == null)
			{
				MenuItemExit.X = -380f;
			}
			else
			{
				MenuItemExit.RelativeX = -380f;
			}
			if (MenuItemExit.Parent == null)
			{
				MenuItemExit.Y = -240f;
			}
			else
			{
				MenuItemExit.RelativeY = -240f;
			}
			MenuItemExit.Text = "Exit";
			MenuItemExit.FontSize = 40;
			MenuItemExit.Red = 1f;
			MenuItemExit.Green = 0f;
			MenuItemExit.Blue = 0f;
			if (TitleTextLabel.Parent == null)
			{
				TitleTextLabel.X = -350f;
			}
			else
			{
				TitleTextLabel.RelativeX = -350f;
			}
			if (TitleTextLabel.Parent == null)
			{
				TitleTextLabel.Y = 240f;
			}
			else
			{
				TitleTextLabel.RelativeY = 240f;
			}
			TitleTextLabel.Text = "Tic-Tac-Toe";
			TitleTextLabel.FontSize = 60;
			TitleTextLabel.Red = 1f;
			TitleTextLabel.Green = 1f;
			TitleTextLabel.Blue = 0f;
			BackgroundImage.RandomImage = false;
			if (GridBackgroundInstance.Parent == null)
			{
				GridBackgroundInstance.Y = -30f;
			}
			else
			{
				GridBackgroundInstance.RelativeY = -30f;
			}
			GridBackgroundInstance.Height = 300f;
			GridBackgroundInstance.Width = 300f;
			if (BoardTileO1.Parent == null)
			{
				BoardTileO1.X = 100f;
			}
			else
			{
				BoardTileO1.RelativeX = 100f;
			}
			if (BoardTileO1.Parent == null)
			{
				BoardTileO1.Y = -130f;
			}
			else
			{
				BoardTileO1.RelativeY = -130f;
			}
			BoardTileO1.PlayerSpriteHeight = 80f;
			BoardTileO1.PlayerSpriteWidth = 80f;
			BoardTileO1.CurrentState = BoardTile.VariableState.O;
			if (BoardTileO2.Parent == null)
			{
				BoardTileO2.Y = -30f;
			}
			else
			{
				BoardTileO2.RelativeY = -30f;
			}
			BoardTileO2.PlayerSpriteHeight = 80f;
			BoardTileO2.PlayerSpriteWidth = 80f;
			BoardTileO2.CurrentState = BoardTile.VariableState.O;
			if (BoardTileX1.Parent == null)
			{
				BoardTileX1.X = -100f;
			}
			else
			{
				BoardTileX1.RelativeX = -100f;
			}
			if (BoardTileX1.Parent == null)
			{
				BoardTileX1.Y = 70f;
			}
			else
			{
				BoardTileX1.RelativeY = 70f;
			}
			BoardTileX1.PlayerSpriteHeight = 80f;
			BoardTileX1.PlayerSpriteWidth = 80f;
			BoardTileX1.CurrentState = BoardTile.VariableState.X;
			if (BoardTileX2.Parent == null)
			{
				BoardTileX2.X = 100f;
			}
			else
			{
				BoardTileX2.RelativeX = 100f;
			}
			if (BoardTileX2.Parent == null)
			{
				BoardTileX2.Y = 70f;
			}
			else
			{
				BoardTileX2.RelativeY = 70f;
			}
			BoardTileX2.PlayerSpriteHeight = 80f;
			BoardTileX2.PlayerSpriteWidth = 80f;
			BoardTileX2.CurrentState = BoardTile.VariableState.X;
			if (BoardTileX3.Parent == null)
			{
				BoardTileX3.X = -100f;
			}
			else
			{
				BoardTileX3.RelativeX = -100f;
			}
			if (BoardTileX3.Parent == null)
			{
				BoardTileX3.Y = -130f;
			}
			else
			{
				BoardTileX3.RelativeY = -130f;
			}
			BoardTileX3.PlayerSpriteHeight = 80f;
			BoardTileX3.PlayerSpriteWidth = 80f;
			BoardTileX3.CurrentState = BoardTile.VariableState.X;
			if (MenuItemAbout.Parent == null)
			{
				MenuItemAbout.Y = -250f;
			}
			else
			{
				MenuItemAbout.RelativeY = -250f;
			}
			MenuItemAbout.Text = "About";
			MenuItemAbout.FontSize = 40;
			MenuItemAbout.Green = 1f;
			MenuItemAbout.Blue = 1f;
			MenuItemAbout.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Center;
		}
		public virtual void ConvertToManuallyUpdated ()
		{
			MenuItemPlay.ConvertToManuallyUpdated();
			MenuItemExit.ConvertToManuallyUpdated();
			TitleTextLabel.ConvertToManuallyUpdated();
			BackgroundImage.ConvertToManuallyUpdated();
			GridBackgroundInstance.ConvertToManuallyUpdated();
			BoardTileO1.ConvertToManuallyUpdated();
			BoardTileO2.ConvertToManuallyUpdated();
			BoardTileX1.ConvertToManuallyUpdated();
			BoardTileX2.ConvertToManuallyUpdated();
			BoardTileX3.ConvertToManuallyUpdated();
			MenuItemAbout.ConvertToManuallyUpdated();
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
			FrbTicTacToe.Entities.GridBackground.LoadStaticContent(contentManagerName);
			FrbTicTacToe.Entities.BoardTile.LoadStaticContent(contentManagerName);
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
