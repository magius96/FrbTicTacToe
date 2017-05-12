#if ANDROID
#define REQUIRES_PRIMARY_THREAD_LOADING
#endif

using BitmapFont = FlatRedBall.Graphics.BitmapFont;
using Cursor = FlatRedBall.Gui.Cursor;
using GuiManager = FlatRedBall.Gui.GuiManager;
// Generated Usings
using FrbTicTacToe.Screens;
using FlatRedBall.Graphics;
using FlatRedBall.Math;
using FlatRedBall.Gui;
using FrbTicTacToe.Entities;
using FlatRedBall;
using FlatRedBall.Screens;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

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
#endif

#if FRB_XNA && !MONODROID
using Model = Microsoft.Xna.Framework.Graphics.Model;
#endif

namespace FrbTicTacToe.Entities
{
	public partial class VictoryPopup : PositionedObject, IDestroyable, IVisible, IWindow
	{
        // This is made global so that static lazy-loaded content can access it.
        public static string ContentManagerName
        {
            get;
            set;
        }

		// Generated Fields
		#if DEBUG
		static bool HasBeenLoadedWithGlobalContentManager = false;
		#endif
		static object mLockObject = new object();
		static List<string> mRegisteredUnloads = new List<string>();
		static List<string> LoadedContentManagers = new List<string>();
		protected static Microsoft.Xna.Framework.Graphics.Texture2D PopupBackgroundTexture;
		
		private FrbTicTacToe.Entities.Label VictoryTextLabel;
		private FrbTicTacToe.Entities.Label PlayAgainText;
		private FrbTicTacToe.Entities.Label NoButton;
		private FrbTicTacToe.Entities.Label YesButton;
		private FlatRedBall.Sprite BackgroundSprite;
		public event EventHandler BeforeWinnerSet;
		public event EventHandler AfterWinnerSet;
		string mWinner;
		public string Winner
		{
			set
			{
				if (BeforeWinnerSet != null)
				{
					BeforeWinnerSet(this, null);
				}
				mWinner = value;
				if (AfterWinnerSet != null)
				{
					AfterWinnerSet(this, null);
				}
			}
			get
			{
				return mWinner;
			}
		}
		public event EventHandler BeforeVisibleSet;
		public event EventHandler AfterVisibleSet;
		protected bool mVisible = true;
		public virtual bool Visible
		{
			get
			{
				return mVisible;
			}
			set
			{
				if (BeforeVisibleSet != null)
				{
					BeforeVisibleSet(this, null);
				}
				mVisible = value;
				if (AfterVisibleSet != null)
				{
					AfterVisibleSet(this, null);
				}
			}
		}
		public bool IgnoresParentVisibility { get; set; }
		public bool AbsoluteVisible
		{
			get
			{
				return Visible && (Parent == null || IgnoresParentVisibility || Parent is IVisible == false || (Parent as IVisible).AbsoluteVisible);
			}
		}
		IVisible IVisible.Parent
		{
			get
			{
				if (this.Parent != null && this.Parent is IVisible)
				{
					return this.Parent as IVisible;
				}
				else
				{
					return null;
				}
			}
		}
		protected Layer LayerProvidedByContainer = null;

        public VictoryPopup()
            : this(FlatRedBall.Screens.ScreenManager.CurrentScreen.ContentManagerName, true)
        {

        }

        public VictoryPopup(string contentManagerName) :
            this(contentManagerName, true)
        {
        }


        public VictoryPopup(string contentManagerName, bool addToManagers) :
			base()
		{
			// Don't delete this:
            ContentManagerName = contentManagerName;
            InitializeEntity(addToManagers);

		}

		protected virtual void InitializeEntity(bool addToManagers)
		{
			// Generated Initialize
			LoadStaticContent(ContentManagerName);
			VictoryTextLabel = new FrbTicTacToe.Entities.Label(ContentManagerName, false);
			VictoryTextLabel.Name = "VictoryTextLabel";
			PlayAgainText = new FrbTicTacToe.Entities.Label(ContentManagerName, false);
			PlayAgainText.Name = "PlayAgainText";
			NoButton = new FrbTicTacToe.Entities.Label(ContentManagerName, false);
			NoButton.Name = "NoButton";
			YesButton = new FrbTicTacToe.Entities.Label(ContentManagerName, false);
			YesButton.Name = "YesButton";
			BackgroundSprite = new FlatRedBall.Sprite();
			BackgroundSprite.Name = "BackgroundSprite";
			this.Click += CallLosePush;
			this.RollOff += CallLosePush;
			
			PostInitialize();
			if (addToManagers)
			{
				AddToManagers(null);
			}


		}

// Generated AddToManagers
		public virtual void ReAddToManagers (Layer layerToAddTo)
		{
			LayerProvidedByContainer = layerToAddTo;
			SpriteManager.AddPositionedObject(this);
			GuiManager.AddWindow(this);
			VictoryTextLabel.ReAddToManagers(LayerProvidedByContainer);
			PlayAgainText.ReAddToManagers(LayerProvidedByContainer);
			NoButton.ReAddToManagers(LayerProvidedByContainer);
			YesButton.ReAddToManagers(LayerProvidedByContainer);
			SpriteManager.AddToLayer(BackgroundSprite, LayerProvidedByContainer);
		}
		public virtual void AddToManagers (Layer layerToAddTo)
		{
			LayerProvidedByContainer = layerToAddTo;
			SpriteManager.AddPositionedObject(this);
			GuiManager.AddWindow(this);
			VictoryTextLabel.AddToManagers(LayerProvidedByContainer);
			PlayAgainText.AddToManagers(LayerProvidedByContainer);
			NoButton.AddToManagers(LayerProvidedByContainer);
			YesButton.AddToManagers(LayerProvidedByContainer);
			SpriteManager.AddToLayer(BackgroundSprite, LayerProvidedByContainer);
			AddToManagersBottomUp(layerToAddTo);
			CustomInitialize();
		}

		public virtual void Activity()
		{
			// Generated Activity
			mIsPaused = false;
			
			VictoryTextLabel.Activity();
			PlayAgainText.Activity();
			NoButton.Activity();
			YesButton.Activity();
			CustomActivity();
			
			// After Custom Activity
		}

		public virtual void Destroy()
		{
			// Generated Destroy
			SpriteManager.RemovePositionedObject(this);
			GuiManager.RemoveWindow(this);
			
			if (VictoryTextLabel != null)
			{
				VictoryTextLabel.Destroy();
				VictoryTextLabel.Detach();
			}
			if (PlayAgainText != null)
			{
				PlayAgainText.Destroy();
				PlayAgainText.Detach();
			}
			if (NoButton != null)
			{
				NoButton.Destroy();
				NoButton.Detach();
			}
			if (YesButton != null)
			{
				YesButton.Destroy();
				YesButton.Detach();
			}
			if (BackgroundSprite != null)
			{
				SpriteManager.RemoveSprite(BackgroundSprite);
			}


			CustomDestroy();
		}

		// Generated Methods
		public virtual void PostInitialize ()
		{
			bool oldShapeManagerSuppressAdd = FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue;
			FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = true;
			this.AfterWinnerSet += OnAfterwinnerSet;
			if (VictoryTextLabel.Parent == null)
			{
				VictoryTextLabel.CopyAbsoluteToRelative();
				VictoryTextLabel.AttachTo(this, false);
			}
			if (VictoryTextLabel.Parent == null)
			{
				VictoryTextLabel.X = -170f;
			}
			else
			{
				VictoryTextLabel.RelativeX = -170f;
			}
			if (VictoryTextLabel.Parent == null)
			{
				VictoryTextLabel.Y = 30f;
			}
			else
			{
				VictoryTextLabel.RelativeY = 30f;
			}
			VictoryTextLabel.Text = "Player # Won.";
			VictoryTextLabel.FontSize = 24;
			VictoryTextLabel.Red = 1f;
			VictoryTextLabel.Green = 1f;
			if (PlayAgainText.Parent == null)
			{
				PlayAgainText.CopyAbsoluteToRelative();
				PlayAgainText.AttachTo(this, false);
			}
			if (PlayAgainText.Parent == null)
			{
				PlayAgainText.X = -170f;
			}
			else
			{
				PlayAgainText.RelativeX = -170f;
			}
			if (PlayAgainText.Parent == null)
			{
				PlayAgainText.Y = -5f;
			}
			else
			{
				PlayAgainText.RelativeY = -5f;
			}
			PlayAgainText.Text = "Would you like to play again?";
			PlayAgainText.FontSize = 12;
			PlayAgainText.Red = 1f;
			PlayAgainText.Green = 1f;
			PlayAgainText.Blue = 1f;
			if (NoButton.Parent == null)
			{
				NoButton.CopyAbsoluteToRelative();
				NoButton.AttachTo(this, false);
			}
			if (NoButton.Parent == null)
			{
				NoButton.X = 110f;
			}
			else
			{
				NoButton.RelativeX = 110f;
			}
			if (NoButton.Parent == null)
			{
				NoButton.Y = -50f;
			}
			else
			{
				NoButton.RelativeY = -50f;
			}
			if (NoButton.Parent == null)
			{
				NoButton.Z = 1f;
			}
			else
			{
				NoButton.RelativeZ = 1f;
			}
			NoButton.Text = "No";
			NoButton.FontSize = 16;
			NoButton.Red = 1f;
			NoButton.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Center;
			if (YesButton.Parent == null)
			{
				YesButton.CopyAbsoluteToRelative();
				YesButton.AttachTo(this, false);
			}
			if (YesButton.Parent == null)
			{
				YesButton.X = -130f;
			}
			else
			{
				YesButton.RelativeX = -130f;
			}
			if (YesButton.Parent == null)
			{
				YesButton.Y = -50f;
			}
			else
			{
				YesButton.RelativeY = -50f;
			}
			if (YesButton.Parent == null)
			{
				YesButton.Z = 1f;
			}
			else
			{
				YesButton.RelativeZ = 1f;
			}
			YesButton.Text = "Yes";
			YesButton.FontSize = 16;
			YesButton.Green = 1f;
			YesButton.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Center;
			if (BackgroundSprite.Parent == null)
			{
				BackgroundSprite.CopyAbsoluteToRelative();
				BackgroundSprite.AttachTo(this, false);
			}
			BackgroundSprite.Texture = PopupBackgroundTexture;
			BackgroundSprite.Height = 200f;
			BackgroundSprite.TextureScale = 0f;
			BackgroundSprite.Width = 430f;
			if (BackgroundSprite.Parent == null)
			{
				BackgroundSprite.X = -10f;
			}
			else
			{
				BackgroundSprite.RelativeX = -10f;
			}
			if (BackgroundSprite.Parent == null)
			{
				BackgroundSprite.Z = -1f;
			}
			else
			{
				BackgroundSprite.RelativeZ = -1f;
			}
			FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = oldShapeManagerSuppressAdd;
		}
		public virtual void AddToManagersBottomUp (Layer layerToAddTo)
		{
			AssignCustomVariables(false);
		}
		public virtual void RemoveFromManagers ()
		{
			SpriteManager.ConvertToManuallyUpdated(this);
			GuiManager.RemoveWindow(this);
			VictoryTextLabel.RemoveFromManagers();
			PlayAgainText.RemoveFromManagers();
			NoButton.RemoveFromManagers();
			YesButton.RemoveFromManagers();
			if (BackgroundSprite != null)
			{
				SpriteManager.RemoveSpriteOneWay(BackgroundSprite);
			}
		}
		public virtual void AssignCustomVariables (bool callOnContainedElements)
		{
			if (callOnContainedElements)
			{
				VictoryTextLabel.AssignCustomVariables(true);
				PlayAgainText.AssignCustomVariables(true);
				NoButton.AssignCustomVariables(true);
				YesButton.AssignCustomVariables(true);
			}
			if (VictoryTextLabel.Parent == null)
			{
				VictoryTextLabel.X = -170f;
			}
			else
			{
				VictoryTextLabel.RelativeX = -170f;
			}
			if (VictoryTextLabel.Parent == null)
			{
				VictoryTextLabel.Y = 30f;
			}
			else
			{
				VictoryTextLabel.RelativeY = 30f;
			}
			VictoryTextLabel.Text = "Player # Won.";
			VictoryTextLabel.FontSize = 24;
			VictoryTextLabel.Red = 1f;
			VictoryTextLabel.Green = 1f;
			if (PlayAgainText.Parent == null)
			{
				PlayAgainText.X = -170f;
			}
			else
			{
				PlayAgainText.RelativeX = -170f;
			}
			if (PlayAgainText.Parent == null)
			{
				PlayAgainText.Y = -5f;
			}
			else
			{
				PlayAgainText.RelativeY = -5f;
			}
			PlayAgainText.Text = "Would you like to play again?";
			PlayAgainText.FontSize = 12;
			PlayAgainText.Red = 1f;
			PlayAgainText.Green = 1f;
			PlayAgainText.Blue = 1f;
			if (NoButton.Parent == null)
			{
				NoButton.X = 110f;
			}
			else
			{
				NoButton.RelativeX = 110f;
			}
			if (NoButton.Parent == null)
			{
				NoButton.Y = -50f;
			}
			else
			{
				NoButton.RelativeY = -50f;
			}
			if (NoButton.Parent == null)
			{
				NoButton.Z = 1f;
			}
			else
			{
				NoButton.RelativeZ = 1f;
			}
			NoButton.Text = "No";
			NoButton.FontSize = 16;
			NoButton.Red = 1f;
			NoButton.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Center;
			if (YesButton.Parent == null)
			{
				YesButton.X = -130f;
			}
			else
			{
				YesButton.RelativeX = -130f;
			}
			if (YesButton.Parent == null)
			{
				YesButton.Y = -50f;
			}
			else
			{
				YesButton.RelativeY = -50f;
			}
			if (YesButton.Parent == null)
			{
				YesButton.Z = 1f;
			}
			else
			{
				YesButton.RelativeZ = 1f;
			}
			YesButton.Text = "Yes";
			YesButton.FontSize = 16;
			YesButton.Green = 1f;
			YesButton.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Center;
			BackgroundSprite.Texture = PopupBackgroundTexture;
			BackgroundSprite.Height = 200f;
			BackgroundSprite.TextureScale = 0f;
			BackgroundSprite.Width = 430f;
			if (BackgroundSprite.Parent == null)
			{
				BackgroundSprite.X = -10f;
			}
			else
			{
				BackgroundSprite.RelativeX = -10f;
			}
			if (BackgroundSprite.Parent == null)
			{
				BackgroundSprite.Z = -1f;
			}
			else
			{
				BackgroundSprite.RelativeZ = -1f;
			}
		}
		public virtual void ConvertToManuallyUpdated ()
		{
			this.ForceUpdateDependenciesDeep();
			SpriteManager.ConvertToManuallyUpdated(this);
			VictoryTextLabel.ConvertToManuallyUpdated();
			PlayAgainText.ConvertToManuallyUpdated();
			NoButton.ConvertToManuallyUpdated();
			YesButton.ConvertToManuallyUpdated();
			SpriteManager.ConvertToManuallyUpdated(BackgroundSprite);
		}
		public static void LoadStaticContent (string contentManagerName)
		{
			if (string.IsNullOrEmpty(contentManagerName))
			{
				throw new ArgumentException("contentManagerName cannot be empty or null");
			}
			ContentManagerName = contentManagerName;
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
			bool registerUnload = false;
			if (LoadedContentManagers.Contains(contentManagerName) == false)
			{
				LoadedContentManagers.Add(contentManagerName);
				lock (mLockObject)
				{
					if (!mRegisteredUnloads.Contains(ContentManagerName) && ContentManagerName != FlatRedBallServices.GlobalContentManager)
					{
						FlatRedBallServices.GetContentManagerByName(ContentManagerName).AddUnloadMethod("VictoryPopupStaticUnload", UnloadStaticContent);
						mRegisteredUnloads.Add(ContentManagerName);
					}
				}
				if (!FlatRedBallServices.IsLoaded<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/victorypopup/popupbackgroundtexture.png", ContentManagerName))
				{
					registerUnload = true;
				}
				PopupBackgroundTexture = FlatRedBallServices.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/victorypopup/popupbackgroundtexture.png", ContentManagerName);
			}
			FrbTicTacToe.Entities.Label.LoadStaticContent(contentManagerName);
			if (registerUnload && ContentManagerName != FlatRedBallServices.GlobalContentManager)
			{
				lock (mLockObject)
				{
					if (!mRegisteredUnloads.Contains(ContentManagerName) && ContentManagerName != FlatRedBallServices.GlobalContentManager)
					{
						FlatRedBallServices.GetContentManagerByName(ContentManagerName).AddUnloadMethod("VictoryPopupStaticUnload", UnloadStaticContent);
						mRegisteredUnloads.Add(ContentManagerName);
					}
				}
			}
			CustomLoadStaticContent(contentManagerName);
		}
		public static void UnloadStaticContent ()
		{
			if (LoadedContentManagers.Count != 0)
			{
				LoadedContentManagers.RemoveAt(0);
				mRegisteredUnloads.RemoveAt(0);
			}
			if (LoadedContentManagers.Count == 0)
			{
				if (PopupBackgroundTexture != null)
				{
					PopupBackgroundTexture= null;
				}
			}
		}
		[System.Obsolete("Use GetFile instead")]
		public static object GetStaticMember (string memberName)
		{
			switch(memberName)
			{
				case  "PopupBackgroundTexture":
					return PopupBackgroundTexture;
			}
			return null;
		}
		public static object GetFile (string memberName)
		{
			switch(memberName)
			{
				case  "PopupBackgroundTexture":
					return PopupBackgroundTexture;
			}
			return null;
		}
		object GetMember (string memberName)
		{
			switch(memberName)
			{
				case  "PopupBackgroundTexture":
					return PopupBackgroundTexture;
			}
			return null;
		}
		
    // DELEGATE START HERE
    

        #region IWindow methods and properties

        public event WindowEvent Click;
		public event WindowEvent ClickNoSlide;
		public event WindowEvent SlideOnClick;
        public event WindowEvent Push;
		public event WindowEvent DragOver;
		public event WindowEvent RollOn;
		public event WindowEvent RollOff;
		public event WindowEvent RollOver;
		public event WindowEvent LosePush;

        System.Collections.ObjectModel.ReadOnlyCollection<IWindow> IWindow.Children
        {
            get { throw new NotImplementedException(); }
        }

        bool mEnabled = true;


		bool IVisible.Visible
        {
            get
            {
                return this.AbsoluteVisible;
            }
			set
			{
				this.Visible = value;
			}
        }
		
		public bool MovesWhenGrabbed
        {
            get;
            set;
        }

        bool IWindow.GuiManagerDrawn
        {
            get
            {
                return false;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool IgnoredByCursor
        {
            get
            {
                return false;
            }
            set
            {
                throw new NotImplementedException();
            }
        }



        public System.Collections.ObjectModel.ReadOnlyCollection<IWindow> FloatingChildren
        {
            get { return null; }
        }

        public FlatRedBall.ManagedSpriteGroups.SpriteFrame SpriteFrame
        {
            get
            {
                return null;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        float IWindow.WorldUnitX
        {
            get
            {
                return Position.X;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        float IWindow.WorldUnitY
        {
            get
            {
                return Position.Y;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        float IWindow.WorldUnitRelativeX
        {
            get
            {
                return RelativePosition.X;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        float IWindow.WorldUnitRelativeY
        {
            get
            {
                return RelativePosition.Y;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        float IWindow.ScaleX
        {
            get;
            set;
        }

        float IWindow.ScaleY
        {
            get;
            set;
        }

        IWindow IWindow.Parent
        {
            get
            {
                return null;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        void IWindow.Activity(Camera camera)
        {

        }

        void IWindow.CallRollOff()
        {
			if(RollOff != null)
			{
				RollOff(this);
			}
        }

        void IWindow.CallRollOn()
        {
			if(RollOn != null)
			{
				RollOn(this);
			}
        }

		void IWindow.CallRollOver()
		{
			if(RollOver != null)
			{
				RollOver(this);
			}	
		}
		
		void CallLosePush(IWindow instance)
		{
			if(LosePush != null)
			{
				LosePush(instance);
			}
		}

        void IWindow.CloseWindow()
        {
            throw new NotImplementedException();
        }

		void IWindow.CallClick()
		{
			if(Click != null)
			{
				Click(this);
			}
		}

        public bool GetParentVisibility()
        {
            throw new NotImplementedException();
        }

        bool IWindow.IsPointOnWindow(float x, float y)
        {
            throw new NotImplementedException();
        }

        public void OnDragging()
        {
			if(DragOver != null)
			{
				DragOver(this);
			}
        }

        public void OnResize()
        {
            throw new NotImplementedException();
        }

        public void OnResizeEnd()
        {
            throw new NotImplementedException();
        }

        public void OnLosingFocus()
        {
            // Do nothing
        }

        public bool OverlapsWindow(IWindow otherWindow)
        {
            return false; // we don't care about this.
        }

        public void SetScaleTL(float newScaleX, float newScaleY)
        {
            throw new NotImplementedException();
        }

        public void SetScaleTL(float newScaleX, float newScaleY, bool keepTopLeftStatic)
        {
            throw new NotImplementedException();
        }

        public virtual void TestCollision(FlatRedBall.Gui.Cursor cursor)
        {
            if (HasCursorOver(cursor))
            {
                cursor.WindowOver = this;

                if (cursor.PrimaryPush)
                {

                    cursor.WindowPushed = this;

                    if (Push != null)
                        Push(this);


					cursor.GrabWindow(this);

                }

                if (cursor.PrimaryClick) // both pushing and clicking can occur in one frame because of buffered input
                {
                    if (cursor.WindowPushed == this)
                    {
                        if (Click != null)
                        {
                            Click(this);
                        }
						if(cursor.PrimaryClickNoSlide && ClickNoSlide != null)
						{
							ClickNoSlide(this);
						}

                        // if (cursor.PrimaryDoubleClick && DoubleClick != null)
                        //   DoubleClick(this);
                    }
					else
					{
						if(SlideOnClick != null)
						{
							SlideOnClick(this);
						}
					}
                }
            }
        }

        void IWindow.UpdateDependencies()
        {
            // do nothing
        }

        Layer ILayered.Layer
        {
            get
            {
				return LayerProvidedByContainer;
            }
        }


        #endregion

		bool IWindow.Enabled
		{
			get
			{
				return mEnabled;
			}
			set
			{
				mEnabled = value;
			}
		}
		public virtual bool HasCursorOver (FlatRedBall.Gui.Cursor cursor)
		{
			if (mIsPaused)
			{
				return false;
			}
			if (!AbsoluteVisible)
			{
				return false;
			}
			if (LayerProvidedByContainer != null && LayerProvidedByContainer.Visible == false)
			{
				return false;
			}
			if (!cursor.IsOn(LayerProvidedByContainer))
			{
				return false;
			}
			if (VictoryTextLabel.HasCursorOver(cursor))
			{
				return true;
			}
			if (PlayAgainText.HasCursorOver(cursor))
			{
				return true;
			}
			if (NoButton.HasCursorOver(cursor))
			{
				return true;
			}
			if (YesButton.HasCursorOver(cursor))
			{
				return true;
			}
			if (BackgroundSprite.Alpha != 0 && BackgroundSprite.AbsoluteVisible && cursor.IsOn3D(BackgroundSprite, LayerProvidedByContainer))
			{
				return true;
			}
			return false;
		}
		public virtual bool WasClickedThisFrame (FlatRedBall.Gui.Cursor cursor)
		{
			return cursor.PrimaryClick && HasCursorOver(cursor);
		}
		protected bool mIsPaused;
		public override void Pause (FlatRedBall.Instructions.InstructionList instructions)
		{
			base.Pause(instructions);
			mIsPaused = true;
		}
		public virtual void SetToIgnorePausing ()
		{
			FlatRedBall.Instructions.InstructionManager.IgnorePausingFor(this);
			VictoryTextLabel.SetToIgnorePausing();
			PlayAgainText.SetToIgnorePausing();
			NoButton.SetToIgnorePausing();
			YesButton.SetToIgnorePausing();
			FlatRedBall.Instructions.InstructionManager.IgnorePausingFor(BackgroundSprite);
		}
		public virtual void MoveToLayer (Layer layerToMoveTo)
		{
			VictoryTextLabel.MoveToLayer(layerToMoveTo);
			PlayAgainText.MoveToLayer(layerToMoveTo);
			NoButton.MoveToLayer(layerToMoveTo);
			YesButton.MoveToLayer(layerToMoveTo);
			if (LayerProvidedByContainer != null)
			{
				LayerProvidedByContainer.Remove(BackgroundSprite);
			}
			SpriteManager.AddToLayer(BackgroundSprite, layerToMoveTo);
			LayerProvidedByContainer = layerToMoveTo;
		}

    }
	
	
		public static class VictoryPopupExtensionMethods
	{
		public static void SetVisible (this PositionedObjectList<VictoryPopup> list, bool value)
		{
			int count = list.Count;
			for (int i = 0; i < count; i++)
			{
				list[i].Visible = value;
			}
		}
	}

	
}
