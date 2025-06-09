using Unity.VisualScripting;
using UnityEngine;

public class characterMovement : MonoBehaviour
{
    private float Move;
    private float speed = 7f;
    private float jumpingPower = 16f;
    private bool isFacingRight;
    private SpriteRenderer spriteRender;
    private int jumpCount;
    private int maxJumps = 1;

    // Buat Cooldown Nembak
    private bool canShoot = true;
    private float shootCooldown = 4f;
    private float shootTimer = 0f;

    [Header("BUAT NYERANG")]
    public GameObject attackPoint;
    public float radius;
    public LayerMask enemies;
    public float damage;

    [Header("BUAT BULLET PROJECTILE")]
    public projectTileBehavior projectilePrefab;
    public Transform launchOffset;
    public float damageProjectile;


    private Animator anim;

    [Header("RIGIDBODY & GROUND CHECK")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    // private bool isWalkingSoundPlaying = false;
    // private bool isAttackkingSound = false;



    void Start()
    {
        isFacingRight = true;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRender = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Move = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && jumpCount < maxJumps)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            jumpCount++;
        }

        // Reset jump count saat karakter menyentuh tanah
        if (IsGrounded())
        {
            jumpCount = 0;
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        if (Move != 0)
        {
            anim.SetBool("isRunning", true);

            // if (!isWalkingSoundPlaying)
            // {
            //     audioManager.PlaySFX(audioManager.walking);
            //     isWalkingSoundPlaying = true;
            // }
        }
        else
        {
            anim.SetBool("isRunning", false);
            // isWalkingSoundPlaying = false;
            // audioManager.StopSFX();
        }
        anim.SetBool("isJumping", !IsGrounded());

        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl)) // (Input.GetMouseButtonDown(0)) Buat nyerang pake klik mouse
        {
            anim.SetBool("isAttacking", true);
            // audioManager.PlaySFX(audioManager.sword);
        }

        if (!isFacingRight && Move > 0)
        {
            Flip();
        }
        else if (isFacingRight && Move < 0)
        {
            Flip();
        }

        // Cooldown untuk nembak
        if (!canShoot)
        {
            shootTimer += Time.deltaTime;
            if (shootTimer >= shootCooldown)
            {
                canShoot = true;
                shootTimer = 0f;
            }
        }

        // Buat nembak projectile
        if (Input.GetKeyDown(KeyCode.RightAlt) && canShoot)
        {
            var projectile = Instantiate(projectilePrefab, launchOffset.position, transform.rotation);
            projectile.damage = damageProjectile; // Set damage dari variabel di characterMovement

            int dir = isFacingRight ? 1 : -1;
            projectile.SetDirection(dir);

            // Jika karakter menghadap kiri, flip projectile di sumbu X
            if (!isFacingRight)
            {
                Vector3 scale = projectile.transform.localScale;
                scale.x *= -1;
                projectile.transform.localScale = scale;
            }

            // Cek apakah bisa nembak
            canShoot = false;
            shootTimer = 0f;
        }

    }

    public void attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, enemies);

        foreach (Collider2D hit in hitEnemies)
        {
            Debug.Log("Hit Enemy");

            // Cek dan hit musuh biasa
            enemyHealth enemy = hit.GetComponent<enemyHealth>();
            if (enemy != null)
            {
                enemy.GetHit(damage);
            }

            // Cek dan hit boss
            BossHealth boss = hit.GetComponent<BossHealth>();
            if (boss != null)
            {
                boss.TakeDamage((int)damage);
            }
        }
    }

    public void AttackEnd()
    {
        anim.SetBool("isAttacking", false);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.transform.position, radius);
    }

    public void Flip()
    {
        isFacingRight = !isFacingRight;
        spriteRender.flipX = !spriteRender.flipX; // Membalikkan sprite pada sumbu X

        Vector3 offsetPos = launchOffset.localPosition;
        offsetPos.x *= -1;
        launchOffset.localPosition = offsetPos;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(Move * speed, rb.velocity.y);

        if (IsGrounded() && Move != 0)
        {
            rb.AddForce(new Vector2(Move * 0.1f, 0), ForceMode2D.Impulse);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
}