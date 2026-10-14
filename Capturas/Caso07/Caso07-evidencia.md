# Caso 07 — Conflicto en Player.prefab

| Rol | Rama | Acción | Commit |
|---|---|---|---|
| Base | dev | Crear `Assets/Prefabs/Player.prefab` (Capsule + PlayerController) | `789bc97 feat: add Player prefab` |
| A — Movimiento | Feature_PlayerMovement | Speed 5 → 8 y Rigidbody | `ab3120e feat: configure player movement in prefab` |
| B — Animator | Feature_Animation | Animator en el Prefab | `f91b9da feat: add Animator to Player prefab` |
| C — Integra | dev | Merge → conflicto en Player.prefab; Merge Editor, *Accept Combination* en los 2 conflictos | `9aa3f3d Merge branch 'Feature_Animation' into dev` |
| D — QA | dev | Inspector: PlayerController (8), Rigidbody y Animator; sin Missing | — |

**Observación:** en Play Mode apareció `InvalidOperationException` porque *Active Input Handling* estaba en *Input System Package* y PlayerController usa `UnityEngine.Input`.

## Capturas
01 base · 02 A · 03 B · 04 conflicto · 05 Merge Editor · 06 Inspector · 07 Play Mode · 08 merge y push
