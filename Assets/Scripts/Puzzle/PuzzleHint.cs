using UnityEngine;

// Pista que ayuda al jugador a encontrar el codigo del cofre.
public class PuzzleHint : MonoBehaviour
{
    [SerializeField, TextArea] private string hintMessage = "El codigo esta escrito detras de la puerta.";
    [SerializeField, TextArea] private string secondHintMessage = "Busca cuatro cifras cerca de la puerta.";
    [SerializeField] private PuzzleManager puzzle;

    private bool shown;
    private bool secondHintShown;

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

    public void ShowSecondHint()
    {
        if (secondHintShown || (puzzle != null && puzzle.IsSolved))
        {
            return;
        }

        secondHintShown = true;
        Debug.Log("Segunda pista: " + secondHintMessage, this);
    }
}
