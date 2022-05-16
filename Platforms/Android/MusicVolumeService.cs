using Android.Media;

namespace AudioDuck
{
    public class MusicVolumeService : IMusicVolumeService
    {
        AudioManager _audioManager;

        public bool IsMuted => _audioManager.IsStreamMute(Stream.Music);

        public MusicVolumeService() 
        {
            _audioManager = AudioManager.FromContext(MainApplication.Current.ApplicationContext);
        }

        public int GetCurrentVolume()
        {
            return _audioManager.GetStreamVolume(Stream.Music);
        }

        public void ToggleMute()
        {
            if (IsMuted)
            {
                _audioManager.AdjustStreamVolume(Stream.Music, Adjust.Unmute, 0);
            }
            else
            {
                _audioManager.AdjustStreamVolume(Stream.Music, Adjust.Mute, 0);
            }
        }

        public void SetCurrentVolume(int volume)
        {
            _audioManager.SetStreamVolume(Stream.Music, volume, 0);
        }

        public int IncrementVolume()
        {
            _audioManager.AdjustStreamVolume(Stream.Music, Adjust.Raise, 0);
            return GetCurrentVolume(); 
        }

        public int DecrementVolume()
        {
            // For some reason, AdjustStreamVolume with Adjust.Lower doesn't seem to work
            var current = GetCurrentVolume();
            _audioManager.SetStreamVolume(Stream.Music, current - 1, 0);
            return GetCurrentVolume();
        }
    }
}