using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float interactionDistance = 3f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) TryInteract();
    }

    private void TryInteract()
    {
        Debug.Log("Buscando objeto interactuable...");
    }
}