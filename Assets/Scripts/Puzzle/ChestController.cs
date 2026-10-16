using UnityEngine;

public class ChestController : MonoBehaviour
{
    [SerializeField] private Transform lidPivot;
    [SerializeField, Range(-120f, -45f)] private float openAngle = -100f;
    [SerializeField, Min(0.1f)] private float openingSpeed = 4f;

    private Quaternion closedRotation;
    private bool isOpen;

    public bool IsOpen => isOpen;

    private void Awake()
    {
        CacheClosedRotation();
    }

    private void OnEnable()
    {
        CacheClosedRotation();
    }

    public void OpenChest()
    {
        if (lidPivot == null)
        {
            Debug.LogError("ChestController requires a lid pivot.", this);
            return;
        }

        isOpen = true;
    }

    private void Update()
    {
        if (lidPivot == null)
        {
            return;
        }

        Quaternion targetRotation = isOpen
            ? closedRotation * Quaternion.Euler(openAngle, 0f, 0f)
            : closedRotation;
        lidPivot.localRotation = Quaternion.Slerp(
            lidPivot.localRotation,
            targetRotation,
            Time.deltaTime * openingSpeed);
    }

    private void CacheClosedRotation()
    {
        if (lidPivot != null)
        {
            closedRotation = lidPivot.localRotation;
        }
    }
}
