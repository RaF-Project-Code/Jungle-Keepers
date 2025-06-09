using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemBatuBehavior : MonoBehaviour
{

    [Header("Tag dari player (misalnya 'Player')")]
    public string playerTag = "Player";


    private void OnTriggerEnter2D(Collider2D other)
    {
        // Ketika player masuk ke collider
        if (other.CompareTag(playerTag))
        {
            playerManager.isItemTaken = true;
            Destroy(gameObject);
        }
    }
}
