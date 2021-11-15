namespace AudioDuck
{
    public interface IMusicVolumeService
	{
		int GetCurrentVolume();
		void SetCurrentVolume(int volume);	
	}
}