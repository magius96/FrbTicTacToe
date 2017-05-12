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
	public partial class Label
	{
        void OnAfterFontSizeSet (object sender, EventArgs e)
        {
            LabelText.Scale = FontSize;
            LabelText.Spacing = FontSize;
            LabelText.NewLineDistance = FontSize * 2;
        }
        void OnAfterRedSet (object sender, EventArgs e)
        {
            LabelText.Red = 1 - Red;
        }
        void OnAfterGreenSet (object sender, EventArgs e)
        {
            LabelText.Green = 1 - Green;
        }
        void OnAfterBlueSet (object sender, EventArgs e)
        {
            LabelText.Blue = 1 - Blue;
        }
	}
}
