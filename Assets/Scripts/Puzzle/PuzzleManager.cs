using UnityEngine;
using UnityEngine.Events;

// Versión integrada (Caso 10): une la validación de código de A
// con el control de intentos y el evento de B en un solo PuzzleManager.
public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private string correctCode = "1234";
    [SerializeField] private int maxAttempts = 3;
    public UnityEvent onPuzzleSolved;

    [Header("Prueba en Play Mode")]
    [SerializeField] private string testCode = "1234";

    private int attempts;
    private bool solved;

    public bool IsSolved => solved;

    public bool TrySolve(string code)
    {
        if (solved) return true;

        if (attempts >= maxAttempts)
        {
            Debug.Log("Sin intentos restantes");
            return false;
        }

        attempts++;

        if (code == correctCode)
        {
            solved = true;
            Debug.Log("Puzzle resuelto: el cofre se abre");
            onPuzzleSolved?.Invoke();
        }
        else
        {
            Debug.Log("Código incorrecto (" + attempts + "/" + maxAttempts + ")");
        }

        return solved;
    }

    private void Update()
    {
        // 1 = código incorrecto, Enter = código de prueba
        if (Input.GetKeyDown(KeyCode.Alpha1)) TrySolve("0000");
        if (Input.GetKeyDown(KeyCode.Return)) TrySolve(testCode);
    }
}
