using System.Collections.Generic;
using FlatRedBall;
using FlatRedBall.Graphics;
#if FRB_XNA || SILVERLIGHT
using Texture2D = Microsoft.Xna.Framework.Graphics.Texture2D;
#endif

namespace FrbTicTacToe.Entities
{
	public partial class Background
	{
	    private bool _initialized = false;
	    private List<Texture2D> Backgrounds = new List<Texture2D>(); 

		private void CustomInitialize() { Backgrounds = new List<Texture2D> {Background1, Background2, Background3, Background4, Background5}; }

		private void CustomActivity()
		{
            if(!_initialized)
            {
                ChangeBackground();
                _initialized = true;
            }

            if(Backgrounds.Count == 0)
            {
                // I could easily just recreate the list with all the backgrounds
                // but i don't want to repeat the current background again
                if (BackgroundTexture != Background1) Backgrounds.Add(Background1);
                if (BackgroundTexture != Background2) Backgrounds.Add(Background2);
                if (BackgroundTexture != Background3) Backgrounds.Add(Background3);
                if (BackgroundTexture != Background4) Backgrounds.Add(Background4);
                if (BackgroundTexture != Background5) Backgrounds.Add(Background5);
            }
		}

		private void CustomDestroy()
		{


		}

        private static void CustomLoadStaticContent(string contentManagerName)
        {


        }

        public void ChangeBackground()
        {
            if (RandomImage)
            {
                var index = FlatRedBallServices.Random.Next(Backgrounds.Count);
                BackgroundSprite.Texture = Backgrounds[index];
                BackgroundSprite.ColorOperation = ColorOperation.Subtract;
                BackgroundSprite.Red = 0.25f;
                BackgroundSprite.Green = 0.25f;
                BackgroundSprite.Blue = 0.25f;

                Backgrounds.RemoveAt(index);
            }
            else
            {
                BackgroundSprite.Texture = BackgroundTexture;
            }
        }
	}
}
