using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectTileBehavior : MonoBehaviour
{
    public float damage;
    public float Speed = 4.5f;
    private int direction = 1;

    public void SetDirection(int dir)
    {
        direction = dir;
    }

    private void Update()
    {
        transform.Translate(Vector2.right * Speed * direction * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Projectile trigger");
        if (other.CompareTag("EnemyTag"))
        {
            BossHealth boss = other.GetComponent<BossHealth>();
            if (boss != null)
            {
                boss.TakeDamage((int)damage);
            }
            Destroy(gameObject); // Hancurkan projectile setelah kena musuh
        }
    }
}
