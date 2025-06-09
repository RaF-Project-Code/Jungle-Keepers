using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAudio : MonoBehaviour
{
    public audioManager AudioManager;

    public void BeruangRawr()
    {
        AudioManager.PlaySFX(AudioManager.beruang);
    }

    public void BeruangRawr2()
    {
        AudioManager.PlaySFX(AudioManager.beruangfase2);
    }

    public void BeruangGigit()
    {
        AudioManager.PlaySFX(AudioManager.beruanggigit);
    }

    public void StopBeruangGigit()
    {
        AudioManager.StopSFX();
    }
}
