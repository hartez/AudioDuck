namespace AudioDuck
{
    public interface IMusicVolumeService
	{
		int GetCurrentVolume();
		void SetCurrentVolume(int volume);
		bool IsMuted { get; }
		void ToggleMute();
		int IncrementVolume();
		int DecrementVolume();
	}
}