using FlatRedBall;
using Microsoft.Xna.Framework;

namespace FrbTicTacToe
{
	internal static class CameraSetup
	{
			internal static void SetupCamera (Camera cameraToSetUp, GraphicsDeviceManager graphicsDeviceManager, int width = 800, int height = 600)
			{
				FlatRedBallServices.GraphicsOptions.SetResolution(width, height);
				#if WINDOWS_PHONE || WINDOWS_8 || IOS || ANDROID
				if (height > width)
				{
					graphicsDeviceManager.SupportedOrientations = DisplayOrientation.Portrait;
				}
				else
				{
					graphicsDeviceManager.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;
				}
				#endif
				cameraToSetUp.UsePixelCoordinates();
			}
			internal static void ResetCamera (Camera cameraToReset)
			{
				cameraToReset.X = 0;
				cameraToReset.Y = 0;
				cameraToReset.XVelocity = 0;
				cameraToReset.YVelocity = 0;
			}

	}
}
