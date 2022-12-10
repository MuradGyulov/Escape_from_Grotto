using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet characteristics")]
    [SerializeField] float Bullet_speed;

    [Header("Bullet particles")]
    [SerializeField] ParticleSystem Enemy_hit_particles;
    [SerializeField] ParticleSystem Wall_hit_particles;
    [SerializeField] ParticleSystem Bullet_traill;

    private Rigidbody2D RB2D;
    private SpriteRenderer spriterRend;
    private BoxCollider2D boxCollider2D;

    private void Awake()
    {
        RB2D = GetComponent<Rigidbody2D>();
        spriterRend = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();

        Bullet_traill.Play();
        Destroy(this.gameObject, 2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "Host" && collision.gameObject.tag != "Host sensor")
        {
           // Destroy(this.gameObject);
        }

        switch (collision.gameObject.tag)
        {
            case "Untagged":
                Bullet_speed = 0;
                spriterRend.enabled = false;
                boxCollider2D.enabled = false;
                Bullet_traill.Stop();
                Wall_hit_particles.Play();
                break;
            case "Box":
                Bullet_speed = 0;
                spriterRend.enabled = false;
                boxCollider2D.enabled = false;
                Bullet_traill.Stop();
                Wall_hit_particles.Play();
                break;
            case "Spike":
                Bullet_speed = 0;
                spriterRend.enabled = false;
                boxCollider2D.enabled = false;
                Bullet_traill.Stop();
                Wall_hit_particles.Play();
                break;
            case "Stalagmit":
                Bullet_speed = 0;
                spriterRend.enabled = false;
                boxCollider2D.enabled = false;
                Bullet_traill.Stop();
                Wall_hit_particles.Play();
                break;
            case "Slug":
                Bullet_speed = 0;
                spriterRend.enabled = false;
                boxCollider2D.enabled = false;
                Bullet_traill.Stop();
                Enemy_hit_particles.Play();
                break;
            case "Gates":
                break;

        }
    }

    private void FixedUpdate()
    {
        RB2D.velocity = transform.right * Bullet_speed;
    }
}
