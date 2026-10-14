using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

// Integrates code validation, limited attempts, and a persistent solve event.
public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private string correctCode = "1234";
    [SerializeField, Min(1)] private int maxAttempts = 3;
    [SerializeField] private string testCode = "1234";

    public UnityEvent onPuzzleSolved = new UnityEvent();

    private int attempts;
    private bool solved;

    public bool IsSolved => solved;
    public int Attempts => attempts;

    public bool TrySolve(string code)
    {
        if (solved)
        {
            return true;
        }

        if (attempts >= maxAttempts)
        {
            Debug.Log("Sin intentos restantes", this);
            return false;
        }

        attempts++;
        if (code == correctCode)
        {
            solved = true;
            Debug.Log("Puzzle resuelto: el cofre se abre", this);
            onPuzzleSolved?.Invoke();
            return true;
        }

        Debug.Log($"Código incorrecto ({attempts}/{maxAttempts})", this);
        return false;
    }

    private void Update()
    {
        Keyboard keyboard = Keyboard.current;
        if (keyboard == null)
        {
            return;
        }

        // 1 submits an incorrect code; Enter submits the configured test code.
        if (keyboard.digit1Key.wasPressedThisFrame)
        {
            TrySolve("0000");
        }

        if (keyboard.enterKey.wasPressedThisFrame || keyboard.numpadEnterKey.wasPressedThisFrame)
        {
            TrySolve(testCode);
        }
    }
}
