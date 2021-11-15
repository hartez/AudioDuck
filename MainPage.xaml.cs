using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Essentials;

namespace AudioDuck
{
	public partial class MainPage : ContentPage
	{
		int _lowVolume = 2;
		int _highVolume = 7;
		bool _onHigh;

		IMusicVolumeService _volumeService;

		IMusicVolumeService VolumeService
        {
			get 
			{
#if ANDROID
				return _volumeService;
#else
				return null;
#endif
			}
		}

		public MainPage(IMusicVolumeService volumeService)
		{
			InitializeComponent();

			_volumeService = volumeService;

			ToggleButton.Clicked += Toggle;
			SetHighVolume.Clicked += SetHigh;
			SetLowVolume.Clicked += SetLow;

			UpdateVolumeLabels();
		}

		private void SetHigh(object sender, EventArgs e) 
		{
			_highVolume = VolumeService.GetCurrentVolume();
			UpdateVolumeLabels();
		}

		private void SetLow(object sender, EventArgs e)
		{
			_lowVolume = VolumeService.GetCurrentVolume();
			UpdateVolumeLabels();
		}

		void UpdateVolumeLabels() 
		{
			HighVolume.Text = _highVolume.ToString();
			LowVolume.Text = _lowVolume.ToString();
		}

		private void Toggle(object sender, EventArgs e)
        {
			if (_onHigh)
			{
				_onHigh = false;
				VolumeService.SetCurrentVolume(_lowVolume);
				ToggleButton.Text = "Get Loud";
			}
			else
			{
				_onHigh = true;
				VolumeService.SetCurrentVolume(_highVolume);
				ToggleButton.Text = "Get Quiet";
			}
		}
    }
}
