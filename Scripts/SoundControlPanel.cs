using UnityEngine;
using UnityEngine.Audio;

public class SoundControlPanel : MonoBehaviour
{
    public const string MasterVolume = nameof(MasterVolume);
    public const string SoundVolume = nameof(SoundVolume);
    public const string MusicVolume = nameof(MusicVolume);

    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private AudioSource _audioSource;

    private float _volumeBackgroundMusic;

    public void Toggle(bool enabled)
    {
        if (enabled)
        {
            ChangeVolume(MasterVolume, _audioSource.volume);
        }
        else
        {
            int volumeOff = -80;

            ChangeVolume(MasterVolume, volumeOff);
        }
    }

    public void ChangeMasterVolume(float volume)
    {
        _audioSource.volume = volume;

        ChangeVolume(MasterVolume, _audioSource.volume);
    }

    public void ChangeVolumeButtons(float volume)
    {
        ChangeVolume(SoundVolume, volume);
    }

    public void ChangeVolumeBackgroundMusic(float volume)
    {
        _volumeBackgroundMusic = volume;

        ChangeVolume(MusicVolume, _volumeBackgroundMusic);
    }

    private void ChangeVolume(string nameMixer, float volume)
    {
        _mixer.audioMixer.SetFloat(nameMixer, Mathf.Log10(volume) * 20);
    }
}