using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class characterCollision : MonoBehaviour
{
    public healthManager healthManager;

    void Start()
    {
        healthManager = FindObjectOfType<healthManager>();
    }

    public void TakeDamage(int damage)
    {
        if (transform.tag == "Player")
        {
            healthManager.health--;
            if (healthManager.health <= 0)
            {
                playerManager.isGameOver = true;
                gameObject.SetActive(false);
            }
            else
            {
                StartCoroutine(GetHurt());
            }
        }
    }

    public void InstantDamage()
    {
        if (transform.tag == "Player")
        {
            healthManager.health = 0;
            playerManager.isGameOver = true;
            gameObject.SetActive(false);
        }
    }
    
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "EnemyTag")
        {
            healthManager.health--;
            if (healthManager.health <= 0)
            {
                playerManager.isGameOver = true;
                gameObject.SetActive(false);
            }
            else
            {
                StartCoroutine(GetHurt());
            }
        }
    }

    IEnumerator GetHurt()
    {
        Physics2D.IgnoreLayerCollision(3,7);
        GetComponent<Animator>().SetLayerWeight(1,1);
        yield return new WaitForSeconds(3);
        GetComponent<Animator>().SetLayerWeight(1,0);
        Physics2D.IgnoreLayerCollision(3,7,false); 
    }
}