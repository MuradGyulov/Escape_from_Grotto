using UnityEngine;

public class CainionAmmo : MonoBehaviour
{
    [Header("Canion ammo characteristics")]
    [SerializeField] float Ammo_speed;
    [SerializeField] float Ammo_life_time;

    [Header("Canion ammo particle effects")]
    [SerializeField] ParticleSystem Explosion_particles;
    [SerializeField] ParticleSystem Trail_particles;

    private Rigidbody2D rigidbody2;
    private SpriteRenderer spritErenderer;
    private BoxCollider2D boxCollider;
    


    private void Awake()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
        spritErenderer = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();

        Destroy(this.gameObject, Ammo_life_time);
    }

    private void FixedUpdate()
    {
        rigidbody2.velocity = transform.right * Ammo_speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Untagged":
                spritErenderer.enabled = false;
                boxCollider.enabled = false;
                Trail_particles.Stop();
                Explosion_particles.Play();
                Ammo_speed = 0;
                Destroy(this.gameObject, 1f);
                break;
            case "Player":
                spritErenderer.enabled = false;
                boxCollider.enabled = false;
                Trail_particles.Stop();
                Explosion_particles.Play();
                Ammo_speed = 0;
                Destroy(this.gameObject, 1f);
                break;
            case "Box":
                spritErenderer.enabled = false;
                boxCollider.enabled = false;
                Trail_particles.Stop();
                Explosion_particles.Play();
                Ammo_speed = 0;
                Destroy(this.gameObject, 1f);
                break;
            case "Stalagmit":
                spritErenderer.enabled = false;
                boxCollider.enabled = false;
                Trail_particles.Stop();
                Explosion_particles.Play();
                Ammo_speed = 0;
                Destroy(this.gameObject, 1f);
                break;
            case "Canion Ammo":
                spritErenderer.enabled = false;
                boxCollider.enabled = false;
                Trail_particles.Stop();
                Explosion_particles.Play();
                Ammo_speed = 0;
                Destroy(this.gameObject, 1f);
                break;
        }
    }
}
