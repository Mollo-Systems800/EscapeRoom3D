using UnityEngine;
using UnityEngine.Events;

// Implementación B: cuenta intentos y avisa cuando se resuelve el puzzle.
public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private string solution = "1234";
    [SerializeField] private int maxAttempts = 3;
    public UnityEvent onPuzzleSolved;

    private int attempts;

    public void CheckCode(string input)
    {
        attempts++;

        if (input == solution)
        {
            Debug.Log("Cofre desbloqueado");
            onPuzzleSolved?.Invoke();
        }
        else if (attempts >= maxAttempts)
        {
            Debug.Log("Sin intentos restantes");
        }
        else
        {
            Debug.Log("Intento fallido " + attempts + "/" + maxAttempts);
        }
    }
}
