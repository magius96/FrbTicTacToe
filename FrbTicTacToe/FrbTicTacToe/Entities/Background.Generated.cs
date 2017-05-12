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
	public partial class Background : PositionedObject, IDestroyable
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
		protected static Microsoft.Xna.Framework.Graphics.Texture2D BackgroundTexture;
		protected static Microsoft.Xna.Framework.Graphics.Texture2D Background4;
		protected static Microsoft.Xna.Framework.Graphics.Texture2D Background5;
		protected static Microsoft.Xna.Framework.Graphics.Texture2D Background1;
		protected static Microsoft.Xna.Framework.Graphics.Texture2D Background2;
		protected static Microsoft.Xna.Framework.Graphics.Texture2D Background3;
		
		private FlatRedBall.Sprite BackgroundSprite;
		public bool RandomImage = true;
		protected Layer LayerProvidedByContainer = null;

        public Background()
            : this(FlatRedBall.Screens.ScreenManager.CurrentScreen.ContentManagerName, true)
        {

        }

        public Background(string contentManagerName) :
            this(contentManagerName, true)
        {
        }


        public Background(string contentManagerName, bool addToManagers) :
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
			BackgroundSprite = new FlatRedBall.Sprite();
			BackgroundSprite.Name = "BackgroundSprite";
			
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
			SpriteManager.AddToLayer(BackgroundSprite, LayerProvidedByContainer);
		}
		public virtual void AddToManagers (Layer layerToAddTo)
		{
			LayerProvidedByContainer = layerToAddTo;
			SpriteManager.AddPositionedObject(this);
			SpriteManager.AddToLayer(BackgroundSprite, LayerProvidedByContainer);
			AddToManagersBottomUp(layerToAddTo);
			CustomInitialize();
		}

		public virtual void Activity()
		{
			// Generated Activity
			
			CustomActivity();
			
			// After Custom Activity
		}

		public virtual void Destroy()
		{
			// Generated Destroy
			SpriteManager.RemovePositionedObject(this);
			
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
			if (BackgroundSprite.Parent == null)
			{
				BackgroundSprite.CopyAbsoluteToRelative();
				BackgroundSprite.AttachTo(this, false);
			}
			BackgroundSprite.Texture = BackgroundTexture;
			BackgroundSprite.Height = 600f;
			BackgroundSprite.TextureScale = 0f;
			BackgroundSprite.Width = 800f;
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
			if (BackgroundSprite != null)
			{
				SpriteManager.RemoveSpriteOneWay(BackgroundSprite);
			}
		}
		public virtual void AssignCustomVariables (bool callOnContainedElements)
		{
			if (callOnContainedElements)
			{
			}
			BackgroundSprite.Texture = BackgroundTexture;
			BackgroundSprite.Height = 600f;
			BackgroundSprite.TextureScale = 0f;
			BackgroundSprite.Width = 800f;
			if (BackgroundSprite.Parent == null)
			{
				BackgroundSprite.Z = -1f;
			}
			else
			{
				BackgroundSprite.RelativeZ = -1f;
			}
			RandomImage = true;
		}
		public virtual void ConvertToManuallyUpdated ()
		{
			this.ForceUpdateDependenciesDeep();
			SpriteManager.ConvertToManuallyUpdated(this);
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
						FlatRedBallServices.GetContentManagerByName(ContentManagerName).AddUnloadMethod("BackgroundStaticUnload", UnloadStaticContent);
						mRegisteredUnloads.Add(ContentManagerName);
					}
				}
				if (!FlatRedBallServices.IsLoaded<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/background/backgroundtexture.png", ContentManagerName))
				{
					registerUnload = true;
				}
				BackgroundTexture = FlatRedBallServices.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/background/backgroundtexture.png", ContentManagerName);
				if (!FlatRedBallServices.IsLoaded<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/background/background4.png", ContentManagerName))
				{
					registerUnload = true;
				}
				Background4 = FlatRedBallServices.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/background/background4.png", ContentManagerName);
				if (!FlatRedBallServices.IsLoaded<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/background/background5.png", ContentManagerName))
				{
					registerUnload = true;
				}
				Background5 = FlatRedBallServices.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/background/background5.png", ContentManagerName);
				if (!FlatRedBallServices.IsLoaded<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/background/background1.png", ContentManagerName))
				{
					registerUnload = true;
				}
				Background1 = FlatRedBallServices.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/background/background1.png", ContentManagerName);
				if (!FlatRedBallServices.IsLoaded<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/background/background2.png", ContentManagerName))
				{
					registerUnload = true;
				}
				Background2 = FlatRedBallServices.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/background/background2.png", ContentManagerName);
				if (!FlatRedBallServices.IsLoaded<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/background/background3.png", ContentManagerName))
				{
					registerUnload = true;
				}
				Background3 = FlatRedBallServices.Load<Microsoft.Xna.Framework.Graphics.Texture2D>(@"content/entities/background/background3.png", ContentManagerName);
			}
			if (registerUnload && ContentManagerName != FlatRedBallServices.GlobalContentManager)
			{
				lock (mLockObject)
				{
					if (!mRegisteredUnloads.Contains(ContentManagerName) && ContentManagerName != FlatRedBallServices.GlobalContentManager)
					{
						FlatRedBallServices.GetContentManagerByName(ContentManagerName).AddUnloadMethod("BackgroundStaticUnload", UnloadStaticContent);
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
				if (BackgroundTexture != null)
				{
					BackgroundTexture= null;
				}
				if (Background4 != null)
				{
					Background4= null;
				}
				if (Background5 != null)
				{
					Background5= null;
				}
				if (Background1 != null)
				{
					Background1= null;
				}
				if (Background2 != null)
				{
					Background2= null;
				}
				if (Background3 != null)
				{
					Background3= null;
				}
			}
		}
		[System.Obsolete("Use GetFile instead")]
		public static object GetStaticMember (string memberName)
		{
			switch(memberName)
			{
				case  "BackgroundTexture":
					return BackgroundTexture;
				case  "Background4":
					return Background4;
				case  "Background5":
					return Background5;
				case  "Background1":
					return Background1;
				case  "Background2":
					return Background2;
				case  "Background3":
					return Background3;
			}
			return null;
		}
		public static object GetFile (string memberName)
		{
			switch(memberName)
			{
				case  "BackgroundTexture":
					return BackgroundTexture;
				case  "Background4":
					return Background4;
				case  "Background5":
					return Background5;
				case  "Background1":
					return Background1;
				case  "Background2":
					return Background2;
				case  "Background3":
					return Background3;
			}
			return null;
		}
		object GetMember (string memberName)
		{
			switch(memberName)
			{
				case  "BackgroundTexture":
					return BackgroundTexture;
				case  "Background4":
					return Background4;
				case  "Background5":
					return Background5;
				case  "Background1":
					return Background1;
				case  "Background2":
					return Background2;
				case  "Background3":
					return Background3;
			}
			return null;
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
			FlatRedBall.Instructions.InstructionManager.IgnorePausingFor(BackgroundSprite);
		}
		public virtual void MoveToLayer (Layer layerToMoveTo)
		{
			if (LayerProvidedByContainer != null)
			{
				LayerProvidedByContainer.Remove(BackgroundSprite);
			}
			SpriteManager.AddToLayer(BackgroundSprite, layerToMoveTo);
			LayerProvidedByContainer = layerToMoveTo;
		}

    }
	
	
	// Extra classes
	
}
