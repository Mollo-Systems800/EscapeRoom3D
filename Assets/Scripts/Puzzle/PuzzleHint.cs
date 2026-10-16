using UnityEngine;

// Pista que ayuda al jugador a encontrar el codigo del cofre.
public class PuzzleHint : MonoBehaviour
{
    [SerializeField, TextArea] private string hintMessage = "El codigo esta escrito detras de la puerta.";
    [SerializeField] private PuzzleManager puzzle;

    private bool shown;

    public string HintMessage => hintMessage;

    public void ShowHint()
    {
        if (shown || (puzzle != null && puzzle.IsSolved))
        {
            return;
        }

        shown = true;
        Debug.Log("Pista: " + hintMessage, this);
    }
}
