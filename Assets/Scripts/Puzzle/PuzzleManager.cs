using UnityEngine;

// Implementación A: valida un código numérico para abrir el cofre.
public class PuzzleManager : MonoBehaviour
{
    [SerializeField] private string correctCode = "1234";
    private bool solved;

    public bool IsSolved => solved;

    public bool TrySolve(string code)
    {
        if (solved) return true;

        solved = code == correctCode;
        Debug.Log(solved ? "Puzzle resuelto: el cofre se abre" : "Código incorrecto");
        return solved;
    }
}
