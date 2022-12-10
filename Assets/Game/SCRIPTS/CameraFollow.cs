using UnityEngine;
using YG;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private float smoothSpeed;
    [SerializeField] private Vector3 offset;
    [Space(12)]
    [SerializeField] private Camera cameraComponent;

    private void Start()
    {
        cameraComponent.orthographicSize = YandexGame.savesData.cameraSize;
    }

    private void FixedUpdate()
    {
        Vector3 desiredPosition = Player.position + offset;
        Vector3 smothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smothPosition;
    }
}
