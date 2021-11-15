using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;
using Application = Microsoft.Maui.Controls.Application;

namespace AudioDuck
{
	public partial class App : Application
	{
		public App(IMusicVolumeService musicVolumeService)
		{
			InitializeComponent();
			MainPage = new MainPage(musicVolumeService);
		}
	}
}
