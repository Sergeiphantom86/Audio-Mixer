using UnityEngine;
using UnityEngine.UI;

public class ButtonForSound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Button _button;

    private void OnEnable()
    {
        _button.onClick.AddListener(TurnOn);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(TurnOn);
    }

    public void TurnOn()
    {
        _audioSource.Play();
    }
}