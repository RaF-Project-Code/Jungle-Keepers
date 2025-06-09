using UnityEngine;

public class audioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("Audio Clip")]
    public AudioClip background;
    public AudioClip sword;
    public AudioClip walking;
    public AudioClip jumping;
    public AudioClip babi;
    public AudioClip beruang;
    public AudioClip beruangfase2;
    public AudioClip beruanggigit;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clipAudio)
    {
        // SFXSource.clip = clipAudio;
        // SFXSource.Play();
        SFXSource.PlayOneShot(clipAudio);
    }

    public void StopSFX()
    {
        SFXSource.Stop();
    }

}
