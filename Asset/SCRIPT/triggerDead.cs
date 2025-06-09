using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerDead : MonoBehaviour
{
    public characterCollision hm;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && hm != null)
        {
            // Kurangi semua health player sebelum destroy
            //characterCollision2 hm = FindObjectOfType<characterCollision2>();
            hm.InstantDamage(); // Kurangi health sebanyak sisa nyawa
        }
    }
}