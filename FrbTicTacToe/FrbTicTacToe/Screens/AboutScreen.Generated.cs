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
	public partial class AboutScreen : Screen
	{
		// Generated Fields
		#if DEBUG
		static bool HasBeenLoadedWithGlobalContentManager = false;
		#endif
		
		private FrbTicTacToe.Entities.Background BackgroundImage;
		private FrbTicTacToe.Entities.Label BackButton;
		private FrbTicTacToe.Entities.Label ProgrammingLabel;
		private FrbTicTacToe.Entities.Label HeaderText;
		private FrbTicTacToe.Entities.Label ProgrammingText;
		private FrbTicTacToe.Entities.Label SupportLabel;
		private FrbTicTacToe.Entities.Label SupportText;
		private FrbTicTacToe.Entities.Label ArtworkLabel;
		private FrbTicTacToe.Entities.Label ArtworkText;
		private FrbTicTacToe.Entities.Label PaintingsLabel;
		private FrbTicTacToe.Entities.Label PaintingsText;
		private FrbTicTacToe.Entities.Label SoundEffectsLabel;
		private FrbTicTacToe.Entities.Label SoundEffectsText;
		private FrbTicTacToe.Entities.Label MusicLabel;
		private FrbTicTacToe.Entities.Label MusicText;

		public AboutScreen()
			: base("AboutScreen")
		{
		}

        public override void Initialize(bool addToManagers)
        {
			// Generated Initialize
			LoadStaticContent(ContentManagerName);
			BackgroundImage = new FrbTicTacToe.Entities.Background(ContentManagerName, false);
			BackgroundImage.Name = "BackgroundImage";
			BackButton = new FrbTicTacToe.Entities.Label(ContentManagerName, false);
			BackButton.Name = "BackButton";
			ProgrammingLabel = new FrbTicTacToe.Entities.Label(ContentManagerName, false);
			ProgrammingLabel.Name = "ProgrammingLabel";
			HeaderText = new FrbTicTacToe.Entities.Label(ContentManagerName, false);
			HeaderText.Name = "HeaderText";
			ProgrammingText = new FrbTicTacToe.Entities.Label(ContentManagerName, false);
			ProgrammingText.Name = "ProgrammingText";
			SupportLabel = new FrbTicTacToe.Entities.Label(ContentManagerName, false);
			SupportLabel.Name = "SupportLabel";
			SupportText = new FrbTicTacToe.Entities.Label(ContentManagerName, false);
			SupportText.Name = "SupportText";
			ArtworkLabel = new FrbTicTacToe.Entities.Label(ContentManagerName, false);
			ArtworkLabel.Name = "ArtworkLabel";
			ArtworkText = new FrbTicTacToe.Entities.Label(ContentManagerName, false);
			ArtworkText.Name = "ArtworkText";
			PaintingsLabel = new FrbTicTacToe.Entities.Label(ContentManagerName, false);
			PaintingsLabel.Name = "PaintingsLabel";
			PaintingsText = new FrbTicTacToe.Entities.Label(ContentManagerName, false);
			PaintingsText.Name = "PaintingsText";
			SoundEffectsLabel = new FrbTicTacToe.Entities.Label(ContentManagerName, false);
			SoundEffectsLabel.Name = "SoundEffectsLabel";
			SoundEffectsText = new FrbTicTacToe.Entities.Label(ContentManagerName, false);
			SoundEffectsText.Name = "SoundEffectsText";
			MusicLabel = new FrbTicTacToe.Entities.Label(ContentManagerName, false);
			MusicLabel.Name = "MusicLabel";
			MusicText = new FrbTicTacToe.Entities.Label(ContentManagerName, false);
			MusicText.Name = "MusicText";
			
			
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
			BackgroundImage.AddToManagers(mLayer);
			BackButton.AddToManagers(mLayer);
			ProgrammingLabel.AddToManagers(mLayer);
			HeaderText.AddToManagers(mLayer);
			ProgrammingText.AddToManagers(mLayer);
			SupportLabel.AddToManagers(mLayer);
			SupportText.AddToManagers(mLayer);
			ArtworkLabel.AddToManagers(mLayer);
			ArtworkText.AddToManagers(mLayer);
			PaintingsLabel.AddToManagers(mLayer);
			PaintingsText.AddToManagers(mLayer);
			SoundEffectsLabel.AddToManagers(mLayer);
			SoundEffectsText.AddToManagers(mLayer);
			MusicLabel.AddToManagers(mLayer);
			MusicText.AddToManagers(mLayer);
			base.AddToManagers();
			AddToManagersBottomUp();
			CustomInitialize();
		}


		public override void Activity(bool firstTimeCalled)
		{
			// Generated Activity
			if (!IsPaused)
			{
				
				BackgroundImage.Activity();
				BackButton.Activity();
				ProgrammingLabel.Activity();
				HeaderText.Activity();
				ProgrammingText.Activity();
				SupportLabel.Activity();
				SupportText.Activity();
				ArtworkLabel.Activity();
				ArtworkText.Activity();
				PaintingsLabel.Activity();
				PaintingsText.Activity();
				SoundEffectsLabel.Activity();
				SoundEffectsText.Activity();
				MusicLabel.Activity();
				MusicText.Activity();
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
			
			if (BackgroundImage != null)
			{
				BackgroundImage.Destroy();
				BackgroundImage.Detach();
			}
			if (BackButton != null)
			{
				BackButton.Destroy();
				BackButton.Detach();
			}
			if (ProgrammingLabel != null)
			{
				ProgrammingLabel.Destroy();
				ProgrammingLabel.Detach();
			}
			if (HeaderText != null)
			{
				HeaderText.Destroy();
				HeaderText.Detach();
			}
			if (ProgrammingText != null)
			{
				ProgrammingText.Destroy();
				ProgrammingText.Detach();
			}
			if (SupportLabel != null)
			{
				SupportLabel.Destroy();
				SupportLabel.Detach();
			}
			if (SupportText != null)
			{
				SupportText.Destroy();
				SupportText.Detach();
			}
			if (ArtworkLabel != null)
			{
				ArtworkLabel.Destroy();
				ArtworkLabel.Detach();
			}
			if (ArtworkText != null)
			{
				ArtworkText.Destroy();
				ArtworkText.Detach();
			}
			if (PaintingsLabel != null)
			{
				PaintingsLabel.Destroy();
				PaintingsLabel.Detach();
			}
			if (PaintingsText != null)
			{
				PaintingsText.Destroy();
				PaintingsText.Detach();
			}
			if (SoundEffectsLabel != null)
			{
				SoundEffectsLabel.Destroy();
				SoundEffectsLabel.Detach();
			}
			if (SoundEffectsText != null)
			{
				SoundEffectsText.Destroy();
				SoundEffectsText.Detach();
			}
			if (MusicLabel != null)
			{
				MusicLabel.Destroy();
				MusicLabel.Detach();
			}
			if (MusicText != null)
			{
				MusicText.Destroy();
				MusicText.Detach();
			}

			base.Destroy();

			CustomDestroy();

		}

		// Generated Methods
		public virtual void PostInitialize ()
		{
			bool oldShapeManagerSuppressAdd = FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue;
			FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = true;
			BackgroundImage.RandomImage = false;
			if (BackButton.Parent == null)
			{
				BackButton.X = -390f;
			}
			else
			{
				BackButton.RelativeX = -390f;
			}
			if (BackButton.Parent == null)
			{
				BackButton.Y = -290f;
			}
			else
			{
				BackButton.RelativeY = -290f;
			}
			BackButton.Text = "Back";
			BackButton.FontSize = 12;
			BackButton.Green = 1f;
			BackButton.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Left;
			BackButton.VerticalAlignment = FlatRedBall.Graphics.VerticalAlignment.Bottom;
			if (ProgrammingLabel.Parent == null)
			{
				ProgrammingLabel.Y = 189f;
			}
			else
			{
				ProgrammingLabel.RelativeY = 189f;
			}
			if (ProgrammingLabel.Parent == null)
			{
				ProgrammingLabel.Z = 0.01f;
			}
			else
			{
				ProgrammingLabel.RelativeZ = 0.01f;
			}
			ProgrammingLabel.Text = "Programming";
			ProgrammingLabel.FontSize = 9;
			ProgrammingLabel.Red = 1f;
			ProgrammingLabel.Green = 1f;
			ProgrammingLabel.Blue = 0f;
			ProgrammingLabel.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Center;
			ProgrammingLabel.VerticalAlignment = FlatRedBall.Graphics.VerticalAlignment.Top;
			if (HeaderText.Parent == null)
			{
				HeaderText.Y = 279f;
			}
			else
			{
				HeaderText.RelativeY = 279f;
			}
			if (HeaderText.Parent == null)
			{
				HeaderText.Z = 0.01f;
			}
			else
			{
				HeaderText.RelativeZ = 0.01f;
			}
			HeaderText.Text = "This version of Tic-Tac-Toe was built using FlatRedBall.\n\nFlatRedBall is a game development engine and toolkit\nthat is available free to the public.";
			HeaderText.FontSize = 9;
			HeaderText.Red = 0f;
			HeaderText.Green = 1f;
			HeaderText.Blue = 1f;
			HeaderText.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Center;
			HeaderText.VerticalAlignment = FlatRedBall.Graphics.VerticalAlignment.Top;
			if (ProgrammingText.Parent == null)
			{
				ProgrammingText.Y = 171f;
			}
			else
			{
				ProgrammingText.RelativeY = 171f;
			}
			if (ProgrammingText.Parent == null)
			{
				ProgrammingText.Z = 0.01f;
			}
			else
			{
				ProgrammingText.RelativeZ = 0.01f;
			}
			ProgrammingText.Text = "Jason Yarber (Magius96)";
			ProgrammingText.FontSize = 9;
			ProgrammingText.Red = 1f;
			ProgrammingText.Green = 1f;
			ProgrammingText.Blue = 1f;
			ProgrammingText.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Center;
			ProgrammingText.VerticalAlignment = FlatRedBall.Graphics.VerticalAlignment.Top;
			if (SupportLabel.Parent == null)
			{
				SupportLabel.Y = 135f;
			}
			else
			{
				SupportLabel.RelativeY = 135f;
			}
			if (SupportLabel.Parent == null)
			{
				SupportLabel.Z = 0.01f;
			}
			else
			{
				SupportLabel.RelativeZ = 0.01f;
			}
			SupportLabel.Text = "Support";
			SupportLabel.FontSize = 9;
			SupportLabel.Red = 1f;
			SupportLabel.Green = 1f;
			SupportLabel.Blue = 0f;
			SupportLabel.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Center;
			SupportLabel.VerticalAlignment = FlatRedBall.Graphics.VerticalAlignment.Top;
			if (SupportText.Parent == null)
			{
				SupportText.Y = 117f;
			}
			else
			{
				SupportText.RelativeY = 117f;
			}
			if (SupportText.Parent == null)
			{
				SupportText.Z = 0.01f;
			}
			else
			{
				SupportText.RelativeZ = 0.01f;
			}
			SupportText.Text = "Victor Chelaru\nLuckyNight";
			SupportText.FontSize = 9;
			SupportText.Red = 1f;
			SupportText.Green = 1f;
			SupportText.Blue = 1f;
			SupportText.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Center;
			SupportText.VerticalAlignment = FlatRedBall.Graphics.VerticalAlignment.Top;
			if (ArtworkLabel.Parent == null)
			{
				ArtworkLabel.Y = 63f;
			}
			else
			{
				ArtworkLabel.RelativeY = 63f;
			}
			if (ArtworkLabel.Parent == null)
			{
				ArtworkLabel.Z = 0.01f;
			}
			else
			{
				ArtworkLabel.RelativeZ = 0.01f;
			}
			ArtworkLabel.Text = "Artwork";
			ArtworkLabel.FontSize = 9;
			ArtworkLabel.Red = 1f;
			ArtworkLabel.Green = 1f;
			ArtworkLabel.Blue = 0f;
			ArtworkLabel.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Center;
			ArtworkLabel.VerticalAlignment = FlatRedBall.Graphics.VerticalAlignment.Top;
			if (ArtworkText.Parent == null)
			{
				ArtworkText.Y = 45f;
			}
			else
			{
				ArtworkText.RelativeY = 45f;
			}
			if (ArtworkText.Parent == null)
			{
				ArtworkText.Z = 0.01f;
			}
			else
			{
				ArtworkText.RelativeZ = 0.01f;
			}
			ArtworkText.Text = "Jason Yarber (Magius96)";
			ArtworkText.FontSize = 9;
			ArtworkText.Red = 1f;
			ArtworkText.Green = 1f;
			ArtworkText.Blue = 1f;
			ArtworkText.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Center;
			ArtworkText.VerticalAlignment = FlatRedBall.Graphics.VerticalAlignment.Top;
			if (PaintingsLabel.Parent == null)
			{
				PaintingsLabel.Y = 9f;
			}
			else
			{
				PaintingsLabel.RelativeY = 9f;
			}
			if (PaintingsLabel.Parent == null)
			{
				PaintingsLabel.Z = 0.01f;
			}
			else
			{
				PaintingsLabel.RelativeZ = 0.01f;
			}
			PaintingsLabel.Text = "Paintings";
			PaintingsLabel.FontSize = 9;
			PaintingsLabel.Red = 1f;
			PaintingsLabel.Green = 1f;
			PaintingsLabel.Blue = 0f;
			PaintingsLabel.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Center;
			PaintingsLabel.VerticalAlignment = FlatRedBall.Graphics.VerticalAlignment.Top;
			if (PaintingsText.Parent == null)
			{
				PaintingsText.Y = -9f;
			}
			else
			{
				PaintingsText.RelativeY = -9f;
			}
			if (PaintingsText.Parent == null)
			{
				PaintingsText.Z = 0.01f;
			}
			else
			{
				PaintingsText.RelativeZ = 0.01f;
			}
			PaintingsText.Text = "Childe Hassam - Bridge over the stour\nGerda Wallander - Barplockande barn en sommardag\nJohn Reinhard Weguelin - Mermaid (1911)\nTurner - The Slave Ship\nWidder Dunavecse 1939";
			PaintingsText.FontSize = 9;
			PaintingsText.Red = 1f;
			PaintingsText.Green = 1f;
			PaintingsText.Blue = 1f;
			PaintingsText.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Center;
			PaintingsText.VerticalAlignment = FlatRedBall.Graphics.VerticalAlignment.Top;
			if (SoundEffectsLabel.Parent == null)
			{
				SoundEffectsLabel.Y = -117f;
			}
			else
			{
				SoundEffectsLabel.RelativeY = -117f;
			}
			if (SoundEffectsLabel.Parent == null)
			{
				SoundEffectsLabel.Z = 0.01f;
			}
			else
			{
				SoundEffectsLabel.RelativeZ = 0.01f;
			}
			SoundEffectsLabel.Text = "Sound Effects";
			SoundEffectsLabel.FontSize = 9;
			SoundEffectsLabel.Red = 1f;
			SoundEffectsLabel.Green = 1f;
			SoundEffectsLabel.Blue = 0f;
			SoundEffectsLabel.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Center;
			SoundEffectsLabel.VerticalAlignment = FlatRedBall.Graphics.VerticalAlignment.Top;
			if (SoundEffectsText.Parent == null)
			{
				SoundEffectsText.Y = -135f;
			}
			else
			{
				SoundEffectsText.RelativeY = -135f;
			}
			if (SoundEffectsText.Parent == null)
			{
				SoundEffectsText.Z = 0.01f;
			}
			else
			{
				SoundEffectsText.RelativeZ = 0.01f;
			}
			SoundEffectsText.Text = "Caroline Ford - Small Scrape\nJoe Lamb - Sad Trombone\nMike Koenig - Ta Da\nNatalie Wendt - Bubble Gum Pop\nSebastian - Click2";
			SoundEffectsText.FontSize = 9;
			SoundEffectsText.Red = 1f;
			SoundEffectsText.Green = 1f;
			SoundEffectsText.Blue = 1f;
			SoundEffectsText.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Center;
			SoundEffectsText.VerticalAlignment = FlatRedBall.Graphics.VerticalAlignment.Top;
			if (MusicLabel.Parent == null)
			{
				MusicLabel.Y = -243f;
			}
			else
			{
				MusicLabel.RelativeY = -243f;
			}
			if (MusicLabel.Parent == null)
			{
				MusicLabel.Z = 0.01f;
			}
			else
			{
				MusicLabel.RelativeZ = 0.01f;
			}
			MusicLabel.Text = "Music";
			MusicLabel.FontSize = 9;
			MusicLabel.Red = 1f;
			MusicLabel.Green = 1f;
			MusicLabel.Blue = 0f;
			MusicLabel.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Center;
			MusicLabel.VerticalAlignment = FlatRedBall.Graphics.VerticalAlignment.Top;
			if (MusicText.Parent == null)
			{
				MusicText.Y = -261f;
			}
			else
			{
				MusicText.RelativeY = -261f;
			}
			if (MusicText.Parent == null)
			{
				MusicText.Z = 0.01f;
			}
			else
			{
				MusicText.RelativeZ = 0.01f;
			}
			MusicText.Text = "Jason Shaw at audionautix.com";
			MusicText.FontSize = 9;
			MusicText.Red = 1f;
			MusicText.Green = 1f;
			MusicText.Blue = 1f;
			MusicText.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Center;
			MusicText.VerticalAlignment = FlatRedBall.Graphics.VerticalAlignment.Top;
			FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = oldShapeManagerSuppressAdd;
		}
		public virtual void AddToManagersBottomUp ()
		{
			CameraSetup.ResetCamera(SpriteManager.Camera);
			AssignCustomVariables(false);
		}
		public virtual void RemoveFromManagers ()
		{
			BackgroundImage.RemoveFromManagers();
			BackButton.RemoveFromManagers();
			ProgrammingLabel.RemoveFromManagers();
			HeaderText.RemoveFromManagers();
			ProgrammingText.RemoveFromManagers();
			SupportLabel.RemoveFromManagers();
			SupportText.RemoveFromManagers();
			ArtworkLabel.RemoveFromManagers();
			ArtworkText.RemoveFromManagers();
			PaintingsLabel.RemoveFromManagers();
			PaintingsText.RemoveFromManagers();
			SoundEffectsLabel.RemoveFromManagers();
			SoundEffectsText.RemoveFromManagers();
			MusicLabel.RemoveFromManagers();
			MusicText.RemoveFromManagers();
		}
		public virtual void AssignCustomVariables (bool callOnContainedElements)
		{
			if (callOnContainedElements)
			{
				BackgroundImage.AssignCustomVariables(true);
				BackButton.AssignCustomVariables(true);
				ProgrammingLabel.AssignCustomVariables(true);
				HeaderText.AssignCustomVariables(true);
				ProgrammingText.AssignCustomVariables(true);
				SupportLabel.AssignCustomVariables(true);
				SupportText.AssignCustomVariables(true);
				ArtworkLabel.AssignCustomVariables(true);
				ArtworkText.AssignCustomVariables(true);
				PaintingsLabel.AssignCustomVariables(true);
				PaintingsText.AssignCustomVariables(true);
				SoundEffectsLabel.AssignCustomVariables(true);
				SoundEffectsText.AssignCustomVariables(true);
				MusicLabel.AssignCustomVariables(true);
				MusicText.AssignCustomVariables(true);
			}
			BackgroundImage.RandomImage = false;
			if (BackButton.Parent == null)
			{
				BackButton.X = -390f;
			}
			else
			{
				BackButton.RelativeX = -390f;
			}
			if (BackButton.Parent == null)
			{
				BackButton.Y = -290f;
			}
			else
			{
				BackButton.RelativeY = -290f;
			}
			BackButton.Text = "Back";
			BackButton.FontSize = 12;
			BackButton.Green = 1f;
			BackButton.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Left;
			BackButton.VerticalAlignment = FlatRedBall.Graphics.VerticalAlignment.Bottom;
			if (ProgrammingLabel.Parent == null)
			{
				ProgrammingLabel.Y = 189f;
			}
			else
			{
				ProgrammingLabel.RelativeY = 189f;
			}
			if (ProgrammingLabel.Parent == null)
			{
				ProgrammingLabel.Z = 0.01f;
			}
			else
			{
				ProgrammingLabel.RelativeZ = 0.01f;
			}
			ProgrammingLabel.Text = "Programming";
			ProgrammingLabel.FontSize = 9;
			ProgrammingLabel.Red = 1f;
			ProgrammingLabel.Green = 1f;
			ProgrammingLabel.Blue = 0f;
			ProgrammingLabel.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Center;
			ProgrammingLabel.VerticalAlignment = FlatRedBall.Graphics.VerticalAlignment.Top;
			if (HeaderText.Parent == null)
			{
				HeaderText.Y = 279f;
			}
			else
			{
				HeaderText.RelativeY = 279f;
			}
			if (HeaderText.Parent == null)
			{
				HeaderText.Z = 0.01f;
			}
			else
			{
				HeaderText.RelativeZ = 0.01f;
			}
			HeaderText.Text = "This version of Tic-Tac-Toe was built using FlatRedBall.\n\nFlatRedBall is a game development engine and toolkit\nthat is available free to the public.";
			HeaderText.FontSize = 9;
			HeaderText.Red = 0f;
			HeaderText.Green = 1f;
			HeaderText.Blue = 1f;
			HeaderText.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Center;
			HeaderText.VerticalAlignment = FlatRedBall.Graphics.VerticalAlignment.Top;
			if (ProgrammingText.Parent == null)
			{
				ProgrammingText.Y = 171f;
			}
			else
			{
				ProgrammingText.RelativeY = 171f;
			}
			if (ProgrammingText.Parent == null)
			{
				ProgrammingText.Z = 0.01f;
			}
			else
			{
				ProgrammingText.RelativeZ = 0.01f;
			}
			ProgrammingText.Text = "Jason Yarber (Magius96)";
			ProgrammingText.FontSize = 9;
			ProgrammingText.Red = 1f;
			ProgrammingText.Green = 1f;
			ProgrammingText.Blue = 1f;
			ProgrammingText.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Center;
			ProgrammingText.VerticalAlignment = FlatRedBall.Graphics.VerticalAlignment.Top;
			if (SupportLabel.Parent == null)
			{
				SupportLabel.Y = 135f;
			}
			else
			{
				SupportLabel.RelativeY = 135f;
			}
			if (SupportLabel.Parent == null)
			{
				SupportLabel.Z = 0.01f;
			}
			else
			{
				SupportLabel.RelativeZ = 0.01f;
			}
			SupportLabel.Text = "Support";
			SupportLabel.FontSize = 9;
			SupportLabel.Red = 1f;
			SupportLabel.Green = 1f;
			SupportLabel.Blue = 0f;
			SupportLabel.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Center;
			SupportLabel.VerticalAlignment = FlatRedBall.Graphics.VerticalAlignment.Top;
			if (SupportText.Parent == null)
			{
				SupportText.Y = 117f;
			}
			else
			{
				SupportText.RelativeY = 117f;
			}
			if (SupportText.Parent == null)
			{
				SupportText.Z = 0.01f;
			}
			else
			{
				SupportText.RelativeZ = 0.01f;
			}
			SupportText.Text = "Victor Chelaru\nLuckyNight";
			SupportText.FontSize = 9;
			SupportText.Red = 1f;
			SupportText.Green = 1f;
			SupportText.Blue = 1f;
			SupportText.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Center;
			SupportText.VerticalAlignment = FlatRedBall.Graphics.VerticalAlignment.Top;
			if (ArtworkLabel.Parent == null)
			{
				ArtworkLabel.Y = 63f;
			}
			else
			{
				ArtworkLabel.RelativeY = 63f;
			}
			if (ArtworkLabel.Parent == null)
			{
				ArtworkLabel.Z = 0.01f;
			}
			else
			{
				ArtworkLabel.RelativeZ = 0.01f;
			}
			ArtworkLabel.Text = "Artwork";
			ArtworkLabel.FontSize = 9;
			ArtworkLabel.Red = 1f;
			ArtworkLabel.Green = 1f;
			ArtworkLabel.Blue = 0f;
			ArtworkLabel.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Center;
			ArtworkLabel.VerticalAlignment = FlatRedBall.Graphics.VerticalAlignment.Top;
			if (ArtworkText.Parent == null)
			{
				ArtworkText.Y = 45f;
			}
			else
			{
				ArtworkText.RelativeY = 45f;
			}
			if (ArtworkText.Parent == null)
			{
				ArtworkText.Z = 0.01f;
			}
			else
			{
				ArtworkText.RelativeZ = 0.01f;
			}
			ArtworkText.Text = "Jason Yarber (Magius96)";
			ArtworkText.FontSize = 9;
			ArtworkText.Red = 1f;
			ArtworkText.Green = 1f;
			ArtworkText.Blue = 1f;
			ArtworkText.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Center;
			ArtworkText.VerticalAlignment = FlatRedBall.Graphics.VerticalAlignment.Top;
			if (PaintingsLabel.Parent == null)
			{
				PaintingsLabel.Y = 9f;
			}
			else
			{
				PaintingsLabel.RelativeY = 9f;
			}
			if (PaintingsLabel.Parent == null)
			{
				PaintingsLabel.Z = 0.01f;
			}
			else
			{
				PaintingsLabel.RelativeZ = 0.01f;
			}
			PaintingsLabel.Text = "Paintings";
			PaintingsLabel.FontSize = 9;
			PaintingsLabel.Red = 1f;
			PaintingsLabel.Green = 1f;
			PaintingsLabel.Blue = 0f;
			PaintingsLabel.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Center;
			PaintingsLabel.VerticalAlignment = FlatRedBall.Graphics.VerticalAlignment.Top;
			if (PaintingsText.Parent == null)
			{
				PaintingsText.Y = -9f;
			}
			else
			{
				PaintingsText.RelativeY = -9f;
			}
			if (PaintingsText.Parent == null)
			{
				PaintingsText.Z = 0.01f;
			}
			else
			{
				PaintingsText.RelativeZ = 0.01f;
			}
			PaintingsText.Text = "Childe Hassam - Bridge over the stour\nGerda Wallander - Barplockande barn en sommardag\nJohn Reinhard Weguelin - Mermaid (1911)\nTurner - The Slave Ship\nWidder Dunavecse 1939";
			PaintingsText.FontSize = 9;
			PaintingsText.Red = 1f;
			PaintingsText.Green = 1f;
			PaintingsText.Blue = 1f;
			PaintingsText.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Center;
			PaintingsText.VerticalAlignment = FlatRedBall.Graphics.VerticalAlignment.Top;
			if (SoundEffectsLabel.Parent == null)
			{
				SoundEffectsLabel.Y = -117f;
			}
			else
			{
				SoundEffectsLabel.RelativeY = -117f;
			}
			if (SoundEffectsLabel.Parent == null)
			{
				SoundEffectsLabel.Z = 0.01f;
			}
			else
			{
				SoundEffectsLabel.RelativeZ = 0.01f;
			}
			SoundEffectsLabel.Text = "Sound Effects";
			SoundEffectsLabel.FontSize = 9;
			SoundEffectsLabel.Red = 1f;
			SoundEffectsLabel.Green = 1f;
			SoundEffectsLabel.Blue = 0f;
			SoundEffectsLabel.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Center;
			SoundEffectsLabel.VerticalAlignment = FlatRedBall.Graphics.VerticalAlignment.Top;
			if (SoundEffectsText.Parent == null)
			{
				SoundEffectsText.Y = -135f;
			}
			else
			{
				SoundEffectsText.RelativeY = -135f;
			}
			if (SoundEffectsText.Parent == null)
			{
				SoundEffectsText.Z = 0.01f;
			}
			else
			{
				SoundEffectsText.RelativeZ = 0.01f;
			}
			SoundEffectsText.Text = "Caroline Ford - Small Scrape\nJoe Lamb - Sad Trombone\nMike Koenig - Ta Da\nNatalie Wendt - Bubble Gum Pop\nSebastian - Click2";
			SoundEffectsText.FontSize = 9;
			SoundEffectsText.Red = 1f;
			SoundEffectsText.Green = 1f;
			SoundEffectsText.Blue = 1f;
			SoundEffectsText.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Center;
			SoundEffectsText.VerticalAlignment = FlatRedBall.Graphics.VerticalAlignment.Top;
			if (MusicLabel.Parent == null)
			{
				MusicLabel.Y = -243f;
			}
			else
			{
				MusicLabel.RelativeY = -243f;
			}
			if (MusicLabel.Parent == null)
			{
				MusicLabel.Z = 0.01f;
			}
			else
			{
				MusicLabel.RelativeZ = 0.01f;
			}
			MusicLabel.Text = "Music";
			MusicLabel.FontSize = 9;
			MusicLabel.Red = 1f;
			MusicLabel.Green = 1f;
			MusicLabel.Blue = 0f;
			MusicLabel.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Center;
			MusicLabel.VerticalAlignment = FlatRedBall.Graphics.VerticalAlignment.Top;
			if (MusicText.Parent == null)
			{
				MusicText.Y = -261f;
			}
			else
			{
				MusicText.RelativeY = -261f;
			}
			if (MusicText.Parent == null)
			{
				MusicText.Z = 0.01f;
			}
			else
			{
				MusicText.RelativeZ = 0.01f;
			}
			MusicText.Text = "Jason Shaw at audionautix.com";
			MusicText.FontSize = 9;
			MusicText.Red = 1f;
			MusicText.Green = 1f;
			MusicText.Blue = 1f;
			MusicText.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Center;
			MusicText.VerticalAlignment = FlatRedBall.Graphics.VerticalAlignment.Top;
		}
		public virtual void ConvertToManuallyUpdated ()
		{
			BackgroundImage.ConvertToManuallyUpdated();
			BackButton.ConvertToManuallyUpdated();
			ProgrammingLabel.ConvertToManuallyUpdated();
			HeaderText.ConvertToManuallyUpdated();
			ProgrammingText.ConvertToManuallyUpdated();
			SupportLabel.ConvertToManuallyUpdated();
			SupportText.ConvertToManuallyUpdated();
			ArtworkLabel.ConvertToManuallyUpdated();
			ArtworkText.ConvertToManuallyUpdated();
			PaintingsLabel.ConvertToManuallyUpdated();
			PaintingsText.ConvertToManuallyUpdated();
			SoundEffectsLabel.ConvertToManuallyUpdated();
			SoundEffectsText.ConvertToManuallyUpdated();
			MusicLabel.ConvertToManuallyUpdated();
			MusicText.ConvertToManuallyUpdated();
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
			FrbTicTacToe.Entities.Background.LoadStaticContent(contentManagerName);
			FrbTicTacToe.Entities.Label.LoadStaticContent(contentManagerName);
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
