using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioPanel : MonoBehaviour
{
    public const string MasterVolume = nameof(MasterVolume);

    [SerializeField] private Toggle _toggle;
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private AudioSource _source;
    [SerializeField] private VolumeChanger _masterVolume;
    [SerializeField] private VolumeChanger _soundVolume;
    [SerializeField] private VolumeChanger _backgroundMusicVolume;

    private float _volume = 1;
    private float _volumeTurnedOff = 0.0001f;

    private void OnEnable()
    {
        _masterVolume.OnVolumeChange += ChangeVolume;
        _soundVolume.OnVolumeChange += ChangeVolume;
        _backgroundMusicVolume.OnVolumeChange += ChangeVolume;

        _toggle.onValueChanged.AddListener(TurnOff);

        _source.volume = _volume;
    }

    private void OnDisable()
    {
        _masterVolume.OnVolumeChange -= ChangeVolume;
        _soundVolume.OnVolumeChange -= ChangeVolume;
        _backgroundMusicVolume.OnVolumeChange -= ChangeVolume;

        _toggle.onValueChanged.RemoveListener(TurnOff);
    }

    private void ChangeVolume(string name, float volume)
    {
        _volume = volume;   

        if (volume >= _volumeTurnedOff)
        {
            _mixer.SetFloat(name, Mathf.Log10(volume) * 20);
        }

        ReplaceValueInToggle();
    }

    private void ReplaceValueInToggle()
    {
        if (_source.volume > _volumeTurnedOff)
        {
            _toggle.isOn = false;
        }
    }

    private void TurnOff(bool isTurnOff)
    {
        if (isTurnOff)
        {
            _mixer.SetFloat(_masterVolume.name, Mathf.Log10(_volumeTurnedOff) * 20);
        }
        else
        {
            TurnOn(_masterVolume.name, _volume);
        }
    }

    private void TurnOn(string name, float volume)
    {
        ChangeVolume(name, volume);
    }
}