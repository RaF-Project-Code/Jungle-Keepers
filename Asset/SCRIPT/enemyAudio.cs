using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAudio : MonoBehaviour
{
    public audioManager AudioManager;

    public void PigDie()
    {
        AudioManager.PlaySFX(AudioManager.babi);
    }
}
