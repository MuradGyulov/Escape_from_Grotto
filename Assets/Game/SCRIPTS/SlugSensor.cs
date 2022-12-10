using UnityEngine;

public class SlugSensor : MonoBehaviour
{
    [SerializeField] Slug_enemy Slug;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Untagged":
                Slug.Fliip();
                if (Slug.gameObject.transform.localScale.x == -1) { Slug.Mvement_speed = -1; ; }
                if (Slug.gameObject.transform.localScale.x == 1) { Slug.Mvement_speed = 1; }
                break;
            case "Gates":
                Slug.Fliip();
                if (Slug.gameObject.transform.localScale.x == -1) { Slug.Mvement_speed = -1; ; }
                if (Slug.gameObject.transform.localScale.x == 1) { Slug.Mvement_speed = 1; }
                break;
            case "Box":
                Slug.Fliip();
                if (Slug.gameObject.transform.localScale.x == -1) { Slug.Mvement_speed = -1; ; }
                if (Slug.gameObject.transform.localScale.x == 1) { Slug.Mvement_speed = 1; }
                break;
            case "Spike":
                Slug.Fliip();
                if (Slug.gameObject.transform.localScale.x == -1) { Slug.Mvement_speed = -1; ; }
                if (Slug.gameObject.transform.localScale.x == 1) { Slug.Mvement_speed = 1; }
                break;
            case "Slug Sensor":
                Slug.Fliip();
                if (Slug.gameObject.transform.localScale.x == -1) { Slug.Mvement_speed = -1; ; }
                if (Slug.gameObject.transform.localScale.x == 1) { Slug.Mvement_speed = 1; }
                break;

        }
    }
}
