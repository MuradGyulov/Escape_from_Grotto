using UnityEngine;

public class Host_sensor : MonoBehaviour
{
    [SerializeField] Host_enemy Host;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Untagged":
                Host.Fliip();
                if (Host.gameObject.transform.localScale.x == -1) { Host.Mvement_speed = -1; ; }
                if (Host.gameObject.transform.localScale.x == 1) { Host.Mvement_speed = 1; }
                break;
            case "Gates":
                Host.Fliip();
                if (Host.gameObject.transform.localScale.x == -1) { Host.Mvement_speed = -1; ; }
                if (Host.gameObject.transform.localScale.x == 1) { Host.Mvement_speed = 1; }
                break;
            case "Box":
                Host.Fliip();
                if (Host.gameObject.transform.localScale.x == -1) { Host.Mvement_speed = -1; ; }
                if (Host.gameObject.transform.localScale.x == 1) { Host.Mvement_speed = 1; }
                break;
            case "Spike":
                Host.Fliip();
                if (Host.gameObject.transform.localScale.x == -1) { Host.Mvement_speed = -1; ; }
                if (Host.gameObject.transform.localScale.x == 1) { Host.Mvement_speed = 1; }
                break;

        }
    }
}
