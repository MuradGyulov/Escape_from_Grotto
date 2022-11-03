using UnityEngine;

public class Sleveer : MonoBehaviour
{
    [Header("Slever characteristics")]
    [SerializeField] float Slever_life_time;
    private float Push_force;

    private Rigidbody2D rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();


        Push_force = Random.Range(0.225f, 0.26f);
        rigid.AddForce(transform.up * Push_force, ForceMode2D.Impulse);

        Destroy(this.gameObject, 2f);
    }
}
