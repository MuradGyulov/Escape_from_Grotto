using System.Collections;
using UnityEngine;

public class Canion : MonoBehaviour
{
    [Header("Canion characteristics")]
    [SerializeField] float Fire_rate;

    [Header("Canion ammo")]
    [SerializeField] GameObject Ammo;

    private void Awake()
    {
        StartCoroutine(Shooting());
    }

    private IEnumerator Shooting()
    {
        while (true)
        {
            Instantiate(Ammo, transform.position, transform.rotation);
            yield return new WaitForSeconds(Fire_rate);
        }
    }
}
