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
using FlatRedBall.Math;
using Microsoft.Xna.Framework.Graphics;

namespace FrbTicTacToe.Screens
{
	public partial class GameScreen : Screen
	{
		// Generated Fields
		#if DEBUG
		static bool HasBeenLoadedWithGlobalContentManager = false;
		#endif
		public enum PlayerIndicator
		{
			Uninitialized = 0, //This exists so that the first set call actually does something
			Unknown = 1, //This exists so that if the entity is actually a child entity and has set a child state, you will get this
			PlayerXMove = 2, 
			PlayerOMove = 3
		}
		protected int mCurrentPlayerIndicatorState = 0;
		public Screens.GameScreen.PlayerIndicator CurrentPlayerIndicatorState
		{
			get
			{
				if (Enum.IsDefined(typeof(PlayerIndicator), mCurrentPlayerIndicatorState))
				{
					return (PlayerIndicator)mCurrentPlayerIndicatorState;
				}
				else
				{
					return PlayerIndicator.Unknown;
				}
			}
			set
			{
				mCurrentPlayerIndicatorState = (int)value;
				switch(CurrentPlayerIndicatorState)
				{
					case  PlayerIndicator.Uninitialized:
						break;
					case  PlayerIndicator.Unknown:
						break;
					case  PlayerIndicator.PlayerXMove:
						break;
					case  PlayerIndicator.PlayerOMove:
						break;
				}
			}
		}
		protected static Microsoft.Xna.Framework.Graphics.Texture2D TopBarTexture;
		
		private PositionedObjectList<FrbTicTacToe.Entities.BoardTile> BoardTileList;
		private FrbTicTacToe.Entities.BoardTile BoardTile11;
		private FrbTicTacToe.Entities.BoardTile BoardTile12;
		private FrbTicTacToe.Entities.BoardTile BoardTile13;
		private FrbTicTacToe.Entities.BoardTile BoardTile21;
		private FrbTicTacToe.Entities.BoardTile BoardTile22;
		private FrbTicTacToe.Entities.BoardTile BoardTile23;
		private FrbTicTacToe.Entities.BoardTile BoardTile31;
		private FrbTicTacToe.Entities.BoardTile BoardTile32;
		private FrbTicTacToe.Entities.BoardTile BoardTile33;
		private FrbTicTacToe.Entities.Background BackgroundImage;
		private FrbTicTacToe.Entities.GridBackground GridBackgroundInstance;
		private FlatRedBall.Sprite TopBarSprite;
		private FrbTicTacToe.Entities.Label CurrentPlayerLabel;
		private FrbTicTacToe.Entities.BoardTile CurrentPlayerIndicator;
		private FrbTicTacToe.Entities.BoardTile PlayerXWinsLabel;
		private FrbTicTacToe.Entities.Icon Player1TypeLabel;
		private FrbTicTacToe.Entities.BoardTile PlayerOWinsLabel;
		private FrbTicTacToe.Entities.Icon Player2TypeLabel;
		private FrbTicTacToe.Entities.Label Player1WinCount;
		private FrbTicTacToe.Entities.Label Player2WinCount;
		private FrbTicTacToe.Entities.VictoryPopup VictoryPopupWindow;
		private FrbTicTacToe.Entities.Label PlayerXAiLevelText;
		private FrbTicTacToe.Entities.Label PlayerOAiLevelText;
		public int BlockingWeight = 25;
		public int CompletionWeight = 125;
		public int PairWeight = 5;
		public int SingleWeight = 1;

		public GameScreen()
			: base("GameScreen")
		{
		}

        public override void Initialize(bool addToManagers)
        {
			// Generated Initialize
			LoadStaticContent(ContentManagerName);
			BoardTileList = new PositionedObjectList<FrbTicTacToe.Entities.BoardTile>();
			BoardTileList.Name = "BoardTileList";
			BoardTile11 = new FrbTicTacToe.Entities.BoardTile(ContentManagerName, false);
			BoardTile11.Name = "BoardTile11";
			BoardTile12 = new FrbTicTacToe.Entities.BoardTile(ContentManagerName, false);
			BoardTile12.Name = "BoardTile12";
			BoardTile13 = new FrbTicTacToe.Entities.BoardTile(ContentManagerName, false);
			BoardTile13.Name = "BoardTile13";
			BoardTile21 = new FrbTicTacToe.Entities.BoardTile(ContentManagerName, false);
			BoardTile21.Name = "BoardTile21";
			BoardTile22 = new FrbTicTacToe.Entities.BoardTile(ContentManagerName, false);
			BoardTile22.Name = "BoardTile22";
			BoardTile23 = new FrbTicTacToe.Entities.BoardTile(ContentManagerName, false);
			BoardTile23.Name = "BoardTile23";
			BoardTile31 = new FrbTicTacToe.Entities.BoardTile(ContentManagerName, false);
			BoardTile31.Name = "BoardTile31";
			BoardTile32 = new FrbTicTacToe.Entities.BoardTile(ContentManagerName, false);
			BoardTile32.Name = "BoardTile32";
			BoardTile33 = new FrbTicTacToe.Entities.BoardTile(ContentManagerName, false);
			BoardTile33.Name = "BoardTile33";
			BackgroundImage = new FrbTicTacToe.Entities.Background(ContentManagerName, false);
			BackgroundImage.Name = "BackgroundImage";
			GridBackgroundInstance = new FrbTicTacToe.Entities.GridBackground(ContentManagerName, false);
			GridBackgroundInstance.Name = "GridBackgroundInstance";
			TopBarSprite = new FlatRedBall.Sprite();
			TopBarSprite.Name = "TopBarSprite";
			CurrentPlayerLabel = new FrbTicTacToe.Entities.Label(ContentManagerName, false);
			CurrentPlayerLabel.Name = "CurrentPlayerLabel";
			CurrentPlayerIndicator = new FrbTicTacToe.Entities.BoardTile(ContentManagerName, false);
			CurrentPlayerIndicator.Name = "CurrentPlayerIndicator";
			PlayerXWinsLabel = new FrbTicTacToe.Entities.BoardTile(ContentManagerName, false);
			PlayerXWinsLabel.Name = "PlayerXWinsLabel";
			Player1TypeLabel = new FrbTicTacToe.Entities.Icon(ContentManagerName, false);
			Player1TypeLabel.Name = "Player1TypeLabel";
			PlayerOWinsLabel = new FrbTicTacToe.Entities.BoardTile(ContentManagerName, false);
			PlayerOWinsLabel.Name = "PlayerOWinsLabel";
			Player2TypeLabel = new FrbTicTacToe.Entities.Icon(ContentManagerName, false);
			Player2TypeLabel.Name = "Player2TypeLabel";
			Player1WinCount = new FrbTicTacToe.Entities.Label(ContentManagerName, false);
			Player1WinCount.Name = "Player1WinCount";
			Player2WinCount = new FrbTicTacToe.Entities.Label(ContentManagerName, false);
			Player2WinCount.Name = "Player2WinCount";
			VictoryPopupWindow = new FrbTicTacToe.Entities.VictoryPopup(ContentManagerName, false);
			VictoryPopupWindow.Name = "VictoryPopupWindow";
			PlayerXAiLevelText = new FrbTicTacToe.Entities.Label(ContentManagerName, false);
			PlayerXAiLevelText.Name = "PlayerXAiLevelText";
			PlayerOAiLevelText = new FrbTicTacToe.Entities.Label(ContentManagerName, false);
			PlayerOAiLevelText.Name = "PlayerOAiLevelText";
			
			
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
			BoardTile11.AddToManagers(mLayer);
			BoardTile12.AddToManagers(mLayer);
			BoardTile13.AddToManagers(mLayer);
			BoardTile21.AddToManagers(mLayer);
			BoardTile22.AddToManagers(mLayer);
			BoardTile23.AddToManagers(mLayer);
			BoardTile31.AddToManagers(mLayer);
			BoardTile32.AddToManagers(mLayer);
			BoardTile33.AddToManagers(mLayer);
			BackgroundImage.AddToManagers(mLayer);
			GridBackgroundInstance.AddToManagers(mLayer);
			SpriteManager.AddSprite(TopBarSprite);
			CurrentPlayerLabel.AddToManagers(mLayer);
			CurrentPlayerIndicator.AddToManagers(mLayer);
			PlayerXWinsLabel.AddToManagers(mLayer);
			Player1TypeLabel.AddToManagers(mLayer);
			PlayerOWinsLabel.AddToManagers(mLayer);
			Player2TypeLabel.AddToManagers(mLayer);
			Player1WinCount.AddToManagers(mLayer);
			Player2WinCount.AddToManagers(mLayer);
			VictoryPopupWindow.AddToManagers(mLayer);
			PlayerXAiLevelText.AddToManagers(mLayer);
			PlayerOAiLevelText.AddToManagers(mLayer);
			base.AddToManagers();
			AddToManagersBottomUp();
			CustomInitialize();
		}


		public override void Activity(bool firstTimeCalled)
		{
			// Generated Activity
			if (!IsPaused)
			{
				
				for (int i = BoardTileList.Count - 1; i > -1; i--)
				{
					if (i < BoardTileList.Count)
					{
						// We do the extra if-check because activity could destroy any number of entities
						BoardTileList[i].Activity();
					}
				}
				BackgroundImage.Activity();
				GridBackgroundInstance.Activity();
				CurrentPlayerLabel.Activity();
				CurrentPlayerIndicator.Activity();
				PlayerXWinsLabel.Activity();
				Player1TypeLabel.Activity();
				PlayerOWinsLabel.Activity();
				Player2TypeLabel.Activity();
				Player1WinCount.Activity();
				Player2WinCount.Activity();
				VictoryPopupWindow.Activity();
				PlayerXAiLevelText.Activity();
				PlayerOAiLevelText.Activity();
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
			TopBarTexture = null;
			
			BoardTileList.MakeOneWay();
			for (int i = BoardTileList.Count - 1; i > -1; i--)
			{
				BoardTileList[i].Destroy();
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
			if (TopBarSprite != null)
			{
				SpriteManager.RemoveSprite(TopBarSprite);
			}
			if (CurrentPlayerLabel != null)
			{
				CurrentPlayerLabel.Destroy();
				CurrentPlayerLabel.Detach();
			}
			if (CurrentPlayerIndicator != null)
			{
				CurrentPlayerIndicator.Destroy();
				CurrentPlayerIndicator.Detach();
			}
			if (PlayerXWinsLabel != null)
			{
				PlayerXWinsLabel.Destroy();
				PlayerXWinsLabel.Detach();
			}
			if (Player1TypeLabel != null)
			{
				Player1TypeLabel.Destroy();
				Player1TypeLabel.Detach();
			}
			if (PlayerOWinsLabel != null)
			{
				PlayerOWinsLabel.Destroy();
				PlayerOWinsLabel.Detach();
			}
			if (Player2TypeLabel != null)
			{
				Player2TypeLabel.Destroy();
				Player2TypeLabel.Detach();
			}
			if (Player1WinCount != null)
			{
				Player1WinCount.Destroy();
				Player1WinCount.Detach();
			}
			if (Player2WinCount != null)
			{
				Player2WinCount.Destroy();
				Player2WinCount.Detach();
			}
			if (VictoryPopupWindow != null)
			{
				VictoryPopupWindow.Destroy();
				VictoryPopupWindow.Detach();
			}
			if (PlayerXAiLevelText != null)
			{
				PlayerXAiLevelText.Destroy();
				PlayerXAiLevelText.Detach();
			}
			if (PlayerOAiLevelText != null)
			{
				PlayerOAiLevelText.Destroy();
				PlayerOAiLevelText.Detach();
			}
			BoardTileList.MakeTwoWay();

			base.Destroy();

			CustomDestroy();

		}

		// Generated Methods
		public virtual void PostInitialize ()
		{
			bool oldShapeManagerSuppressAdd = FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue;
			FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = true;
			BoardTileList.Add(BoardTile11);
			if (BoardTile11.Parent == null)
			{
				BoardTile11.X = 133f;
			}
			else
			{
				BoardTile11.RelativeX = 133f;
			}
			if (BoardTile11.Parent == null)
			{
				BoardTile11.Y = 83f;
			}
			else
			{
				BoardTile11.RelativeY = 83f;
			}
			BoardTile11.PlayerSpriteHeight = 166f;
			BoardTile11.PlayerSpriteWidth = 266f;
			BoardTile11.CurrentState = BoardTile.VariableState.X;
			BoardTileList.Add(BoardTile12);
			if (BoardTile12.Parent == null)
			{
				BoardTile12.X = 133f;
			}
			else
			{
				BoardTile12.RelativeX = 133f;
			}
			if (BoardTile12.Parent == null)
			{
				BoardTile12.Y = 249f;
			}
			else
			{
				BoardTile12.RelativeY = 249f;
			}
			BoardTile12.PlayerSpriteHeight = 166f;
			BoardTile12.PlayerSpriteWidth = 266f;
			BoardTile12.CurrentState = BoardTile.VariableState.O;
			BoardTileList.Add(BoardTile13);
			if (BoardTile13.Parent == null)
			{
				BoardTile13.X = 133f;
			}
			else
			{
				BoardTile13.RelativeX = 133f;
			}
			if (BoardTile13.Parent == null)
			{
				BoardTile13.Y = 415f;
			}
			else
			{
				BoardTile13.RelativeY = 415f;
			}
			BoardTile13.PlayerSpriteHeight = 166f;
			BoardTile13.PlayerSpriteWidth = 266f;
			BoardTile13.CurrentState = BoardTile.VariableState.X;
			BoardTileList.Add(BoardTile21);
			if (BoardTile21.Parent == null)
			{
				BoardTile21.X = 399f;
			}
			else
			{
				BoardTile21.RelativeX = 399f;
			}
			if (BoardTile21.Parent == null)
			{
				BoardTile21.Y = 83f;
			}
			else
			{
				BoardTile21.RelativeY = 83f;
			}
			BoardTile21.PlayerSpriteHeight = 166f;
			BoardTile21.PlayerSpriteWidth = 266f;
			BoardTile21.CurrentState = BoardTile.VariableState.O;
			BoardTileList.Add(BoardTile22);
			if (BoardTile22.Parent == null)
			{
				BoardTile22.X = 399f;
			}
			else
			{
				BoardTile22.RelativeX = 399f;
			}
			if (BoardTile22.Parent == null)
			{
				BoardTile22.Y = 249f;
			}
			else
			{
				BoardTile22.RelativeY = 249f;
			}
			BoardTile22.PlayerSpriteHeight = 166f;
			BoardTile22.PlayerSpriteWidth = 266f;
			BoardTile22.CurrentState = BoardTile.VariableState.X;
			BoardTileList.Add(BoardTile23);
			if (BoardTile23.Parent == null)
			{
				BoardTile23.X = 399f;
			}
			else
			{
				BoardTile23.RelativeX = 399f;
			}
			if (BoardTile23.Parent == null)
			{
				BoardTile23.Y = 415f;
			}
			else
			{
				BoardTile23.RelativeY = 415f;
			}
			BoardTile23.PlayerSpriteHeight = 166f;
			BoardTile23.PlayerSpriteWidth = 266f;
			BoardTile23.CurrentState = BoardTile.VariableState.O;
			BoardTileList.Add(BoardTile31);
			if (BoardTile31.Parent == null)
			{
				BoardTile31.X = 664f;
			}
			else
			{
				BoardTile31.RelativeX = 664f;
			}
			if (BoardTile31.Parent == null)
			{
				BoardTile31.Y = 83f;
			}
			else
			{
				BoardTile31.RelativeY = 83f;
			}
			BoardTile31.PlayerSpriteHeight = 166f;
			BoardTile31.PlayerSpriteWidth = 266f;
			BoardTile31.CurrentState = BoardTile.VariableState.X;
			BoardTileList.Add(BoardTile32);
			if (BoardTile32.Parent == null)
			{
				BoardTile32.X = 664f;
			}
			else
			{
				BoardTile32.RelativeX = 664f;
			}
			if (BoardTile32.Parent == null)
			{
				BoardTile32.Y = 249f;
			}
			else
			{
				BoardTile32.RelativeY = 249f;
			}
			BoardTile32.PlayerSpriteHeight = 166f;
			BoardTile32.PlayerSpriteWidth = 266f;
			BoardTile32.CurrentState = BoardTile.VariableState.O;
			BoardTileList.Add(BoardTile33);
			if (BoardTile33.Parent == null)
			{
				BoardTile33.X = 664f;
			}
			else
			{
				BoardTile33.RelativeX = 664f;
			}
			if (BoardTile33.Parent == null)
			{
				BoardTile33.Y = 415f;
			}
			else
			{
				BoardTile33.RelativeY = 415f;
			}
			BoardTile33.PlayerSpriteHeight = 166f;
			BoardTile33.PlayerSpriteWidth = 266f;
			BoardTile33.CurrentState = BoardTile.VariableState.X;
			if (BackgroundImage.Parent == null)
			{
				BackgroundImage.X = 400f;
			}
			else
			{
				BackgroundImage.RelativeX = 400f;
			}
			if (BackgroundImage.Parent == null)
			{
				BackgroundImage.Y = 300f;
			}
			else
			{
				BackgroundImage.RelativeY = 300f;
			}
			if (GridBackgroundInstance.Parent == null)
			{
				GridBackgroundInstance.X = 390f;
			}
			else
			{
				GridBackgroundInstance.RelativeX = 390f;
			}
			if (GridBackgroundInstance.Parent == null)
			{
				GridBackgroundInstance.Y = 250f;
			}
			else
			{
				GridBackgroundInstance.RelativeY = 250f;
			}
			GridBackgroundInstance.Height = 500f;
			GridBackgroundInstance.Width = 800f;
			TopBarSprite.Texture = TopBarTexture;
			TopBarSprite.Height = 100f;
			TopBarSprite.TextureScale = 0f;
			TopBarSprite.Width = 800f;
			if (TopBarSprite.Parent == null)
			{
				TopBarSprite.X = 400f;
			}
			else
			{
				TopBarSprite.RelativeX = 400f;
			}
			if (TopBarSprite.Parent == null)
			{
				TopBarSprite.Y = 550f;
			}
			else
			{
				TopBarSprite.RelativeY = 550f;
			}
			if (TopBarSprite.Parent == null)
			{
				TopBarSprite.Z = -0.01f;
			}
			else
			{
				TopBarSprite.RelativeZ = -0.01f;
			}
			if (CurrentPlayerLabel.Parent == null)
			{
				CurrentPlayerLabel.X = 325f;
			}
			else
			{
				CurrentPlayerLabel.RelativeX = 325f;
			}
			if (CurrentPlayerLabel.Parent == null)
			{
				CurrentPlayerLabel.Y = 575f;
			}
			else
			{
				CurrentPlayerLabel.RelativeY = 575f;
			}
			CurrentPlayerLabel.Text = "Current Player";
			CurrentPlayerLabel.FontSize = 10;
			CurrentPlayerLabel.Red = 1f;
			CurrentPlayerLabel.Green = 1f;
			if (CurrentPlayerIndicator.Parent == null)
			{
				CurrentPlayerIndicator.X = 400f;
			}
			else
			{
				CurrentPlayerIndicator.RelativeX = 400f;
			}
			if (CurrentPlayerIndicator.Parent == null)
			{
				CurrentPlayerIndicator.Y = 535f;
			}
			else
			{
				CurrentPlayerIndicator.RelativeY = 535f;
			}
			CurrentPlayerIndicator.PlayerSpriteHeight = 80f;
			CurrentPlayerIndicator.PlayerSpriteWidth = 80f;
			CurrentPlayerIndicator.CurrentState = BoardTile.VariableState.X;
			if (PlayerXWinsLabel.Parent == null)
			{
				PlayerXWinsLabel.X = 30f;
			}
			else
			{
				PlayerXWinsLabel.RelativeX = 30f;
			}
			if (PlayerXWinsLabel.Parent == null)
			{
				PlayerXWinsLabel.Y = 570f;
			}
			else
			{
				PlayerXWinsLabel.RelativeY = 570f;
			}
			PlayerXWinsLabel.PlayerSpriteHeight = 50f;
			PlayerXWinsLabel.PlayerSpriteWidth = 50f;
			PlayerXWinsLabel.CurrentState = BoardTile.VariableState.X;
			if (Player1TypeLabel.Parent == null)
			{
				Player1TypeLabel.X = 70f;
			}
			else
			{
				Player1TypeLabel.RelativeX = 70f;
			}
			if (Player1TypeLabel.Parent == null)
			{
				Player1TypeLabel.Y = 570f;
			}
			else
			{
				Player1TypeLabel.RelativeY = 570f;
			}
			Player1TypeLabel.CurrentPlayerTypeState = Icon.PlayerType.Human;
			Player1TypeLabel.CurrentIconStateState = Icon.IconState.Selected;
			Player1TypeLabel.Size = 30f;
			Player1TypeLabel.HighlightSpriteVisible = false;
			if (PlayerOWinsLabel.Parent == null)
			{
				PlayerOWinsLabel.X = 760f;
			}
			else
			{
				PlayerOWinsLabel.RelativeX = 760f;
			}
			if (PlayerOWinsLabel.Parent == null)
			{
				PlayerOWinsLabel.Y = 570f;
			}
			else
			{
				PlayerOWinsLabel.RelativeY = 570f;
			}
			PlayerOWinsLabel.PlayerSpriteHeight = 50f;
			PlayerOWinsLabel.PlayerSpriteWidth = 50f;
			PlayerOWinsLabel.CurrentState = BoardTile.VariableState.O;
			if (Player2TypeLabel.Parent == null)
			{
				Player2TypeLabel.X = 720f;
			}
			else
			{
				Player2TypeLabel.RelativeX = 720f;
			}
			if (Player2TypeLabel.Parent == null)
			{
				Player2TypeLabel.Y = 570f;
			}
			else
			{
				Player2TypeLabel.RelativeY = 570f;
			}
			Player2TypeLabel.CurrentPlayerTypeState = Icon.PlayerType.Human;
			Player2TypeLabel.CurrentIconStateState = Icon.IconState.Selected;
			Player2TypeLabel.Size = 30f;
			Player2TypeLabel.HighlightSpriteVisible = false;
			if (Player1WinCount.Parent == null)
			{
				Player1WinCount.X = 15f;
			}
			else
			{
				Player1WinCount.RelativeX = 15f;
			}
			if (Player1WinCount.Parent == null)
			{
				Player1WinCount.Y = 540f;
			}
			else
			{
				Player1WinCount.RelativeY = 540f;
			}
			Player1WinCount.Text = "0 Wins";
			Player1WinCount.FontSize = 15;
			Player1WinCount.Red = 1f;
			Player1WinCount.Green = 1f;
			if (Player2WinCount.Parent == null)
			{
				Player2WinCount.X = 780f;
			}
			else
			{
				Player2WinCount.RelativeX = 780f;
			}
			if (Player2WinCount.Parent == null)
			{
				Player2WinCount.Y = 540f;
			}
			else
			{
				Player2WinCount.RelativeY = 540f;
			}
			Player2WinCount.Text = "0 Wins";
			Player2WinCount.FontSize = 15;
			Player2WinCount.Red = 1f;
			Player2WinCount.Green = 1f;
			Player2WinCount.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Right;
			if (VictoryPopupWindow.Parent == null)
			{
				VictoryPopupWindow.X = 400f;
			}
			else
			{
				VictoryPopupWindow.RelativeX = 400f;
			}
			if (VictoryPopupWindow.Parent == null)
			{
				VictoryPopupWindow.Y = 300f;
			}
			else
			{
				VictoryPopupWindow.RelativeY = 300f;
			}
			if (VictoryPopupWindow.Parent == null)
			{
				VictoryPopupWindow.Z = 2f;
			}
			else
			{
				VictoryPopupWindow.RelativeZ = 2f;
			}
			if (PlayerXAiLevelText.Parent == null)
			{
				PlayerXAiLevelText.X = 100f;
			}
			else
			{
				PlayerXAiLevelText.RelativeX = 100f;
			}
			if (PlayerXAiLevelText.Parent == null)
			{
				PlayerXAiLevelText.Y = 580f;
			}
			else
			{
				PlayerXAiLevelText.RelativeY = 580f;
			}
			PlayerXAiLevelText.FontSize = 10;
			PlayerXAiLevelText.Red = 1f;
			PlayerXAiLevelText.Green = 1f;
			PlayerXAiLevelText.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Left;
			PlayerXAiLevelText.VerticalAlignment = FlatRedBall.Graphics.VerticalAlignment.Top;
			if (PlayerOAiLevelText.Parent == null)
			{
				PlayerOAiLevelText.X = 680f;
			}
			else
			{
				PlayerOAiLevelText.RelativeX = 680f;
			}
			if (PlayerOAiLevelText.Parent == null)
			{
				PlayerOAiLevelText.Y = 580f;
			}
			else
			{
				PlayerOAiLevelText.RelativeY = 580f;
			}
			PlayerOAiLevelText.FontSize = 10;
			PlayerOAiLevelText.Red = 1f;
			PlayerOAiLevelText.Green = 1f;
			PlayerOAiLevelText.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Right;
			PlayerOAiLevelText.VerticalAlignment = FlatRedBall.Graphics.VerticalAlignment.Top;
			FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = oldShapeManagerSuppressAdd;
		}
		public virtual void AddToManagersBottomUp ()
		{
			CameraSetup.ResetCamera(SpriteManager.Camera);
			AssignCustomVariables(false);
		}
		public virtual void RemoveFromManagers ()
		{
			for (int i = BoardTileList.Count - 1; i > -1; i--)
			{
				BoardTileList[i].Destroy();
			}
			BackgroundImage.RemoveFromManagers();
			GridBackgroundInstance.RemoveFromManagers();
			if (TopBarSprite != null)
			{
				SpriteManager.RemoveSpriteOneWay(TopBarSprite);
			}
			CurrentPlayerLabel.RemoveFromManagers();
			CurrentPlayerIndicator.RemoveFromManagers();
			PlayerXWinsLabel.RemoveFromManagers();
			Player1TypeLabel.RemoveFromManagers();
			PlayerOWinsLabel.RemoveFromManagers();
			Player2TypeLabel.RemoveFromManagers();
			Player1WinCount.RemoveFromManagers();
			Player2WinCount.RemoveFromManagers();
			VictoryPopupWindow.RemoveFromManagers();
			PlayerXAiLevelText.RemoveFromManagers();
			PlayerOAiLevelText.RemoveFromManagers();
		}
		public virtual void AssignCustomVariables (bool callOnContainedElements)
		{
			if (callOnContainedElements)
			{
				BoardTile11.AssignCustomVariables(true);
				BoardTile12.AssignCustomVariables(true);
				BoardTile13.AssignCustomVariables(true);
				BoardTile21.AssignCustomVariables(true);
				BoardTile22.AssignCustomVariables(true);
				BoardTile23.AssignCustomVariables(true);
				BoardTile31.AssignCustomVariables(true);
				BoardTile32.AssignCustomVariables(true);
				BoardTile33.AssignCustomVariables(true);
				BackgroundImage.AssignCustomVariables(true);
				GridBackgroundInstance.AssignCustomVariables(true);
				CurrentPlayerLabel.AssignCustomVariables(true);
				CurrentPlayerIndicator.AssignCustomVariables(true);
				PlayerXWinsLabel.AssignCustomVariables(true);
				Player1TypeLabel.AssignCustomVariables(true);
				PlayerOWinsLabel.AssignCustomVariables(true);
				Player2TypeLabel.AssignCustomVariables(true);
				Player1WinCount.AssignCustomVariables(true);
				Player2WinCount.AssignCustomVariables(true);
				VictoryPopupWindow.AssignCustomVariables(true);
				PlayerXAiLevelText.AssignCustomVariables(true);
				PlayerOAiLevelText.AssignCustomVariables(true);
			}
			BoardTile11.CurrentState = FrbTicTacToe.Entities.BoardTile.VariableState.None;
			if (BoardTile11.Parent == null)
			{
				BoardTile11.X = 133f;
			}
			else
			{
				BoardTile11.RelativeX = 133f;
			}
			if (BoardTile11.Parent == null)
			{
				BoardTile11.Y = 83f;
			}
			else
			{
				BoardTile11.RelativeY = 83f;
			}
			BoardTile11.PlayerSpriteHeight = 166f;
			BoardTile11.PlayerSpriteWidth = 266f;
			BoardTile11.CurrentState = BoardTile.VariableState.X;
			BoardTile12.CurrentState = FrbTicTacToe.Entities.BoardTile.VariableState.None;
			if (BoardTile12.Parent == null)
			{
				BoardTile12.X = 133f;
			}
			else
			{
				BoardTile12.RelativeX = 133f;
			}
			if (BoardTile12.Parent == null)
			{
				BoardTile12.Y = 249f;
			}
			else
			{
				BoardTile12.RelativeY = 249f;
			}
			BoardTile12.PlayerSpriteHeight = 166f;
			BoardTile12.PlayerSpriteWidth = 266f;
			BoardTile12.CurrentState = BoardTile.VariableState.O;
			BoardTile13.CurrentState = FrbTicTacToe.Entities.BoardTile.VariableState.None;
			if (BoardTile13.Parent == null)
			{
				BoardTile13.X = 133f;
			}
			else
			{
				BoardTile13.RelativeX = 133f;
			}
			if (BoardTile13.Parent == null)
			{
				BoardTile13.Y = 415f;
			}
			else
			{
				BoardTile13.RelativeY = 415f;
			}
			BoardTile13.PlayerSpriteHeight = 166f;
			BoardTile13.PlayerSpriteWidth = 266f;
			BoardTile13.CurrentState = BoardTile.VariableState.X;
			BoardTile21.CurrentState = FrbTicTacToe.Entities.BoardTile.VariableState.O;
			if (BoardTile21.Parent == null)
			{
				BoardTile21.X = 399f;
			}
			else
			{
				BoardTile21.RelativeX = 399f;
			}
			if (BoardTile21.Parent == null)
			{
				BoardTile21.Y = 83f;
			}
			else
			{
				BoardTile21.RelativeY = 83f;
			}
			BoardTile21.PlayerSpriteHeight = 166f;
			BoardTile21.PlayerSpriteWidth = 266f;
			BoardTile21.CurrentState = BoardTile.VariableState.O;
			BoardTile22.CurrentState = FrbTicTacToe.Entities.BoardTile.VariableState.None;
			if (BoardTile22.Parent == null)
			{
				BoardTile22.X = 399f;
			}
			else
			{
				BoardTile22.RelativeX = 399f;
			}
			if (BoardTile22.Parent == null)
			{
				BoardTile22.Y = 249f;
			}
			else
			{
				BoardTile22.RelativeY = 249f;
			}
			BoardTile22.PlayerSpriteHeight = 166f;
			BoardTile22.PlayerSpriteWidth = 266f;
			BoardTile22.CurrentState = BoardTile.VariableState.X;
			BoardTile23.CurrentState = FrbTicTacToe.Entities.BoardTile.VariableState.X;
			if (BoardTile23.Parent == null)
			{
				BoardTile23.X = 399f;
			}
			else
			{
				BoardTile23.RelativeX = 399f;
			}
			if (BoardTile23.Parent == null)
			{
				BoardTile23.Y = 415f;
			}
			else
			{
				BoardTile23.RelativeY = 415f;
			}
			BoardTile23.PlayerSpriteHeight = 166f;
			BoardTile23.PlayerSpriteWidth = 266f;
			BoardTile23.CurrentState = BoardTile.VariableState.O;
			BoardTile31.CurrentState = FrbTicTacToe.Entities.BoardTile.VariableState.X;
			if (BoardTile31.Parent == null)
			{
				BoardTile31.X = 664f;
			}
			else
			{
				BoardTile31.RelativeX = 664f;
			}
			if (BoardTile31.Parent == null)
			{
				BoardTile31.Y = 83f;
			}
			else
			{
				BoardTile31.RelativeY = 83f;
			}
			BoardTile31.PlayerSpriteHeight = 166f;
			BoardTile31.PlayerSpriteWidth = 266f;
			BoardTile31.CurrentState = BoardTile.VariableState.X;
			BoardTile32.CurrentState = FrbTicTacToe.Entities.BoardTile.VariableState.X;
			if (BoardTile32.Parent == null)
			{
				BoardTile32.X = 664f;
			}
			else
			{
				BoardTile32.RelativeX = 664f;
			}
			if (BoardTile32.Parent == null)
			{
				BoardTile32.Y = 249f;
			}
			else
			{
				BoardTile32.RelativeY = 249f;
			}
			BoardTile32.PlayerSpriteHeight = 166f;
			BoardTile32.PlayerSpriteWidth = 266f;
			BoardTile32.CurrentState = BoardTile.VariableState.O;
			BoardTile33.CurrentState = FrbTicTacToe.Entities.BoardTile.VariableState.X;
			if (BoardTile33.Parent == null)
			{
				BoardTile33.X = 664f;
			}
			else
			{
				BoardTile33.RelativeX = 664f;
			}
			if (BoardTile33.Parent == null)
			{
				BoardTile33.Y = 415f;
			}
			else
			{
				BoardTile33.RelativeY = 415f;
			}
			BoardTile33.PlayerSpriteHeight = 166f;
			BoardTile33.PlayerSpriteWidth = 266f;
			BoardTile33.CurrentState = BoardTile.VariableState.X;
			if (BackgroundImage.Parent == null)
			{
				BackgroundImage.X = 400f;
			}
			else
			{
				BackgroundImage.RelativeX = 400f;
			}
			if (BackgroundImage.Parent == null)
			{
				BackgroundImage.Y = 300f;
			}
			else
			{
				BackgroundImage.RelativeY = 300f;
			}
			if (GridBackgroundInstance.Parent == null)
			{
				GridBackgroundInstance.X = 390f;
			}
			else
			{
				GridBackgroundInstance.RelativeX = 390f;
			}
			if (GridBackgroundInstance.Parent == null)
			{
				GridBackgroundInstance.Y = 250f;
			}
			else
			{
				GridBackgroundInstance.RelativeY = 250f;
			}
			GridBackgroundInstance.Height = 500f;
			GridBackgroundInstance.Width = 800f;
			TopBarSprite.Texture = TopBarTexture;
			TopBarSprite.Height = 100f;
			TopBarSprite.TextureScale = 0f;
			TopBarSprite.Width = 800f;
			if (TopBarSprite.Parent == null)
			{
				TopBarSprite.X = 400f;
			}
			else
			{
				TopBarSprite.RelativeX = 400f;
			}
			if (TopBarSprite.Parent == null)
			{
				TopBarSprite.Y = 550f;
			}
			else
			{
				TopBarSprite.RelativeY = 550f;
			}
			if (TopBarSprite.Parent == null)
			{
				TopBarSprite.Z = -0.01f;
			}
			else
			{
				TopBarSprite.RelativeZ = -0.01f;
			}
			if (CurrentPlayerLabel.Parent == null)
			{
				CurrentPlayerLabel.X = 325f;
			}
			else
			{
				CurrentPlayerLabel.RelativeX = 325f;
			}
			if (CurrentPlayerLabel.Parent == null)
			{
				CurrentPlayerLabel.Y = 575f;
			}
			else
			{
				CurrentPlayerLabel.RelativeY = 575f;
			}
			CurrentPlayerLabel.Text = "Current Player";
			CurrentPlayerLabel.FontSize = 10;
			CurrentPlayerLabel.Red = 1f;
			CurrentPlayerLabel.Green = 1f;
			if (CurrentPlayerIndicator.Parent == null)
			{
				CurrentPlayerIndicator.X = 400f;
			}
			else
			{
				CurrentPlayerIndicator.RelativeX = 400f;
			}
			if (CurrentPlayerIndicator.Parent == null)
			{
				CurrentPlayerIndicator.Y = 535f;
			}
			else
			{
				CurrentPlayerIndicator.RelativeY = 535f;
			}
			CurrentPlayerIndicator.PlayerSpriteHeight = 80f;
			CurrentPlayerIndicator.PlayerSpriteWidth = 80f;
			CurrentPlayerIndicator.CurrentState = BoardTile.VariableState.X;
			if (PlayerXWinsLabel.Parent == null)
			{
				PlayerXWinsLabel.X = 30f;
			}
			else
			{
				PlayerXWinsLabel.RelativeX = 30f;
			}
			if (PlayerXWinsLabel.Parent == null)
			{
				PlayerXWinsLabel.Y = 570f;
			}
			else
			{
				PlayerXWinsLabel.RelativeY = 570f;
			}
			PlayerXWinsLabel.PlayerSpriteHeight = 50f;
			PlayerXWinsLabel.PlayerSpriteWidth = 50f;
			PlayerXWinsLabel.CurrentState = BoardTile.VariableState.X;
			if (Player1TypeLabel.Parent == null)
			{
				Player1TypeLabel.X = 70f;
			}
			else
			{
				Player1TypeLabel.RelativeX = 70f;
			}
			if (Player1TypeLabel.Parent == null)
			{
				Player1TypeLabel.Y = 570f;
			}
			else
			{
				Player1TypeLabel.RelativeY = 570f;
			}
			Player1TypeLabel.CurrentPlayerTypeState = Icon.PlayerType.Human;
			Player1TypeLabel.CurrentIconStateState = Icon.IconState.Selected;
			Player1TypeLabel.Size = 30f;
			Player1TypeLabel.HighlightSpriteVisible = false;
			if (PlayerOWinsLabel.Parent == null)
			{
				PlayerOWinsLabel.X = 760f;
			}
			else
			{
				PlayerOWinsLabel.RelativeX = 760f;
			}
			if (PlayerOWinsLabel.Parent == null)
			{
				PlayerOWinsLabel.Y = 570f;
			}
			else
			{
				PlayerOWinsLabel.RelativeY = 570f;
			}
			PlayerOWinsLabel.PlayerSpriteHeight = 50f;
			PlayerOWinsLabel.PlayerSpriteWidth = 50f;
			PlayerOWinsLabel.CurrentState = BoardTile.VariableState.O;
			if (Player2TypeLabel.Parent == null)
			{
				Player2TypeLabel.X = 720f;
			}
			else
			{
				Player2TypeLabel.RelativeX = 720f;
			}
			if (Player2TypeLabel.Parent == null)
			{
				Player2TypeLabel.Y = 570f;
			}
			else
			{
				Player2TypeLabel.RelativeY = 570f;
			}
			Player2TypeLabel.CurrentPlayerTypeState = Icon.PlayerType.Human;
			Player2TypeLabel.CurrentIconStateState = Icon.IconState.Selected;
			Player2TypeLabel.Size = 30f;
			Player2TypeLabel.HighlightSpriteVisible = false;
			if (Player1WinCount.Parent == null)
			{
				Player1WinCount.X = 15f;
			}
			else
			{
				Player1WinCount.RelativeX = 15f;
			}
			if (Player1WinCount.Parent == null)
			{
				Player1WinCount.Y = 540f;
			}
			else
			{
				Player1WinCount.RelativeY = 540f;
			}
			Player1WinCount.Text = "0 Wins";
			Player1WinCount.FontSize = 15;
			Player1WinCount.Red = 1f;
			Player1WinCount.Green = 1f;
			if (Player2WinCount.Parent == null)
			{
				Player2WinCount.X = 780f;
			}
			else
			{
				Player2WinCount.RelativeX = 780f;
			}
			if (Player2WinCount.Parent == null)
			{
				Player2WinCount.Y = 540f;
			}
			else
			{
				Player2WinCount.RelativeY = 540f;
			}
			Player2WinCount.Text = "0 Wins";
			Player2WinCount.FontSize = 15;
			Player2WinCount.Red = 1f;
			Player2WinCount.Green = 1f;
			Player2WinCount.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Right;
			if (VictoryPopupWindow.Parent == null)
			{
				VictoryPopupWindow.X = 400f;
			}
			else
			{
				VictoryPopupWindow.RelativeX = 400f;
			}
			if (VictoryPopupWindow.Parent == null)
			{
				VictoryPopupWindow.Y = 300f;
			}
			else
			{
				VictoryPopupWindow.RelativeY = 300f;
			}
			if (VictoryPopupWindow.Parent == null)
			{
				VictoryPopupWindow.Z = 2f;
			}
			else
			{
				VictoryPopupWindow.RelativeZ = 2f;
			}
			if (PlayerXAiLevelText.Parent == null)
			{
				PlayerXAiLevelText.X = 100f;
			}
			else
			{
				PlayerXAiLevelText.RelativeX = 100f;
			}
			if (PlayerXAiLevelText.Parent == null)
			{
				PlayerXAiLevelText.Y = 580f;
			}
			else
			{
				PlayerXAiLevelText.RelativeY = 580f;
			}
			PlayerXAiLevelText.FontSize = 10;
			PlayerXAiLevelText.Red = 1f;
			PlayerXAiLevelText.Green = 1f;
			PlayerXAiLevelText.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Left;
			PlayerXAiLevelText.VerticalAlignment = FlatRedBall.Graphics.VerticalAlignment.Top;
			if (PlayerOAiLevelText.Parent == null)
			{
				PlayerOAiLevelText.X = 680f;
			}
			else
			{
				PlayerOAiLevelText.RelativeX = 680f;
			}
			if (PlayerOAiLevelText.Parent == null)
			{
				PlayerOAiLevelText.Y = 580f;
			}
			else
			{
				PlayerOAiLevelText.RelativeY = 580f;
			}
			PlayerOAiLevelText.FontSize = 10;
			PlayerOAiLevelText.Red = 1f;
			PlayerOAiLevelText.Green = 1f;
			PlayerOAiLevelText.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Right;
			PlayerOAiLevelText.VerticalAlignment = FlatRedBall.Graphics.VerticalAlignment.Top;
			CurrentPlayerIndicatorState = GameScreen.PlayerIndicator.PlayerXMove;
			BlockingWeight = 25;
			CompletionWeight = 125;
			PairWeight = 5;
			SingleWeight = 1;
		}
		public virtual void ConvertToManuallyUpdated ()
		{
			for (int i = 0; i < BoardTileList.Count; i++)
			{
				BoardTileList[i].ConvertToManuallyUpdated();
			}
			BackgroundImage.ConvertToManuallyUpdated();
			GridBackgroundInstance.ConvertToManuallyUpdated();
			SpriteManager.ConvertToManuallyUpdated(TopBarSprite);
			CurrentPlayerLabel.ConvertToManuallyUpdated();
			CurrentPlayerIndicator.ConvertToManuallyUpdated();
			PlayerXWinsLabel.ConvertToManuallyUpdated();
			Player1TypeLabel.ConvertToManuallyUpdated();
			PlayerOWinsLabel.ConvertToManuallyUpdated();
			Player2TypeLabel.ConvertToManuallyUpdated();
			Player1WinCount.ConvertToManuallyUpdated();
			Player2WinCount.ConvertToManuallyUpdated();
			VictoryPopupWindow.ConvertToManuallyUpdated();
			PlayerXAiLevelText.ConvertToManuallyUpdated();
			PlayerOAiLevelText.ConvertToManuallyUpdated();
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
			if (!FlatRedBallServices.IsLoaded<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/screens/gamescreen/topbartexture.png", contentManagerName))
			{
			}
			TopBarTexture = FlatRedBallServices.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/screens/gamescreen/topbartexture.png", contentManagerName);
			FrbTicTacToe.Entities.Background.LoadStaticContent(contentManagerName);
			FrbTicTacToe.Entities.GridBackground.LoadStaticContent(contentManagerName);
			FrbTicTacToe.Entities.Label.LoadStaticContent(contentManagerName);
			FrbTicTacToe.Entities.BoardTile.LoadStaticContent(contentManagerName);
			FrbTicTacToe.Entities.Icon.LoadStaticContent(contentManagerName);
			FrbTicTacToe.Entities.VictoryPopup.LoadStaticContent(contentManagerName);
			CustomLoadStaticContent(contentManagerName);
		}
		public FlatRedBall.Instructions.Instruction InterpolateToState (PlayerIndicator stateToInterpolateTo, double secondsToTake)
		{
			switch(stateToInterpolateTo)
			{
				case  PlayerIndicator.PlayerXMove:
					break;
				case  PlayerIndicator.PlayerOMove:
					break;
			}
			var instruction = new FlatRedBall.Instructions.DelegateInstruction<PlayerIndicator>(StopStateInterpolation, stateToInterpolateTo);
			instruction.TimeToExecute = FlatRedBall.TimeManager.CurrentTime + secondsToTake;
			FlatRedBall.Instructions.InstructionManager.Add(instruction);
			return instruction;
		}
		public void StopStateInterpolation (PlayerIndicator stateToStop)
		{
			switch(stateToStop)
			{
				case  PlayerIndicator.PlayerXMove:
					break;
				case  PlayerIndicator.PlayerOMove:
					break;
			}
			CurrentPlayerIndicatorState = stateToStop;
		}
		public void InterpolateBetween (PlayerIndicator firstState, PlayerIndicator secondState, float interpolationValue)
		{
			#if DEBUG
			if (float.IsNaN(interpolationValue))
			{
				throw new Exception("interpolationValue cannot be NaN");
			}
			#endif
			switch(firstState)
			{
				case  PlayerIndicator.PlayerXMove:
					break;
				case  PlayerIndicator.PlayerOMove:
					break;
			}
			switch(secondState)
			{
				case  PlayerIndicator.PlayerXMove:
					break;
				case  PlayerIndicator.PlayerOMove:
					break;
			}
			if (interpolationValue < 1)
			{
				mCurrentPlayerIndicatorState = (int)firstState;
			}
			else
			{
				mCurrentPlayerIndicatorState = (int)secondState;
			}
		}
		[System.Obsolete("Use GetFile instead")]
		public static object GetStaticMember (string memberName)
		{
			switch(memberName)
			{
				case  "TopBarTexture":
					return TopBarTexture;
			}
			return null;
		}
		public static object GetFile (string memberName)
		{
			switch(memberName)
			{
				case  "TopBarTexture":
					return TopBarTexture;
			}
			return null;
		}
		object GetMember (string memberName)
		{
			switch(memberName)
			{
				case  "TopBarTexture":
					return TopBarTexture;
			}
			return null;
		}


	}
}
