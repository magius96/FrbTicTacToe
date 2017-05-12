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
	public partial class Icon : PositionedObject, IDestroyable, IVisible, IWindow
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
		public enum PlayerType
		{
			Uninitialized = 0, //This exists so that the first set call actually does something
			Unknown = 1, //This exists so that if the entity is actually a child entity and has set a child state, you will get this
			Computer = 2, 
			Human = 3
		}
		protected int mCurrentPlayerTypeState = 0;
		public Entities.Icon.PlayerType CurrentPlayerTypeState
		{
			get
			{
				if (Enum.IsDefined(typeof(PlayerType), mCurrentPlayerTypeState))
				{
					return (PlayerType)mCurrentPlayerTypeState;
				}
				else
				{
					return PlayerType.Unknown;
				}
			}
			set
			{
				mCurrentPlayerTypeState = (int)value;
				switch(CurrentPlayerTypeState)
				{
					case  PlayerType.Uninitialized:
						break;
					case  PlayerType.Unknown:
						break;
					case  PlayerType.Computer:
						IconSpriteTexture = ComputerTexture;
						break;
					case  PlayerType.Human:
						IconSpriteTexture = HumanTexture;
						break;
				}
			}
		}
		public enum IconState
		{
			Uninitialized = 0, //This exists so that the first set call actually does something
			Unknown = 1, //This exists so that if the entity is actually a child entity and has set a child state, you will get this
			Selected = 2, 
			NotSelected = 3
		}
		protected int mCurrentIconStateState = 0;
		public Entities.Icon.IconState CurrentIconStateState
		{
			get
			{
				if (Enum.IsDefined(typeof(IconState), mCurrentIconStateState))
				{
					return (IconState)mCurrentIconStateState;
				}
				else
				{
					return IconState.Unknown;
				}
			}
			set
			{
				mCurrentIconStateState = (int)value;
				switch(CurrentIconStateState)
				{
					case  IconState.Uninitialized:
						break;
					case  IconState.Unknown:
						break;
					case  IconState.Selected:
						Intensity = 1f;
						HighlightSpriteVisible = true;
						break;
					case  IconState.NotSelected:
						Intensity = 0.5f;
						HighlightSpriteVisible = false;
						break;
				}
			}
		}
		static object mLockObject = new object();
		static List<string> mRegisteredUnloads = new List<string>();
		static List<string> LoadedContentManagers = new List<string>();
		protected static Microsoft.Xna.Framework.Graphics.Texture2D HumanTexture;
		protected static Microsoft.Xna.Framework.Graphics.Texture2D ComputerTexture;
		protected static Microsoft.Xna.Framework.Graphics.Texture2D IconHighlight;
		
		private FlatRedBall.Sprite IconSprite;
		private FlatRedBall.Sprite HighlightSprite;
		public Microsoft.Xna.Framework.Graphics.Texture2D IconSpriteTexture
		{
			get
			{
				return IconSprite.Texture;
			}
			set
			{
				IconSprite.Texture = value;
			}
		}
		public event EventHandler BeforeSizeSet;
		public event EventHandler AfterSizeSet;
		float mSize;
		public float Size
		{
			set
			{
				if (BeforeSizeSet != null)
				{
					BeforeSizeSet(this, null);
				}
				mSize = value;
				if (AfterSizeSet != null)
				{
					AfterSizeSet(this, null);
				}
			}
			get
			{
				return mSize;
			}
		}
		public event EventHandler BeforeIntensitySet;
		public event EventHandler AfterIntensitySet;
		float mIntensity = 0.75f;
		public float Intensity
		{
			set
			{
				if (BeforeIntensitySet != null)
				{
					BeforeIntensitySet(this, null);
				}
				mIntensity = value;
				if (AfterIntensitySet != null)
				{
					AfterIntensitySet(this, null);
				}
			}
			get
			{
				return mIntensity;
			}
		}
		public bool HighlightSpriteVisible
		{
			get
			{
				return HighlightSprite.Visible;
			}
			set
			{
				HighlightSprite.Visible = value;
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

        public Icon()
            : this(FlatRedBall.Screens.ScreenManager.CurrentScreen.ContentManagerName, true)
        {

        }

        public Icon(string contentManagerName) :
            this(contentManagerName, true)
        {
        }


        public Icon(string contentManagerName, bool addToManagers) :
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
			IconSprite = new FlatRedBall.Sprite();
			IconSprite.Name = "IconSprite";
			HighlightSprite = new FlatRedBall.Sprite();
			HighlightSprite.Name = "HighlightSprite";
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
			SpriteManager.AddToLayer(IconSprite, LayerProvidedByContainer);
			SpriteManager.AddToLayer(HighlightSprite, LayerProvidedByContainer);
		}
		public virtual void AddToManagers (Layer layerToAddTo)
		{
			LayerProvidedByContainer = layerToAddTo;
			SpriteManager.AddPositionedObject(this);
			GuiManager.AddWindow(this);
			SpriteManager.AddToLayer(IconSprite, LayerProvidedByContainer);
			SpriteManager.AddToLayer(HighlightSprite, LayerProvidedByContainer);
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
			
			if (IconSprite != null)
			{
				SpriteManager.RemoveSprite(IconSprite);
			}
			if (HighlightSprite != null)
			{
				SpriteManager.RemoveSprite(HighlightSprite);
			}


			CustomDestroy();
		}

		// Generated Methods
		public virtual void PostInitialize ()
		{
			bool oldShapeManagerSuppressAdd = FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue;
			FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = true;
			this.AfterSizeSet += OnAfterSizeSet;
			this.AfterIntensitySet += OnAfterIntensitySet;
			if (IconSprite.Parent == null)
			{
				IconSprite.CopyAbsoluteToRelative();
				IconSprite.AttachTo(this, false);
			}
			IconSprite.TextureScale = 1f;
			#if FRB_MDX
			IconSprite.ColorOperation = Microsoft.DirectX.Direct3D.TextureOperation.Subtract;
			#else
			IconSprite.ColorOperation = FlatRedBall.Graphics.ColorOperation.Subtract;
			#endif
			if (HighlightSprite.Parent == null)
			{
				HighlightSprite.CopyAbsoluteToRelative();
				HighlightSprite.AttachTo(this, false);
			}
			HighlightSprite.Texture = IconHighlight;
			HighlightSprite.TextureScale = 1f;
			if (HighlightSprite.Parent == null)
			{
				HighlightSprite.Z = -0.01f;
			}
			else
			{
				HighlightSprite.RelativeZ = -0.01f;
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
			if (IconSprite != null)
			{
				SpriteManager.RemoveSpriteOneWay(IconSprite);
			}
			if (HighlightSprite != null)
			{
				SpriteManager.RemoveSpriteOneWay(HighlightSprite);
			}
		}
		public virtual void AssignCustomVariables (bool callOnContainedElements)
		{
			if (callOnContainedElements)
			{
			}
			IconSprite.TextureScale = 1f;
			#if FRB_MDX
			IconSprite.ColorOperation = Microsoft.DirectX.Direct3D.TextureOperation.Subtract;
			#else
			IconSprite.ColorOperation = FlatRedBall.Graphics.ColorOperation.Subtract;
			#endif
			HighlightSprite.Texture = IconHighlight;
			HighlightSprite.TextureScale = 1f;
			if (HighlightSprite.Parent == null)
			{
				HighlightSprite.Z = -0.01f;
			}
			else
			{
				HighlightSprite.RelativeZ = -0.01f;
			}
			CurrentPlayerTypeState = Icon.PlayerType.Human;
			CurrentIconStateState = Icon.IconState.NotSelected;
			Intensity = 0.75f;
			HighlightSpriteVisible = true;
		}
		public virtual void ConvertToManuallyUpdated ()
		{
			this.ForceUpdateDependenciesDeep();
			SpriteManager.ConvertToManuallyUpdated(this);
			SpriteManager.ConvertToManuallyUpdated(IconSprite);
			SpriteManager.ConvertToManuallyUpdated(HighlightSprite);
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
						FlatRedBallServices.GetContentManagerByName(ContentManagerName).AddUnloadMethod("IconStaticUnload", UnloadStaticContent);
						mRegisteredUnloads.Add(ContentManagerName);
					}
				}
				if (!FlatRedBallServices.IsLoaded<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/icon/humantexture.png", ContentManagerName))
				{
					registerUnload = true;
				}
				HumanTexture = FlatRedBallServices.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/icon/humantexture.png", ContentManagerName);
				if (!FlatRedBallServices.IsLoaded<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/icon/computertexture.png", ContentManagerName))
				{
					registerUnload = true;
				}
				ComputerTexture = FlatRedBallServices.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/icon/computertexture.png", ContentManagerName);
				if (!FlatRedBallServices.IsLoaded<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/icon/iconhighlight.png", ContentManagerName))
				{
					registerUnload = true;
				}
				IconHighlight = FlatRedBallServices.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/icon/iconhighlight.png", ContentManagerName);
			}
			if (registerUnload && ContentManagerName != FlatRedBallServices.GlobalContentManager)
			{
				lock (mLockObject)
				{
					if (!mRegisteredUnloads.Contains(ContentManagerName) && ContentManagerName != FlatRedBallServices.GlobalContentManager)
					{
						FlatRedBallServices.GetContentManagerByName(ContentManagerName).AddUnloadMethod("IconStaticUnload", UnloadStaticContent);
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
				if (HumanTexture != null)
				{
					HumanTexture= null;
				}
				if (ComputerTexture != null)
				{
					ComputerTexture= null;
				}
				if (IconHighlight != null)
				{
					IconHighlight= null;
				}
			}
		}
		public FlatRedBall.Instructions.Instruction InterpolateToState (PlayerType stateToInterpolateTo, double secondsToTake)
		{
			switch(stateToInterpolateTo)
			{
				case  PlayerType.Computer:
					break;
				case  PlayerType.Human:
					break;
			}
			var instruction = new FlatRedBall.Instructions.DelegateInstruction<PlayerType>(StopStateInterpolation, stateToInterpolateTo);
			instruction.TimeToExecute = FlatRedBall.TimeManager.CurrentTime + secondsToTake;
			this.Instructions.Add(instruction);
			return instruction;
		}
		public void StopStateInterpolation (PlayerType stateToStop)
		{
			switch(stateToStop)
			{
				case  PlayerType.Computer:
					break;
				case  PlayerType.Human:
					break;
			}
			CurrentPlayerTypeState = stateToStop;
		}
		public void InterpolateBetween (PlayerType firstState, PlayerType secondState, float interpolationValue)
		{
			#if DEBUG
			if (float.IsNaN(interpolationValue))
			{
				throw new Exception("interpolationValue cannot be NaN");
			}
			#endif
			switch(firstState)
			{
				case  PlayerType.Computer:
					if (interpolationValue < 1)
					{
						this.IconSpriteTexture = ComputerTexture;
					}
					break;
				case  PlayerType.Human:
					if (interpolationValue < 1)
					{
						this.IconSpriteTexture = HumanTexture;
					}
					break;
			}
			switch(secondState)
			{
				case  PlayerType.Computer:
					if (interpolationValue >= 1)
					{
						this.IconSpriteTexture = ComputerTexture;
					}
					break;
				case  PlayerType.Human:
					if (interpolationValue >= 1)
					{
						this.IconSpriteTexture = HumanTexture;
					}
					break;
			}
			if (interpolationValue < 1)
			{
				mCurrentPlayerTypeState = (int)firstState;
			}
			else
			{
				mCurrentPlayerTypeState = (int)secondState;
			}
		}
		public FlatRedBall.Instructions.Instruction InterpolateToState (IconState stateToInterpolateTo, double secondsToTake)
		{
			switch(stateToInterpolateTo)
			{
				case  IconState.Selected:
					break;
				case  IconState.NotSelected:
					break;
			}
			var instruction = new FlatRedBall.Instructions.DelegateInstruction<IconState>(StopStateInterpolation, stateToInterpolateTo);
			instruction.TimeToExecute = FlatRedBall.TimeManager.CurrentTime + secondsToTake;
			this.Instructions.Add(instruction);
			return instruction;
		}
		public void StopStateInterpolation (IconState stateToStop)
		{
			switch(stateToStop)
			{
				case  IconState.Selected:
					break;
				case  IconState.NotSelected:
					break;
			}
			CurrentIconStateState = stateToStop;
		}
		public void InterpolateBetween (IconState firstState, IconState secondState, float interpolationValue)
		{
			#if DEBUG
			if (float.IsNaN(interpolationValue))
			{
				throw new Exception("interpolationValue cannot be NaN");
			}
			#endif
			bool setIntensity = true;
			float IntensityFirstValue= 0;
			float IntensitySecondValue= 0;
			switch(firstState)
			{
				case  IconState.Selected:
					IntensityFirstValue = 1f;
					if (interpolationValue < 1)
					{
						this.HighlightSpriteVisible = true;
					}
					break;
				case  IconState.NotSelected:
					IntensityFirstValue = 0.5f;
					if (interpolationValue < 1)
					{
						this.HighlightSpriteVisible = false;
					}
					break;
			}
			switch(secondState)
			{
				case  IconState.Selected:
					IntensitySecondValue = 1f;
					if (interpolationValue >= 1)
					{
						this.HighlightSpriteVisible = true;
					}
					break;
				case  IconState.NotSelected:
					IntensitySecondValue = 0.5f;
					if (interpolationValue >= 1)
					{
						this.HighlightSpriteVisible = false;
					}
					break;
			}
			if (setIntensity)
			{
				Intensity = IntensityFirstValue * (1 - interpolationValue) + IntensitySecondValue * interpolationValue;
			}
			if (interpolationValue < 1)
			{
				mCurrentIconStateState = (int)firstState;
			}
			else
			{
				mCurrentIconStateState = (int)secondState;
			}
		}
		public static void PreloadStateContent (PlayerType state, string contentManagerName)
		{
			ContentManagerName = contentManagerName;
			switch(state)
			{
				case  PlayerType.Computer:
					{
						object throwaway = ComputerTexture;
					}
					break;
				case  PlayerType.Human:
					{
						object throwaway = HumanTexture;
					}
					break;
			}
		}
		public static void PreloadStateContent (IconState state, string contentManagerName)
		{
			ContentManagerName = contentManagerName;
			switch(state)
			{
				case  IconState.Selected:
					break;
				case  IconState.NotSelected:
					break;
			}
		}
		[System.Obsolete("Use GetFile instead")]
		public static object GetStaticMember (string memberName)
		{
			switch(memberName)
			{
				case  "HumanTexture":
					return HumanTexture;
				case  "ComputerTexture":
					return ComputerTexture;
				case  "IconHighlight":
					return IconHighlight;
			}
			return null;
		}
		public static object GetFile (string memberName)
		{
			switch(memberName)
			{
				case  "HumanTexture":
					return HumanTexture;
				case  "ComputerTexture":
					return ComputerTexture;
				case  "IconHighlight":
					return IconHighlight;
			}
			return null;
		}
		object GetMember (string memberName)
		{
			switch(memberName)
			{
				case  "HumanTexture":
					return HumanTexture;
				case  "ComputerTexture":
					return ComputerTexture;
				case  "IconHighlight":
					return IconHighlight;
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
			if (IconSprite.Alpha != 0 && IconSprite.AbsoluteVisible && cursor.IsOn3D(IconSprite, LayerProvidedByContainer))
			{
				return true;
			}
			if (HighlightSprite.Alpha != 0 && HighlightSprite.AbsoluteVisible && cursor.IsOn3D(HighlightSprite, LayerProvidedByContainer))
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
			FlatRedBall.Instructions.InstructionManager.IgnorePausingFor(IconSprite);
			FlatRedBall.Instructions.InstructionManager.IgnorePausingFor(HighlightSprite);
		}
		public virtual void MoveToLayer (Layer layerToMoveTo)
		{
			if (LayerProvidedByContainer != null)
			{
				LayerProvidedByContainer.Remove(IconSprite);
			}
			SpriteManager.AddToLayer(IconSprite, layerToMoveTo);
			if (LayerProvidedByContainer != null)
			{
				LayerProvidedByContainer.Remove(HighlightSprite);
			}
			SpriteManager.AddToLayer(HighlightSprite, layerToMoveTo);
			LayerProvidedByContainer = layerToMoveTo;
		}

    }
	
	
		public static class IconExtensionMethods
	{
		public static void SetVisible (this PositionedObjectList<Icon> list, bool value)
		{
			int count = list.Count;
			for (int i = 0; i < count; i++)
			{
				list[i].Visible = value;
			}
		}
	}

	
}
