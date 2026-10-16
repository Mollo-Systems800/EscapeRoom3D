using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float interactionDistance = 3f;

    private bool hasExitKey;

    public bool HasExitKey => hasExitKey;

    private void Update()
    {
        Keyboard keyboard = Keyboard.current;
        if (keyboard != null && keyboard.eKey.wasPressedThisFrame)
        {
            TryInteract();
        }
    }

    private void TryInteract()
    {
        Collider[] nearby = Physics.OverlapSphere(transform.position, interactionDistance);
        KeyItem nearestKey = null;
        OldDoorController nearestDoor = null;
        float nearestDistance = float.MaxValue;

        foreach (Collider hit in nearby)
        {
            KeyItem key = hit.GetComponentInParent<KeyItem>();
            OldDoorController door = hit.GetComponentInParent<OldDoorController>();
            if (key == null && door == null)
            {
                continue;
            }

            float distance = Vector3.Distance(transform.position, hit.ClosestPoint(transform.position));
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestKey = key;
                nearestDoor = door;
            }
        }

        if (nearestKey != null)
        {
            nearestKey.Collect();
            hasExitKey = true;
        }
        else if (nearestDoor != null)
        {
            if (hasExitKey)
            {
                nearestDoor.SetOpen(true);
                Debug.Log("Puerta de salida abierta", nearestDoor);
            }
            else
            {
                Debug.Log("Necesitas la llave del cofre para abrir la puerta", nearestDoor);
            }
        }
    }
}
