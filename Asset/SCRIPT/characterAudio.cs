using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterAudio : MonoBehaviour
{
    public audioManager AudioManager;

    public void WalkingSound()
    {
        AudioManager.PlaySFX(AudioManager.walking);
    }

    public void SwordSound()
    {
        AudioManager.PlaySFX(AudioManager.sword);
    }

    public void JumpSound()
    {
        AudioManager.PlaySFX(AudioManager.jumping);
    }
}
