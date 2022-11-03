using UnityEngine;

public class Slug_enemy : MonoBehaviour
{
    [Header("Slug characteristics")]
    [SerializeField] int Health;
    [HideInInspector] public float Mvement_speed;
    
    private Rigidbody2D rigidBody2D;
    private Animator slugAnimatior;
    private CapsuleCollider2D capsuleCollider;

    private bool fachingRight;
    private bool slugDead = false;

    private void Start()
    {

        rigidBody2D = GetComponent<Rigidbody2D>();
        slugAnimatior = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Health--;
            if(Health <= 0) { SlugDead(); }
            slugAnimatior.SetBool("BulletHit", true);
            Invoke("ReturnMoveAnimation", 0.07f);
        }
    }

    private void ReturnMoveAnimation()
    {
        slugAnimatior.SetBool("BulletHit", false);
    }

    private void FixedUpdate()
    {
        if (!slugDead)
        {
            rigidBody2D.velocity = new Vector2(Mvement_speed, 0);
        }
    }

    private void SlugDead()
    {
        Mvement_speed = 0;
        slugAnimatior.SetBool("SlugDead", true);
        rigidBody2D.bodyType = RigidbodyType2D.Static;
        slugDead = true;
        capsuleCollider.enabled = false;
        Destroy(this.gameObject, 1.10f);
    }

    public void Fliip()
    {
        fachingRight = !fachingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
