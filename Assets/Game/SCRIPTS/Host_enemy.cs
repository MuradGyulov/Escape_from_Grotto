using UnityEngine;

public class Host_enemy : MonoBehaviour
{
    [HideInInspector] public int Mvement_speed;

    private Rigidbody2D rigidBody2D;

    private bool fachingRight;

    private void Start()
    {
        Mvement_speed = 1;
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rigidBody2D.velocity = new Vector2(Mvement_speed, 0);
    }


    public void Fliip()
    {
        fachingRight = !fachingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
