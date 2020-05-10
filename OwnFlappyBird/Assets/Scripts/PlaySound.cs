using UnityEngine;
using UnityEngine.Audio;

public class PlaySound : MonoBehaviour
{
    public AudioSource coinSound;
    public AudioSource buttonSound;


    public void PlayCoinSound()
    {
        coinSound.Play();
    }

    public void PlayButtonSound()
    {
    buttonSound.Play();
    }


}
