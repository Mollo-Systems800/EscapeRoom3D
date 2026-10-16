using UnityEngine;

// Llave que entrega el cofre al resolver el puzzle; la puerta la necesita para abrirse.
public class KeyItem : MonoBehaviour
{
    [SerializeField] private string keyId = "ExitKey";

    private bool collected;

    public string KeyId => keyId;
    public bool IsCollected => collected;

    public void Collect()
    {
        if (collected)
        {
            return;
        }

        collected = true;
        Debug.Log("Llave obtenida: " + keyId, this);
        gameObject.SetActive(false);
    }
}
