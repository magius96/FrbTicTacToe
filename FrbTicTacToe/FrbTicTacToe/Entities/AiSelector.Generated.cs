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
	public partial class AiSelector : PositionedObject, IDestroyable, IVisible
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
			Easy = 2, 
			NormalOffensive = 3, 
			NormalDefensive = 4, 
			Hard = 5
		}
		protected int mCurrentState = 0;
		public Entities.AiSelector.VariableState CurrentState
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
					case  VariableState.Easy:
						EasySelectionBlue = 0f;
						HardSelectionBlue = 1f;
						NormalDefensiveSelectionBlue = 1f;
						NormalOffensiveSelectionBlue = 1f;
						break;
					case  VariableState.NormalOffensive:
						EasySelectionBlue = 1f;
						HardSelectionBlue = 1f;
						NormalDefensiveSelectionBlue = 1f;
						NormalOffensiveSelectionBlue = 0f;
						break;
					case  VariableState.NormalDefensive:
						EasySelectionBlue = 1f;
						HardSelectionBlue = 1f;
						NormalDefensiveSelectionBlue = 0f;
						NormalOffensiveSelectionBlue = 1f;
						break;
					case  VariableState.Hard:
						EasySelectionBlue = 1f;
						HardSelectionBlue = 0f;
						NormalDefensiveSelectionBlue = 1f;
						NormalOffensiveSelectionBlue = 1f;
						break;
				}
			}
		}
		static object mLockObject = new object();
		static List<string> mRegisteredUnloads = new List<string>();
		static List<string> LoadedContentManagers = new List<string>();
		
		private FrbTicTacToe.Entities.Label EasySelection;
		private FrbTicTacToe.Entities.Label NormalOffensiveSelection;
		private FrbTicTacToe.Entities.Label NormalDefensiveSelection;
		private FrbTicTacToe.Entities.Label HardSelection;
		public float EasySelectionBlue
		{
			get
			{
				return EasySelection.Blue;
			}
			set
			{
				EasySelection.Blue = value;
			}
		}
		public float HardSelectionBlue
		{
			get
			{
				return HardSelection.Blue;
			}
			set
			{
				HardSelection.Blue = value;
			}
		}
		public float NormalDefensiveSelectionBlue
		{
			get
			{
				return NormalDefensiveSelection.Blue;
			}
			set
			{
				NormalDefensiveSelection.Blue = value;
			}
		}
		public float NormalOffensiveSelectionBlue
		{
			get
			{
				return NormalOffensiveSelection.Blue;
			}
			set
			{
				NormalOffensiveSelection.Blue = value;
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

        public AiSelector()
            : this(FlatRedBall.Screens.ScreenManager.CurrentScreen.ContentManagerName, true)
        {

        }

        public AiSelector(string contentManagerName) :
            this(contentManagerName, true)
        {
        }


        public AiSelector(string contentManagerName, bool addToManagers) :
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
			EasySelection = new FrbTicTacToe.Entities.Label(ContentManagerName, false);
			EasySelection.Name = "EasySelection";
			NormalOffensiveSelection = new FrbTicTacToe.Entities.Label(ContentManagerName, false);
			NormalOffensiveSelection.Name = "NormalOffensiveSelection";
			NormalDefensiveSelection = new FrbTicTacToe.Entities.Label(ContentManagerName, false);
			NormalDefensiveSelection.Name = "NormalDefensiveSelection";
			HardSelection = new FrbTicTacToe.Entities.Label(ContentManagerName, false);
			HardSelection.Name = "HardSelection";
			
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
			EasySelection.ReAddToManagers(LayerProvidedByContainer);
			NormalOffensiveSelection.ReAddToManagers(LayerProvidedByContainer);
			NormalDefensiveSelection.ReAddToManagers(LayerProvidedByContainer);
			HardSelection.ReAddToManagers(LayerProvidedByContainer);
		}
		public virtual void AddToManagers (Layer layerToAddTo)
		{
			LayerProvidedByContainer = layerToAddTo;
			SpriteManager.AddPositionedObject(this);
			EasySelection.AddToManagers(LayerProvidedByContainer);
			NormalOffensiveSelection.AddToManagers(LayerProvidedByContainer);
			NormalDefensiveSelection.AddToManagers(LayerProvidedByContainer);
			HardSelection.AddToManagers(LayerProvidedByContainer);
			AddToManagersBottomUp(layerToAddTo);
			CustomInitialize();
		}

		public virtual void Activity()
		{
			// Generated Activity
			
			EasySelection.Activity();
			NormalOffensiveSelection.Activity();
			NormalDefensiveSelection.Activity();
			HardSelection.Activity();
			CustomActivity();
			
			// After Custom Activity
		}

		public virtual void Destroy()
		{
			// Generated Destroy
			SpriteManager.RemovePositionedObject(this);
			
			if (EasySelection != null)
			{
				EasySelection.Destroy();
				EasySelection.Detach();
			}
			if (NormalOffensiveSelection != null)
			{
				NormalOffensiveSelection.Destroy();
				NormalOffensiveSelection.Detach();
			}
			if (NormalDefensiveSelection != null)
			{
				NormalDefensiveSelection.Destroy();
				NormalDefensiveSelection.Detach();
			}
			if (HardSelection != null)
			{
				HardSelection.Destroy();
				HardSelection.Detach();
			}


			CustomDestroy();
		}

		// Generated Methods
		public virtual void PostInitialize ()
		{
			bool oldShapeManagerSuppressAdd = FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue;
			FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = true;
			if (EasySelection.Parent == null)
			{
				EasySelection.CopyAbsoluteToRelative();
				EasySelection.AttachTo(this, false);
			}
			if (EasySelection.Parent == null)
			{
				EasySelection.Y = 0f;
			}
			else
			{
				EasySelection.RelativeY = 0f;
			}
			EasySelection.Text = "Easy";
			EasySelection.FontSize = 9;
			EasySelection.Red = 1f;
			EasySelection.Green = 1f;
			EasySelection.Blue = 1f;
			EasySelection.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Left;
			EasySelection.VerticalAlignment = FlatRedBall.Graphics.VerticalAlignment.Top;
			if (NormalOffensiveSelection.Parent == null)
			{
				NormalOffensiveSelection.CopyAbsoluteToRelative();
				NormalOffensiveSelection.AttachTo(this, false);
			}
			if (NormalOffensiveSelection.Parent == null)
			{
				NormalOffensiveSelection.Y = -20f;
			}
			else
			{
				NormalOffensiveSelection.RelativeY = -20f;
			}
			NormalOffensiveSelection.Text = "Normal Offensive";
			NormalOffensiveSelection.FontSize = 9;
			NormalOffensiveSelection.Red = 1f;
			NormalOffensiveSelection.Green = 1f;
			NormalOffensiveSelection.Blue = 1f;
			NormalOffensiveSelection.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Left;
			NormalOffensiveSelection.VerticalAlignment = FlatRedBall.Graphics.VerticalAlignment.Top;
			if (NormalDefensiveSelection.Parent == null)
			{
				NormalDefensiveSelection.CopyAbsoluteToRelative();
				NormalDefensiveSelection.AttachTo(this, false);
			}
			if (NormalDefensiveSelection.Parent == null)
			{
				NormalDefensiveSelection.Y = -40f;
			}
			else
			{
				NormalDefensiveSelection.RelativeY = -40f;
			}
			NormalDefensiveSelection.Text = "Normal Defensive";
			NormalDefensiveSelection.FontSize = 9;
			NormalDefensiveSelection.Red = 1f;
			NormalDefensiveSelection.Green = 1f;
			NormalDefensiveSelection.Blue = 1f;
			NormalDefensiveSelection.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Left;
			NormalDefensiveSelection.VerticalAlignment = FlatRedBall.Graphics.VerticalAlignment.Top;
			if (HardSelection.Parent == null)
			{
				HardSelection.CopyAbsoluteToRelative();
				HardSelection.AttachTo(this, false);
			}
			if (HardSelection.Parent == null)
			{
				HardSelection.Y = -60f;
			}
			else
			{
				HardSelection.RelativeY = -60f;
			}
			HardSelection.Text = "Hard";
			HardSelection.FontSize = 9;
			HardSelection.Red = 1f;
			HardSelection.Green = 1f;
			HardSelection.Blue = 1f;
			HardSelection.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Left;
			HardSelection.VerticalAlignment = FlatRedBall.Graphics.VerticalAlignment.Top;
			FlatRedBall.Math.Geometry.ShapeManager.SuppressAddingOnVisibilityTrue = oldShapeManagerSuppressAdd;
		}
		public virtual void AddToManagersBottomUp (Layer layerToAddTo)
		{
			AssignCustomVariables(false);
		}
		public virtual void RemoveFromManagers ()
		{
			SpriteManager.ConvertToManuallyUpdated(this);
			EasySelection.RemoveFromManagers();
			NormalOffensiveSelection.RemoveFromManagers();
			NormalDefensiveSelection.RemoveFromManagers();
			HardSelection.RemoveFromManagers();
		}
		public virtual void AssignCustomVariables (bool callOnContainedElements)
		{
			if (callOnContainedElements)
			{
				EasySelection.AssignCustomVariables(true);
				NormalOffensiveSelection.AssignCustomVariables(true);
				NormalDefensiveSelection.AssignCustomVariables(true);
				HardSelection.AssignCustomVariables(true);
			}
			if (EasySelection.Parent == null)
			{
				EasySelection.Y = 0f;
			}
			else
			{
				EasySelection.RelativeY = 0f;
			}
			EasySelection.Text = "Easy";
			EasySelection.FontSize = 9;
			EasySelection.Red = 1f;
			EasySelection.Green = 1f;
			EasySelection.Blue = 1f;
			EasySelection.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Left;
			EasySelection.VerticalAlignment = FlatRedBall.Graphics.VerticalAlignment.Top;
			if (NormalOffensiveSelection.Parent == null)
			{
				NormalOffensiveSelection.Y = -20f;
			}
			else
			{
				NormalOffensiveSelection.RelativeY = -20f;
			}
			NormalOffensiveSelection.Text = "Normal Offensive";
			NormalOffensiveSelection.FontSize = 9;
			NormalOffensiveSelection.Red = 1f;
			NormalOffensiveSelection.Green = 1f;
			NormalOffensiveSelection.Blue = 1f;
			NormalOffensiveSelection.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Left;
			NormalOffensiveSelection.VerticalAlignment = FlatRedBall.Graphics.VerticalAlignment.Top;
			if (NormalDefensiveSelection.Parent == null)
			{
				NormalDefensiveSelection.Y = -40f;
			}
			else
			{
				NormalDefensiveSelection.RelativeY = -40f;
			}
			NormalDefensiveSelection.Text = "Normal Defensive";
			NormalDefensiveSelection.FontSize = 9;
			NormalDefensiveSelection.Red = 1f;
			NormalDefensiveSelection.Green = 1f;
			NormalDefensiveSelection.Blue = 1f;
			NormalDefensiveSelection.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Left;
			NormalDefensiveSelection.VerticalAlignment = FlatRedBall.Graphics.VerticalAlignment.Top;
			if (HardSelection.Parent == null)
			{
				HardSelection.Y = -60f;
			}
			else
			{
				HardSelection.RelativeY = -60f;
			}
			HardSelection.Text = "Hard";
			HardSelection.FontSize = 9;
			HardSelection.Red = 1f;
			HardSelection.Green = 1f;
			HardSelection.Blue = 1f;
			HardSelection.HorizontalAlignment = FlatRedBall.Graphics.HorizontalAlignment.Left;
			HardSelection.VerticalAlignment = FlatRedBall.Graphics.VerticalAlignment.Top;
			CurrentState = AiSelector.VariableState.Hard;
		}
		public virtual void ConvertToManuallyUpdated ()
		{
			this.ForceUpdateDependenciesDeep();
			SpriteManager.ConvertToManuallyUpdated(this);
			EasySelection.ConvertToManuallyUpdated();
			NormalOffensiveSelection.ConvertToManuallyUpdated();
			NormalDefensiveSelection.ConvertToManuallyUpdated();
			HardSelection.ConvertToManuallyUpdated();
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
						FlatRedBallServices.GetContentManagerByName(ContentManagerName).AddUnloadMethod("AiSelectorStaticUnload", UnloadStaticContent);
						mRegisteredUnloads.Add(ContentManagerName);
					}
				}
			}
			FrbTicTacToe.Entities.Label.LoadStaticContent(contentManagerName);
			if (registerUnload && ContentManagerName != FlatRedBallServices.GlobalContentManager)
			{
				lock (mLockObject)
				{
					if (!mRegisteredUnloads.Contains(ContentManagerName) && ContentManagerName != FlatRedBallServices.GlobalContentManager)
					{
						FlatRedBallServices.GetContentManagerByName(ContentManagerName).AddUnloadMethod("AiSelectorStaticUnload", UnloadStaticContent);
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
				case  VariableState.Easy:
					break;
				case  VariableState.NormalOffensive:
					break;
				case  VariableState.NormalDefensive:
					break;
				case  VariableState.Hard:
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
				case  VariableState.Easy:
					break;
				case  VariableState.NormalOffensive:
					break;
				case  VariableState.NormalDefensive:
					break;
				case  VariableState.Hard:
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
			bool setEasySelectionBlue = true;
			float EasySelectionBlueFirstValue= 0;
			float EasySelectionBlueSecondValue= 0;
			bool setHardSelectionBlue = true;
			float HardSelectionBlueFirstValue= 0;
			float HardSelectionBlueSecondValue= 0;
			bool setNormalDefensiveSelectionBlue = true;
			float NormalDefensiveSelectionBlueFirstValue= 0;
			float NormalDefensiveSelectionBlueSecondValue= 0;
			bool setNormalOffensiveSelectionBlue = true;
			float NormalOffensiveSelectionBlueFirstValue= 0;
			float NormalOffensiveSelectionBlueSecondValue= 0;
			switch(firstState)
			{
				case  VariableState.Easy:
					EasySelectionBlueFirstValue = 0f;
					HardSelectionBlueFirstValue = 1f;
					NormalDefensiveSelectionBlueFirstValue = 1f;
					NormalOffensiveSelectionBlueFirstValue = 1f;
					break;
				case  VariableState.NormalOffensive:
					EasySelectionBlueFirstValue = 1f;
					HardSelectionBlueFirstValue = 1f;
					NormalDefensiveSelectionBlueFirstValue = 1f;
					NormalOffensiveSelectionBlueFirstValue = 0f;
					break;
				case  VariableState.NormalDefensive:
					EasySelectionBlueFirstValue = 1f;
					HardSelectionBlueFirstValue = 1f;
					NormalDefensiveSelectionBlueFirstValue = 0f;
					NormalOffensiveSelectionBlueFirstValue = 1f;
					break;
				case  VariableState.Hard:
					EasySelectionBlueFirstValue = 1f;
					HardSelectionBlueFirstValue = 0f;
					NormalDefensiveSelectionBlueFirstValue = 1f;
					NormalOffensiveSelectionBlueFirstValue = 1f;
					break;
			}
			switch(secondState)
			{
				case  VariableState.Easy:
					EasySelectionBlueSecondValue = 0f;
					HardSelectionBlueSecondValue = 1f;
					NormalDefensiveSelectionBlueSecondValue = 1f;
					NormalOffensiveSelectionBlueSecondValue = 1f;
					break;
				case  VariableState.NormalOffensive:
					EasySelectionBlueSecondValue = 1f;
					HardSelectionBlueSecondValue = 1f;
					NormalDefensiveSelectionBlueSecondValue = 1f;
					NormalOffensiveSelectionBlueSecondValue = 0f;
					break;
				case  VariableState.NormalDefensive:
					EasySelectionBlueSecondValue = 1f;
					HardSelectionBlueSecondValue = 1f;
					NormalDefensiveSelectionBlueSecondValue = 0f;
					NormalOffensiveSelectionBlueSecondValue = 1f;
					break;
				case  VariableState.Hard:
					EasySelectionBlueSecondValue = 1f;
					HardSelectionBlueSecondValue = 0f;
					NormalDefensiveSelectionBlueSecondValue = 1f;
					NormalOffensiveSelectionBlueSecondValue = 1f;
					break;
			}
			if (setEasySelectionBlue)
			{
				EasySelectionBlue = EasySelectionBlueFirstValue * (1 - interpolationValue) + EasySelectionBlueSecondValue * interpolationValue;
			}
			if (setHardSelectionBlue)
			{
				HardSelectionBlue = HardSelectionBlueFirstValue * (1 - interpolationValue) + HardSelectionBlueSecondValue * interpolationValue;
			}
			if (setNormalDefensiveSelectionBlue)
			{
				NormalDefensiveSelectionBlue = NormalDefensiveSelectionBlueFirstValue * (1 - interpolationValue) + NormalDefensiveSelectionBlueSecondValue * interpolationValue;
			}
			if (setNormalOffensiveSelectionBlue)
			{
				NormalOffensiveSelectionBlue = NormalOffensiveSelectionBlueFirstValue * (1 - interpolationValue) + NormalOffensiveSelectionBlueSecondValue * interpolationValue;
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
				case  VariableState.Easy:
					break;
				case  VariableState.NormalOffensive:
					break;
				case  VariableState.NormalDefensive:
					break;
				case  VariableState.Hard:
					break;
			}
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
		protected bool mIsPaused;
		public override void Pause (FlatRedBall.Instructions.InstructionList instructions)
		{
			base.Pause(instructions);
			mIsPaused = true;
		}
		public virtual void SetToIgnorePausing ()
		{
			FlatRedBall.Instructions.InstructionManager.IgnorePausingFor(this);
			EasySelection.SetToIgnorePausing();
			NormalOffensiveSelection.SetToIgnorePausing();
			NormalDefensiveSelection.SetToIgnorePausing();
			HardSelection.SetToIgnorePausing();
		}
		public virtual void MoveToLayer (Layer layerToMoveTo)
		{
			EasySelection.MoveToLayer(layerToMoveTo);
			NormalOffensiveSelection.MoveToLayer(layerToMoveTo);
			NormalDefensiveSelection.MoveToLayer(layerToMoveTo);
			HardSelection.MoveToLayer(layerToMoveTo);
			LayerProvidedByContainer = layerToMoveTo;
		}

    }
	
	
		public static class AiSelectorExtensionMethods
	{
		public static void SetVisible (this PositionedObjectList<AiSelector> list, bool value)
		{
			int count = list.Count;
			for (int i = 0; i < count; i++)
			{
				list[i].Visible = value;
			}
		}
	}

	
}
