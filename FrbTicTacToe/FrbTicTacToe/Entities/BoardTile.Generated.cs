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
	public partial class BoardTile : PositionedObject, IDestroyable, IVisible, IWindow
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
		public enum VariableState
		{
			Uninitialized = 0, //This exists so that the first set call actually does something
			Unknown = 1, //This exists so that if the entity is actually a child entity and has set a child state, you will get this
			X = 2, 
			O = 3, 
			None = 4
		}
		protected int mCurrentState = 0;
		public Entities.BoardTile.VariableState CurrentState
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
					case  VariableState.X:
						PlayerSpriteTexture = TileXTexture;
						break;
					case  VariableState.O:
						PlayerSpriteTexture = TileOTexture;
						break;
					case  VariableState.None:
						PlayerSpriteTexture = TileNone;
						break;
				}
			}
		}
		static object mLockObject = new object();
		static List<string> mRegisteredUnloads = new List<string>();
		static List<string> LoadedContentManagers = new List<string>();
		protected static Microsoft.Xna.Framework.Graphics.Texture2D TileNone;
		protected static Microsoft.Xna.Framework.Graphics.Texture2D TileOTexture;
		protected static Microsoft.Xna.Framework.Graphics.Texture2D TileXTexture;
		
		private FlatRedBall.Sprite PlayerSprite;
		public Microsoft.Xna.Framework.Graphics.Texture2D PlayerSpriteTexture
		{
			get
			{
				return PlayerSprite.Texture;
			}
			set
			{
				PlayerSprite.Texture = value;
			}
		}
		public float PlayerSpriteHeight
		{
			get
			{
				return PlayerSprite.Height;
			}
			set
			{
				PlayerSprite.Height = value;
			}
		}
		public float PlayerSpriteWidth
		{
			get
			{
				return PlayerSprite.Width;
			}
			set
			{
				PlayerSprite.Width = value;
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

        public BoardTile()
            : this(FlatRedBall.Screens.ScreenManager.CurrentScreen.ContentManagerName, true)
        {

        }

        public BoardTile(string contentManagerName) :
            this(contentManagerName, true)
        {
        }


        public BoardTile(string contentManagerName, bool addToManagers) :
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
			PlayerSprite = new FlatRedBall.Sprite();
			PlayerSprite.Name = "PlayerSprite";
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
			SpriteManager.AddToLayer(PlayerSprite, LayerProvidedByContainer);
		}
		public virtual void AddToManagers (Layer layerToAddTo)
		{
			LayerProvidedByContainer = layerToAddTo;
			SpriteManager.AddPositionedObject(this);
			GuiManager.AddWindow(this);
			SpriteManager.AddToLayer(PlayerSprite, LayerProvidedByContainer);
			AddToManagersBottomUp(layerToAddTo);
			CustomInitialize();
		}

		public virtual void Activity()
		{
			// Generated Activity
			mIsPaused = false;
			
			CustomActivity();
			
			// After Custom Activity
		}

		public virtual void Destroy()
		{
			// Generated Destroy
			SpriteManager.RemovePositionedObject(this);
			GuiManager.RemoveWindow(this);
			
			if (PlayerSprite != null)
			{
				SpriteManager.RemoveSprite(PlayerSprite);
			}


			CustomDestroy();
		}

		// Generated Methods
		public virtual void PostInitialize ()
		{
			bool oldShapeManagerSuppressAdd = FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue;
			FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = true;
			if (PlayerSprite.Parent == null)
			{
				PlayerSprite.CopyAbsoluteToRelative();
				PlayerSprite.AttachTo(this, false);
			}
			PlayerSprite.TextureScale = 0f;
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
			if (PlayerSprite != null)
			{
				SpriteManager.RemoveSpriteOneWay(PlayerSprite);
			}
		}
		public virtual void AssignCustomVariables (bool callOnContainedElements)
		{
			if (callOnContainedElements)
			{
			}
			PlayerSprite.TextureScale = 0f;
			PlayerSpriteHeight = 2f;
			PlayerSpriteWidth = 2f;
			CurrentState = BoardTile.VariableState.None;
		}
		public virtual void ConvertToManuallyUpdated ()
		{
			this.ForceUpdateDependenciesDeep();
			SpriteManager.ConvertToManuallyUpdated(this);
			SpriteManager.ConvertToManuallyUpdated(PlayerSprite);
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
						FlatRedBallServices.GetContentManagerByName(ContentManagerName).AddUnloadMethod("BoardTileStaticUnload", UnloadStaticContent);
						mRegisteredUnloads.Add(ContentManagerName);
					}
				}
				if (!FlatRedBallServices.IsLoaded<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/boardtile/tilenone.png", ContentManagerName))
				{
					registerUnload = true;
				}
				TileNone = FlatRedBallServices.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/boardtile/tilenone.png", ContentManagerName);
				if (!FlatRedBallServices.IsLoaded<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/boardtile/tileotexture.png", ContentManagerName))
				{
					registerUnload = true;
				}
				TileOTexture = FlatRedBallServices.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/boardtile/tileotexture.png", ContentManagerName);
				if (!FlatRedBallServices.IsLoaded<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/boardtile/tilextexture.png", ContentManagerName))
				{
					registerUnload = true;
				}
				TileXTexture = FlatRedBallServices.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/boardtile/tilextexture.png", ContentManagerName);
			}
			if (registerUnload && ContentManagerName != FlatRedBallServices.GlobalContentManager)
			{
				lock (mLockObject)
				{
					if (!mRegisteredUnloads.Contains(ContentManagerName) && ContentManagerName != FlatRedBallServices.GlobalContentManager)
					{
						FlatRedBallServices.GetContentManagerByName(ContentManagerName).AddUnloadMethod("BoardTileStaticUnload", UnloadStaticContent);
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
				if (TileNone != null)
				{
					TileNone= null;
				}
				if (TileOTexture != null)
				{
					TileOTexture= null;
				}
				if (TileXTexture != null)
				{
					TileXTexture= null;
				}
			}
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
				case  VariableState.X:
					break;
				case  VariableState.O:
					break;
				case  VariableState.None:
					break;
			}
			var instruction = new FlatRedBall.Instructions.DelegateInstruction<VariableState>(StopStateInterpolation, stateToInterpolateTo);
			instruction.TimeToExecute = FlatRedBall.TimeManager.CurrentTime + secondsToTake;
			this.Instructions.Add(instruction);
			return instruction;
		}
		public void StopStateInterpolation (VariableState stateToStop)
		{
			switch(stateToStop)
			{
				case  VariableState.X:
					break;
				case  VariableState.O:
					break;
				case  VariableState.None:
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
			switch(firstState)
			{
				case  VariableState.X:
					if (interpolationValue < 1)
					{
						this.PlayerSpriteTexture = TileXTexture;
					}
					break;
				case  VariableState.O:
					if (interpolationValue < 1)
					{
						this.PlayerSpriteTexture = TileOTexture;
					}
					break;
				case  VariableState.None:
					if (interpolationValue < 1)
					{
						this.PlayerSpriteTexture = TileNone;
					}
					break;
			}
			switch(secondState)
			{
				case  VariableState.X:
					if (interpolationValue >= 1)
					{
						this.PlayerSpriteTexture = TileXTexture;
					}
					break;
				case  VariableState.O:
					if (interpolationValue >= 1)
					{
						this.PlayerSpriteTexture = TileOTexture;
					}
					break;
				case  VariableState.None:
					if (interpolationValue >= 1)
					{
						this.PlayerSpriteTexture = TileNone;
					}
					break;
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
		public static void PreloadStateContent (VariableState state, string contentManagerName)
		{
			ContentManagerName = contentManagerName;
			switch(state)
			{
				case  VariableState.X:
					{
						object throwaway = TileXTexture;
					}
					break;
				case  VariableState.O:
					{
						object throwaway = TileOTexture;
					}
					break;
				case  VariableState.None:
					{
						object throwaway = TileNone;
					}
					break;
			}
		}
		[System.Obsolete("Use GetFile instead")]
		public static object GetStaticMember (string memberName)
		{
			switch(memberName)
			{
				case  "TileNone":
					return TileNone;
				case  "TileOTexture":
					return TileOTexture;
				case  "TileXTexture":
					return TileXTexture;
			}
			return null;
		}
		public static object GetFile (string memberName)
		{
			switch(memberName)
			{
				case  "TileNone":
					return TileNone;
				case  "TileOTexture":
					return TileOTexture;
				case  "TileXTexture":
					return TileXTexture;
			}
			return null;
		}
		object GetMember (string memberName)
		{
			switch(memberName)
			{
				case  "TileNone":
					return TileNone;
				case  "TileOTexture":
					return TileOTexture;
				case  "TileXTexture":
					return TileXTexture;
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
			if (PlayerSprite.Alpha != 0 && PlayerSprite.AbsoluteVisible && cursor.IsOn3D(PlayerSprite, LayerProvidedByContainer))
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
			FlatRedBall.Instructions.InstructionManager.IgnorePausingFor(PlayerSprite);
		}
		public virtual void MoveToLayer (Layer layerToMoveTo)
		{
			if (LayerProvidedByContainer != null)
			{
				LayerProvidedByContainer.Remove(PlayerSprite);
			}
			SpriteManager.AddToLayer(PlayerSprite, layerToMoveTo);
			LayerProvidedByContainer = layerToMoveTo;
		}

    }
	
	
		public static class BoardTileExtensionMethods
	{
		public static void SetVisible (this PositionedObjectList<BoardTile> list, bool value)
		{
			int count = list.Count;
			for (int i = 0; i < count; i++)
			{
				list[i].Visible = value;
			}
		}
	}

	
}
