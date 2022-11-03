using UnityEngine;

public class PlayerMusic : MonoBehaviour
{
    private static PlayerMusic playerInstance;

    void Start()
    {
        DontDestroyOnLoad(this);

        if (playerInstance == null)
        {
            playerInstance = this;
        }
        else
        {
            Object.Destroy(gameObject);
        }
    }
}
