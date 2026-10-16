using UnityEngine;

// Estado general del juego. Initialize() prepara la partida y debe ejecutarse UNA sola vez.
public class GameManager : MonoBehaviour
{
    [SerializeField] private Vector3 keySpawnPosition = new Vector3(-3f, 1.2f, 3f);

    public int InitializeCount { get; private set; }

    private void Start()
    {
        // Punto de arranque de la partida: Initialize() se llama UNA sola vez.
        Debug.Log("GameManager: iniciando partida (B)", this);
        Initialize();
    }

    public void Initialize()
    {
        InitializeCount++;
        Debug.Log("GameManager.Initialize() llamada #" + InitializeCount, this);

        if (InitializeCount > 1)
        {
            Debug.LogError("GameManager.Initialize() se ejecutó " + InitializeCount + " veces: lógica duplicada", this);
        }

        // Crea la llave que se obtiene al abrir el cofre.
        GameObject key = GameObject.CreatePrimitive(PrimitiveType.Cube);
        key.name = "Key";
        key.transform.position = keySpawnPosition;
        key.transform.localScale = new Vector3(0.3f, 0.15f, 0.6f);
        key.AddComponent<KeyItem>();
        key.SetActive(false);

        PuzzleManager puzzle = FindFirstObjectByType<PuzzleManager>();
        if (puzzle == null)
        {
            Debug.LogError("GameManager: falta PuzzleManager para entregar la llave", this);
            return;
        }

        puzzle.onPuzzleSolved.AddListener(() => key.SetActive(true));
    }
}
