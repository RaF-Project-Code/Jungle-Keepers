using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public float health;
    public float currentHealth;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {

        if (currentHealth <= 0)
        {
            anim.SetBool("enemyDead", true);
            Debug.Log("Innalillahi wa inna ilaihi raji'un, telah berpulang ke rahmatullah saudara Enemy, semoga amal ibadahnya diterima di sisi-Nya");
            Destroy(gameObject, 0.75f);

        }
    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public void GetHit(float damage)
    {
        currentHealth -= damage;
        anim.SetTrigger("enemyAttacked");
        Debug.Log("Current Health: " + currentHealth);
    }
}
