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
	public partial class Label : PositionedObject, IDestroyable, IVisible, IWindow
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
		protected static FlatRedBall.Graphics.BitmapFont Paint100;
		protected static Microsoft.Xna.Framework.Graphics.Texture2D Paint100_0;
		
		private FlatRedBall.Graphics.Text LabelText;
		public event EventHandler BeforeTextSet;
		public event EventHandler AfterTextSet;
		public string Text
		{
			get
			{
				return LabelText.DisplayText;
			}
			set
			{
				if (BeforeTextSet != null)
				{
					BeforeTextSet(this, null);
				}
				LabelText.DisplayText = value;
				if (AfterTextSet != null)
				{
					AfterTextSet(this, null);
				}
			}
		}
		public event EventHandler BeforeFontSizeSet;
		public event EventHandler AfterFontSizeSet;
		int mFontSize;
		public int FontSize
		{
			set
			{
				if (BeforeFontSizeSet != null)
				{
					BeforeFontSizeSet(this, null);
				}
				mFontSize = value;
				if (AfterFontSizeSet != null)
				{
					AfterFontSizeSet(this, null);
				}
			}
			get
			{
				return mFontSize;
			}
		}
		public event EventHandler BeforeRedSet;
		public event EventHandler AfterRedSet;
		float mRed;
		public float Red
		{
			set
			{
				if (BeforeRedSet != null)
				{
					BeforeRedSet(this, null);
				}
				mRed = value;
				if (AfterRedSet != null)
				{
					AfterRedSet(this, null);
				}
			}
			get
			{
				return mRed;
			}
		}
		public event EventHandler BeforeGreenSet;
		public event EventHandler AfterGreenSet;
		float mGreen;
		public float Green
		{
			set
			{
				if (BeforeGreenSet != null)
				{
					BeforeGreenSet(this, null);
				}
				mGreen = value;
				if (AfterGreenSet != null)
				{
					AfterGreenSet(this, null);
				}
			}
			get
			{
				return mGreen;
			}
		}
		public event EventHandler BeforeBlueSet;
		public event EventHandler AfterBlueSet;
		float mBlue;
		public float Blue
		{
			set
			{
				if (BeforeBlueSet != null)
				{
					BeforeBlueSet(this, null);
				}
				mBlue = value;
				if (AfterBlueSet != null)
				{
					AfterBlueSet(this, null);
				}
			}
			get
			{
				return mBlue;
			}
		}
		public FlatRedBall.Graphics.HorizontalAlignment HorizontalAlignment
		{
			get
			{
				return LabelText.HorizontalAlignment;
			}
			set
			{
				LabelText.HorizontalAlignment = value;
			}
		}
		public FlatRedBall.Graphics.VerticalAlignment VerticalAlignment
		{
			get
			{
				return LabelText.VerticalAlignment;
			}
			set
			{
				LabelText.VerticalAlignment = value;
			}
		}
		public float Alpha
		{
			get
			{
				return LabelText.Alpha;
			}
			set
			{
				LabelText.Alpha = value;
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

        public Label()
            : this(FlatRedBall.Screens.ScreenManager.CurrentScreen.ContentManagerName, true)
        {

        }

        public Label(string contentManagerName) :
            this(contentManagerName, true)
        {
        }


        public Label(string contentManagerName, bool addToManagers) :
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
			LabelText = new FlatRedBall.Graphics.Text();
			LabelText.Name = "LabelText";
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
			TextManager.AddToLayer(LabelText, LayerProvidedByContainer);
			if (LabelText.Font != null)
			{
				LabelText.SetPixelPerfectScale(LayerProvidedByContainer);
			}
		}
		public virtual void AddToManagers (Layer layerToAddTo)
		{
			LayerProvidedByContainer = layerToAddTo;
			SpriteManager.AddPositionedObject(this);
			GuiManager.AddWindow(this);
			TextManager.AddToLayer(LabelText, LayerProvidedByContainer);
			if (LabelText.Font != null)
			{
				LabelText.SetPixelPerfectScale(LayerProvidedByContainer);
			}
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
			
			if (LabelText != null)
			{
				TextManager.RemoveText(LabelText);
			}


			CustomDestroy();
		}

		// Generated Methods
		public virtual void PostInitialize ()
		{
			bool oldShapeManagerSuppressAdd = FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue;
			FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = true;
			this.AfterFontSizeSet += OnAfterFontSizeSet;
			this.AfterRedSet += OnAfterRedSet;
			this.AfterGreenSet += OnAfterGreenSet;
			this.AfterBlueSet += OnAfterBlueSet;
			if (LabelText.Parent == null)
			{
				LabelText.CopyAbsoluteToRelative();
				LabelText.AttachTo(this, false);
			}
			LabelText.DisplayText = "Unset Label";
			LabelText.Font = Paint100;
			LabelText.NewLineDistance = 136.5f;
			LabelText.Scale = 91f;
			LabelText.Spacing = 91f;
			LabelText.Blue = 1f;
			#if FRB_MDX
			LabelText.ColorOperation = Microsoft.DirectX.Direct3D.TextureOperation.Subtract;
			#else
			LabelText.ColorOperation = FlatRedBall.Graphics.ColorOperation.Subtract;
			#endif
			LabelText.Green = 1f;
			LabelText.Red = 1f;
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
			if (LabelText != null)
			{
				TextManager.RemoveTextOneWay(LabelText);
			}
		}
		public virtual void AssignCustomVariables (bool callOnContainedElements)
		{
			if (callOnContainedElements)
			{
			}
			LabelText.DisplayText = "Unset Label";
			LabelText.Font = Paint100;
			LabelText.NewLineDistance = 136.5f;
			LabelText.Scale = 91f;
			LabelText.Spacing = 91f;
			LabelText.Blue = 1f;
			#if FRB_MDX
			LabelText.ColorOperation = Microsoft.DirectX.Direct3D.TextureOperation.Subtract;
			#else
			LabelText.ColorOperation = FlatRedBall.Graphics.ColorOperation.Subtract;
			#endif
			LabelText.Green = 1f;
			LabelText.Red = 1f;
			Text = "Unset Label";
			HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Left;
			VerticalAlignment = FlatRedBall.Graphics.VerticalAlignment.Center;
			Alpha = 1f;
		}
		public virtual void ConvertToManuallyUpdated ()
		{
			this.ForceUpdateDependenciesDeep();
			SpriteManager.ConvertToManuallyUpdated(this);
			TextManager.ConvertToManuallyUpdated(LabelText);
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
						FlatRedBallServices.GetContentManagerByName(ContentManagerName).AddUnloadMethod("LabelStaticUnload", UnloadStaticContent);
						mRegisteredUnloads.Add(ContentManagerName);
					}
				}
				if (!FlatRedBallServices.IsLoaded<FlatRedBall.Graphics.BitmapFont>(@"content/entities/label/paint100.fnt", ContentManagerName))
				{
					registerUnload = true;
				}
				Paint100 = FlatRedBallServices.Load<FlatRedBall.Graphics.BitmapFont>(@"content/entities/label/paint100.fnt", ContentManagerName);
				if (!FlatRedBallServices.IsLoaded<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/label/paint100_0.png", ContentManagerName))
				{
					registerUnload = true;
				}
				Paint100_0 = FlatRedBallServices.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/label/paint100_0.png", ContentManagerName);
			}
			if (registerUnload && ContentManagerName != FlatRedBallServices.GlobalContentManager)
			{
				lock (mLockObject)
				{
					if (!mRegisteredUnloads.Contains(ContentManagerName) && ContentManagerName != FlatRedBallServices.GlobalContentManager)
					{
						FlatRedBallServices.GetContentManagerByName(ContentManagerName).AddUnloadMethod("LabelStaticUnload", UnloadStaticContent);
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
				if (Paint100 != null)
				{
					Paint100= null;
				}
				if (Paint100_0 != null)
				{
					Paint100_0= null;
				}
			}
		}
		[System.Obsolete("Use GetFile instead")]
		public static object GetStaticMember (string memberName)
		{
			switch(memberName)
			{
				case  "Paint100":
					return Paint100;
				case  "Paint100_0":
					return Paint100_0;
			}
			return null;
		}
		public static object GetFile (string memberName)
		{
			switch(memberName)
			{
				case  "Paint100":
					return Paint100;
				case  "Paint100_0":
					return Paint100_0;
			}
			return null;
		}
		object GetMember (string memberName)
		{
			switch(memberName)
			{
				case  "Paint100":
					return Paint100;
				case  "Paint100_0":
					return Paint100_0;
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
			if (LabelText.Alpha != 0 && LabelText.AbsoluteVisible && cursor.IsOn3D(LabelText, LayerProvidedByContainer))
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
			FlatRedBall.Instructions.InstructionManager.IgnorePausingFor(LabelText);
		}
		public virtual void MoveToLayer (Layer layerToMoveTo)
		{
			if (LayerProvidedByContainer != null)
			{
				LayerProvidedByContainer.Remove(LabelText);
			}
			TextManager.AddToLayer(LabelText, layerToMoveTo);
			LayerProvidedByContainer = layerToMoveTo;
		}

    }
	
	
		public static class LabelExtensionMethods
	{
		public static void SetVisible (this PositionedObjectList<Label> list, bool value)
		{
			int count = list.Count;
			for (int i = 0; i < count; i++)
			{
				list[i].Visible = value;
			}
		}
	}

	
}
