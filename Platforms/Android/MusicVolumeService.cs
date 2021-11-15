using Android.Media;

namespace AudioDuck
{
    public class MusicVolumeService : IMusicVolumeService
    {
        AudioManager _audioManager;

        public MusicVolumeService() 
        {
            _audioManager = AudioManager.FromContext(MainApplication.Current.ApplicationContext);
        }

        public int GetCurrentVolume()
        {
            return _audioManager.GetStreamVolume(Stream.Music);
        }

        public void SetCurrentVolume(int volume)
        {
            _audioManager.SetStreamVolume(Stream.Music, volume, VolumeNotificationFlags.ShowUi);
        }
    }
}