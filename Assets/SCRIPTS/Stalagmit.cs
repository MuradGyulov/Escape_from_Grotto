using UnityEngine;

public class Stalagmit : MonoBehaviour
{
    private Rigidbody2D rigid2D;
    private SpriteRenderer spriteRe;
    private Animator animator;
    private PolygonCollider2D polligonCollider;

    [SerializeField] ParticleSystem destroyedParticles;

    private bool falling = false;

    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        spriteRe = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        polligonCollider = GetComponent<PolygonCollider2D>();
    }

    public void SensorWorked()
    {
        falling = true;
        animator.enabled = true;
        Invoke("StalagmitFalling", 0.30f);
    }

    private void StalagmitFalling()
    {
        rigid2D.bodyType = RigidbodyType2D.Dynamic;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (falling && collision.gameObject.tag != "Sleever")
        {
            spriteRe.enabled = false;
            destroyedParticles.Play();
            rigid2D.bodyType = RigidbodyType2D.Static;
            polligonCollider.enabled = false;
            Destroy(this.gameObject, 1f);
        }
    }
}

