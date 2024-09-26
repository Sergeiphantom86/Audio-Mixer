using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    public void TurnOn()
    {
        _audioSource.Play();
    }
}