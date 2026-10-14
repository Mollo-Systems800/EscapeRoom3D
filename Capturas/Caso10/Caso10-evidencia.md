# Caso 10 — Dos alumnos crean PuzzleManager.cs (Add/Add)

| Rol | Rama | Acción | Commit |
|---|---|---|---|
| Base | dev | `PuzzleManager.cs` no existe (captura 01) | — |
| A — Implementación A | Feature_Puzzle | `TrySolve(code)` + `IsSolved` | `c672007 feat: add PuzzleManager with code validation (A)` |
| B — Implementación B | Feature_Interaction | `CheckCode(input)` + intentos + `UnityEvent onPuzzleSolved` | `b197606 feat: add PuzzleManager with attempts and event (B)` |
| C — Compara | dev | Merge → `CONFLICT (add/add)`. Se compararon ambas y se escribió una sola clase | Merge commit en dev |
| D — Prueba | dev | PuzzleManager en Chest; tecla 1 → "Código incorrecto (1/3)"; Enter → "Puzzle resuelto: el cofre se abre"; 0 errores | `test: attach PuzzleManager to Chest` |

## Decisión de integración
- Responsabilidades duplicadas: ambas validaban el mismo código (`correctCode` / `solution`) con métodos distintos (`TrySolve` / `CheckCode`).
- Se dejó **un solo método** `TrySolve`, **un solo campo** `correctCode`, y se añadió de B el límite `maxAttempts` y el evento `onPuzzleSolved`.
- Resultado: un único `PuzzleManager.cs`, sin lógica duplicada, Unity compila.

## Capturas
01 base sin PuzzleManager · 02 versión A · 03 versión B · 04 conflicto add/add · 05 Merge Editor con ambas versiones · 06 resultado final · 07 Unity compila (PuzzleManager en Chest) · 08 puzzle funcionando
