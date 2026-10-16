using UnityEngine;

public class OldDoorController : MonoBehaviour
{
    [SerializeField, Range(0f, 180f)] private float openAngle = 90f;
    [SerializeField, Min(0.1f)] private float rotationSpeed = 2f;

    private bool isOpen;
    private Quaternion closedRotation;

    public bool IsOpen => isOpen;

    private void Awake()
    {
        closedRotation = transform.localRotation;
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
        float targetAngle = isOpen ? openAngle : 0f;
        Quaternion targetRotation = closedRotation * Quaternion.Euler(0f, targetAngle, 0f);
        transform.localRotation = Quaternion.Slerp(
            transform.localRotation,
            targetRotation,
            Time.deltaTime * rotationSpeed);
    }
}
