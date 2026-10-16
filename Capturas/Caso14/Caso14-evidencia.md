# Caso 14 — Feature desactualizada respecto a Dev

**Objetivo:** actualizar `Feature_Puzzle` con los cambios recientes de `dev` antes de integrarla.

## Roles

| Rol | Integrante | Qué hizo |
|---|---|---|
| A | Hugo (simulado) | Trabaja en `Feature_Puzzle` |
| B | Hugo (simulado) | Agrega dos cambios a `dev` y hace push |
| C | Alaitz Keyra | Hace Pull y Merge Branch `dev` → `Feature_Puzzle` |
| D | Alaitz Keyra | Prueba en Unity (QA) |

## Procedimiento

| Paso | Rama | Acción | Commit |
|---|---|---|---|
| 245 | Feature_Puzzle | Se actualizó desde `dev` (fast-forward) y se publicó | `d2d86ff` |
| 246 | dev | Cambio 1 (B): `feat: add KeyItem script (B)` | `1c1f670` |
| 246 | dev | Cambio 2 (B): `docs: describe game elements in README (B)` | `c4317f7` |
| 247 | dev | Push de dev | — |
| 248 | Feature_Puzzle | Sin actualizar, cambio propio (A): `feat: add PuzzleHint with clue message (A)` | `3e2979b` |
| 249 | Feature_Puzzle | Push de la Feature | — |

### Problema

`Feature_Puzzle` quedó **desactualizada**: tiene 1 commit propio y le faltan 2 commits de `dev`. Las ramas divergen desde `d2d86ff`. En la Feature, el README no tiene la sección "Elementos del juego" y no existe `KeyItem.cs`.

```
* 3e2979b feat: add PuzzleHint with clue message (A)      ← Feature_Puzzle
| * c4317f7 docs: describe game elements in README (B)    ← dev
| * 1c1f670 feat: add KeyItem script (B)
|/
* d2d86ff docs: add evidence for cases 00-06, 09 and 11-13
```

### Resolución en VS Code (pasos 250–257)

1. Se cambió a `Feature_Puzzle`.
2. **Pull**.
3. **Source Control › … › Branch › Merge… › dev**.
4. No hubo conflictos: los cambios estaban en archivos distintos (`PuzzleHint.cs` en la Feature; `KeyItem.cs` y `README.md` en dev).
5. Se probó en Unity (rol D).
6. Se creó el commit del merge: `1b61751 Merge branch 'dev' into Feature_Puzzle`.
7. **Sync / Push** de la Feature.
8. En GitHub, la comparación `dev...Feature_Puzzle` dice **"Able to merge"**: la rama está lista para el Pull Request.

```
*   1b61751 Merge branch 'dev' into Feature_Puzzle        ← Feature_Puzzle, origin/Feature_Puzzle
|\
| * c4317f7 docs: describe game elements in README (B)    ← dev
| * 1c1f670 feat: add KeyItem script (B)
* | 3e2979b feat: add PuzzleHint with clue message (A)
|/
* d2d86ff
```

### Comprobación en Unity

- La Feature contiene los cambios recientes de dev: en `Assets/Scripts/Puzzle` están `KeyItem` (de dev) y `PuzzleHint` (de la Feature).
- Unity compila sin errores. En Play Mode, al pulsar **Enter** aparece "Puzzle resuelto: el cofre se abre", la tapa del cofre se abre y la consola tiene **0 errores**.
- La Feature está publicada: `origin/Feature_Puzzle` = `1b61751`, 2 commits por delante de dev y 0 por detrás.

## Capturas

| Captura | Qué muestra |
|---|---|
| [Caso14_01](Caso14_01_A_FeaturePuzzle_creada_desde_dev.jpg) | A: Feature_Puzzle actualizada desde dev, antes de publicarse |
| [Caso14_02](Caso14_02_B_DosCambiosNuevosEnDev.jpg) | B: dos commits nuevos en dev (KeyItem y README) |
| [Caso14_03](Caso14_03_A_HistorialAntes_FeatureDesactualizada.jpg) | **Historial antes**: la Feature diverge de dev y su README no tiene los cambios |
| [Caso14_04](Caso14_04_C_Pull_y_MenuMergeBranch.jpg) | C: menú Branch › Merge… en Source Control |
| [Caso14_05](Caso14_05_C_MergeBranch_seleccionar_dev.jpg) | C: se elige `dev` como rama de origen del merge |
| [Caso14_06](Caso14_06_C_MergeDevEnFeature_SinConflictos.jpg) | **Merge Dev → Feature** sin conflictos; el README ya trae la sección nueva |
| [Caso14_07](Caso14_07_D_Unity_FeatureConCambiosDeDev.jpg) | D: Unity muestra KeyItem y PuzzleHint juntos |
| [Caso14_08](Caso14_08_D_PlayMode_PuzzleResuelto_0Errores.jpg) | D: Play Mode con el puzzle resuelto y 0 errores |
| [Caso14_09](Caso14_09_C_HistorialDespues_MergeDev_Push.jpg) | **Historial después**: commit de merge (KeyItem.cs, KeyItem.cs.meta, README.md) ya publicado |
| [Caso14_10](Caso14_10_GitHub_Compare_dev_FeaturePuzzle.jpg) | GitHub: comparación dev...Feature_Puzzle (2 commits, 2 archivos) |
| [Caso14_11](Caso14_11_GitHub_AbleToMerge_ListaParaPR.jpg) | GitHub: "Able to merge", lista para el PR |

## Preguntas de reflexión

**262. ¿Por qué conviene resolver el conflicto en la Feature?**
Porque quien conoce el código de la Feature es su autor, y puede decidir bien qué conservar. Así los problemas se resuelven y se prueban en la rama de trabajo, sin romper `dev`, que es compartida. Cuando llega el Pull Request, la Feature ya está al día y el merge hacia dev es limpio (GitHub muestra "Able to merge"). El revisor solo tiene que revisar el cambio nuevo, no arreglar conflictos ajenos.

**263. ¿Qué diferencia conceptual existe entre merge y rebase?**
- **Merge** une las dos historias con un *commit de merge* (`1b61751`) que tiene dos padres. Se conserva la historia real, con la bifurcación tal como ocurrió, y no cambia ningún commit ya publicado.
- **Rebase** "mueve" los commits de la Feature para que empiecen después del último commit de dev. Los vuelve a crear con hashes nuevos y deja una historia lineal, sin commit de merge. Como reescribe commits, no se debe hacer sobre ramas ya compartidas sin coordinarse con el equipo. Por eso aquí se usó merge.
