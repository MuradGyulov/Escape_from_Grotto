using UnityEngine;
using UnityEngine.Events;

public class StalagmitSensor : MonoBehaviour
{
    [SerializeField] UnityEvent SensorWorked;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SensorWorked.Invoke();
            Destroy(this.gameObject);
        }
    }
}
