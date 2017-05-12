#if ANDROID
#define REQUIRES_PRIMARY_THREAD_LOADING
#endif
using System.Collections.Generic;
using System.Threading;
using FlatRedBall;
using FlatRedBall.Math.Geometry;
using FlatRedBall.ManagedSpriteGroups;
using FlatRedBall.Graphics.Animation;
using FlatRedBall.Graphics.Particle;
using FlatRedBall.AI.Pathfinding;
using FlatRedBall.Utilities;
using BitmapFont = FlatRedBall.Graphics.BitmapFont;
using FlatRedBall.Localization;

namespace FrbTicTacToe
{
	public static partial class GlobalContent
	{
		
		public static Microsoft.Xna.Framework.Audio.SoundEffect ClickWave { get; set; }
		public static Microsoft.Xna.Framework.Audio.SoundEffect ScrapeWave { get; set; }
		public static Microsoft.Xna.Framework.Audio.SoundEffect PopWave { get; set; }
		public static Microsoft.Xna.Framework.Audio.SoundEffect TaDa { get; set; }
		public static Microsoft.Xna.Framework.Audio.SoundEffect Sad { get; set; }
		public static Microsoft.Xna.Framework.Media.Song GameMusic3 { get; set; }
		public static Microsoft.Xna.Framework.Media.Song GameMusic4 { get; set; }
		public static Microsoft.Xna.Framework.Media.Song GameMusic5 { get; set; }
		public static Microsoft.Xna.Framework.Media.Song GameMusic2 { get; set; }
		public static Microsoft.Xna.Framework.Media.Song GameMusic1 { get; set; }
		public static Microsoft.Xna.Framework.Media.Song MenuMusic { get; set; }
		[System.Obsolete("Use GetFile instead")]
		public static object GetStaticMember (string memberName)
		{
			switch(memberName)
			{
				case  "ClickWave":
					return ClickWave;
				case  "ScrapeWave":
					return ScrapeWave;
				case  "PopWave":
					return PopWave;
				case  "TaDa":
					return TaDa;
				case  "Sad":
					return Sad;
				case  "GameMusic3":
					return GameMusic3;
				case  "GameMusic4":
					return GameMusic4;
				case  "GameMusic5":
					return GameMusic5;
				case  "GameMusic2":
					return GameMusic2;
				case  "GameMusic1":
					return GameMusic1;
				case  "MenuMusic":
					return MenuMusic;
			}
			return null;
		}
		public static object GetFile (string memberName)
		{
			switch(memberName)
			{
				case  "ClickWave":
					return ClickWave;
				case  "ScrapeWave":
					return ScrapeWave;
				case  "PopWave":
					return PopWave;
				case  "TaDa":
					return TaDa;
				case  "Sad":
					return Sad;
				case  "GameMusic3":
					return GameMusic3;
				case  "GameMusic4":
					return GameMusic4;
				case  "GameMusic5":
					return GameMusic5;
				case  "GameMusic2":
					return GameMusic2;
				case  "GameMusic1":
					return GameMusic1;
				case  "MenuMusic":
					return MenuMusic;
			}
			return null;
		}
		public static bool IsInitialized { get; private set; }
		public static bool ShouldStopLoading { get; set; }
		const string ContentManagerName = "Global";
		public static void Initialize ()
		{
			
			#if !REQUIRES_PRIMARY_THREAD_LOADING
			ClickWave = FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/globalcontent/clickwave", ContentManagerName);
			ScrapeWave = FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/globalcontent/scrapewave", ContentManagerName);
			PopWave = FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/globalcontent/popwave", ContentManagerName);
			TaDa = FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/globalcontent/tada", ContentManagerName);
			Sad = FlatRedBallServices.Load<Microsoft.Xna.Framework.Audio.SoundEffect>(@"content/globalcontent/sad", ContentManagerName);
			GameMusic3 = FlatRedBallServices.Load<Microsoft.Xna.Framework.Media.Song>(@"content/globalcontent/gamemusic3", ContentManagerName);
			GameMusic4 = FlatRedBallServices.Load<Microsoft.Xna.Framework.Media.Song>(@"content/globalcontent/gamemusic4", ContentManagerName);
			GameMusic5 = FlatRedBallServices.Load<Microsoft.Xna.Framework.Media.Song>(@"content/globalcontent/gamemusic5", ContentManagerName);
			GameMusic2 = FlatRedBallServices.Load<Microsoft.Xna.Framework.Media.Song>(@"content/globalcontent/gamemusic2", ContentManagerName);
			GameMusic1 = FlatRedBallServices.Load<Microsoft.Xna.Framework.Media.Song>(@"content/globalcontent/gamemusic1", ContentManagerName);
			MenuMusic = FlatRedBallServices.Load<Microsoft.Xna.Framework.Media.Song>(@"content/globalcontent/menumusic", ContentManagerName);
			#endif
						IsInitialized = true;
		}
		public static void Reload (object whatToReload)
		{
		}
		
		
	}
}
