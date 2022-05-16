using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

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

            DecrementHigh.Clicked += DecrementHighVolume;
            IncrementHigh.Clicked += IncrementHighVolume;

            DecrementLow.Clicked += DecrementLowVolume;
            IncrementLow.Clicked += IncrementLowVolume;

            Mute.Clicked += ToggleMute;

			// Start out at default low volume
			_onHigh = true;
			Toggle();
		}

        private void DecrementHighVolume(object sender, EventArgs e)
        {
            _volumeService.SetCurrentVolume(_highVolume);
            _highVolume = _volumeService.DecrementVolume();
            _onHigh = true;
            UpdateUI();
        }

        private void IncrementHighVolume(object sender, EventArgs e)
        {
            _volumeService.SetCurrentVolume(_highVolume);
            _highVolume = _volumeService.IncrementVolume();
            _onHigh = true;
            UpdateUI();
        }

        private void DecrementLowVolume(object sender, EventArgs e)
        {
            _volumeService.SetCurrentVolume(_lowVolume);
            if (_lowVolume > 1)
            {
                _lowVolume = _volumeService.DecrementVolume();
            }
            _onHigh = false;
            UpdateUI();
        }

        private void IncrementLowVolume(object sender, EventArgs e)
        {
            _volumeService.SetCurrentVolume(_lowVolume);
            _lowVolume = _volumeService.IncrementVolume();
            _onHigh = false;
            UpdateUI();
        }

        private void ToggleMute(object sender, EventArgs e)
        {
			VolumeService.ToggleMute();
			UpdateUI();
        }

        private void SetHigh(object sender, EventArgs e) 
		{
			_highVolume = VolumeService.GetCurrentVolume();
			UpdateUI();
		}

		private void SetLow(object sender, EventArgs e)
		{
			SetLow();
		}

		private void SetLow() 
		{
            _lowVolume = VolumeService.GetCurrentVolume();
            UpdateUI();
        }

		void UpdateUI() 
		{
			HighVolume.Text = _highVolume.ToString();
			LowVolume.Text = _lowVolume.ToString();

            if (VolumeService.IsMuted)
            {
                Mute.Text = "Unmute";
            }
            else
            {
                Mute.Text = "Mute";
            }

			if (_onHigh)
			{
                ToggleButton.Text = "Get Quiet";
            }
			else 
			{
                ToggleButton.Text = "Get Loud";
            }
        }

		private void Toggle(object sender, EventArgs e)
        {
			Toggle();
		}

        private void Toggle()
        {
            if (_onHigh)
            {
                _onHigh = false;
                VolumeService.SetCurrentVolume(_lowVolume);
            }
            else
            {
                _onHigh = true;
                VolumeService.SetCurrentVolume(_highVolume);
            }

            UpdateUI();
        }
    }
}
