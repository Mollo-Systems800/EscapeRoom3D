using UnityEngine;
using UnityEngine.InputSystem;

public class OldDoorController : MonoBehaviour
{
    [SerializeField, Range(0f, 180f)] private float openAngle = 90f;
    [SerializeField, Min(0.1f)] private float rotationSpeed = 2f;
    [SerializeField, Min(0.1f)] private float interactionDistance = 3.5f;

    private bool isOpen;
    private Quaternion closedRotation;
    private Transform player;

    public bool IsOpen => isOpen;

    private void Awake()
    {
        closedRotation = transform.localRotation;
        GameObject playerObject = GameObject.Find("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    public void ToggleDoor()
    {
        isOpen = !isOpen;
    }

    public void SetOpen(bool open)
    {
        isOpen = open;
    }

    private void Update()
    {
        Keyboard keyboard = Keyboard.current;
        if (keyboard != null && keyboard.eKey.wasPressedThisFrame && player != null
            && Vector3.Distance(player.position, transform.position) >= interactionDistance)
        {
            ToggleDoor();
        }

        float targetAngle = isOpen ? openAngle : 0f;
        Quaternion targetRotation = closedRotation * Quaternion.Euler(0f, targetAngle, 0f);
        transform.localRotation = Quaternion.Slerp(
            transform.localRotation,
            targetRotation,
            Time.deltaTime * rotationSpeed);
    }
}
