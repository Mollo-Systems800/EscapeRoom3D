using UnityEngine;

public class OldDoorController : MonoBehaviour
{
    public float openAngle = 90f;
    public float rotationSpeed = 2f;

    private bool isOpen;
    private Quaternion closedRotation;

    private void Awake()
    {
        closedRotation = transform.localRotation;
    }

    public void ToggleDoor()
    {
        isOpen = !isOpen;
    }

    private void Update()
    {
        float angle = isOpen ? openAngle : 0f;
        Quaternion targetRotation = closedRotation * Quaternion.Euler(0f, angle, 0f);
        transform.localRotation = Quaternion.Slerp(
            transform.localRotation,
            targetRotation,
            Time.deltaTime * rotationSpeed);
    }
}
