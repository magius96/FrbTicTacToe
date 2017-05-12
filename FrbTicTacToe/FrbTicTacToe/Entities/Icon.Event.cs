using System;
using FlatRedBall;
using FlatRedBall.Input;
using FlatRedBall.Instructions;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Specialized;
using FlatRedBall.Audio;
using FlatRedBall.Screens;
using FrbTicTacToe.Entities;
using FrbTicTacToe.Screens;
namespace FrbTicTacToe.Entities
{
	public partial class Icon
	{
        void OnAfterSizeSet (object sender, EventArgs e)
        {
            IconSprite.Width = Size;
            IconSprite.Height = Size;
            HighlightSprite.Width = Size*2f;
            HighlightSprite.Height = Size;
            HighlightSprite.RelativeY = -Size;
        }
        void OnAfterIntensitySet (object sender, EventArgs e)
        {
            IconSprite.Red = 1 - Intensity;
            IconSprite.Green = 1 - Intensity;
            IconSprite.Blue = 1 - Intensity;
        }
		
	}
}
