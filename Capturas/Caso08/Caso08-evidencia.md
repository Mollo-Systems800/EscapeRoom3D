# Caso 08 — Conflicto en MainScene.unity

| Rol | Rama | Acción | Commit |
|---|---|---|---|
| Base | dev | Player en MainScene | `6d5b29b chore: add Player to MainScene base` |
| A — Cofre | Feature_Interaction | Chest en (-3, 0.5, 3) | `8bbc021 feat: add Chest to MainScene` |
| B — Puerta | Feature_Animation | Door en (3, 1, 5), escala 1.2×2×0.2 | `f7b8b40 feat: add Door to MainScene` |
| C — Integra | dev | Conflicto en MainScene.unity (bloque de GameObject y `SceneRoots`); Merge Editor conservando ambos | `d009a59 Merge branch 'Feature_Animation' into dev` |
| D — Prueba | dev | Hierarchy: Player, Chest y Door una vez; Transforms correctos; Play Mode sin errores | — |

**Verificación:** sin marcas de conflicto, sin fileID duplicados, Chest y Door aparecen una sola vez.

## Capturas
01 A Chest · 02 B Door · 03 conflicto · 04 Merge Editor · 05 0 conflictos · 06 merge y push · 07–08 Hierarchy/escena final · 09 Play Mode
