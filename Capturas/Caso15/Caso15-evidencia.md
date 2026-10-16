# Caso 15 — Conflicto en varios archivos

**Objetivo:** resolver a la vez conflictos en un script, un Prefab y una escena.

## Roles

| Rol | Integrante | Qué hizo |
|---|---|---|
| A | Hugo Nava | `b0e13e2 feat: tune player movement and prefab (A)`: PlayerController, Player.prefab y MainScene |
| B | Hugo Nava | `c1787e0 feat: tune interaction and scene lighting (B)`: PlayerController, Player.prefab y MainScene |
| C | Hugo Nava / Alaitz Keyra | Hugo integró y subió `3e93d34 Merge branch 'Feature_Interaction' into dev`. Alaitz repitió la integración en VS Code para dejar la evidencia y comprobó que el resultado es idéntico |
| D | Alaitz Keyra | QA completo en Unity |

## Cambios de cada rama (desde `dc28bfa`)

| Archivo | A (Feature_PlayerMovement) | B (Feature_Interaction) |
|---|---|---|
| `PlayerController.cs` | `speed = 6f`; movimiento con `Vector3.ClampMagnitude` | `speed = 4f`; log `"Interaction key pressed: E"` |
| `Player.prefab` | `speed: 6`; Rigidbody `m_Constraints: 112` (congela la rotación X, Y, Z) | `speed: 4`; Rigidbody `m_Interpolate: 1` |
| `MainScene.unity` | Directional Light `m_Intensity: 1.2` | Directional Light `m_Intensity: 1.4` |

## Problema

Al integrar Feature_Interaction en dev, **Source Control › Merge Changes** muestra **3 archivos en conflicto**: `Player.prefab`, `MainScene.unity` y `PlayerController.cs`. Cada archivo es una decisión distinta: resolver uno no resuelve los demás.

## Resolución en el Merge Editor (pasos 270–277)

| Archivo | Conflicto | Decisión | Motivo |
|---|---|---|---|
| `PlayerController.cs` | `speed` 6f vs 4f | **Accept Current (6f)** | Se mantiene la velocidad de A, que va junto con `ClampMagnitude`. El log de la tecla E de B no estaba en conflicto y se conservó solo |
| `Player.prefab` (1) | `speed` 6 vs 4 | **Accept Current (6)** | El valor del Prefab tiene que coincidir con el del script |
| `Player.prefab` (2) | `m_Interpolate` / `m_Constraints` | **Accept Combination** → `Interpolate: 1` + `Constraints: 112` | Son mejoras distintas del Rigidbody y las dos sirven |
| `MainScene.unity` | Intensidad de la luz 1.2 vs 1.4 | **Accept Incoming (1.4)** | El cambio de iluminación es responsabilidad de B |

Cada archivo se cerró con **Complete Merge** y quedó en *Staged Changes*: 0 conflictos. Después se hizo **Continue** (commit del merge).

**Comprobación:** el resultado de esta integración es idéntico al merge que Hugo subió (`git diff 3e93d34` vacío). Por eso la reproducción no se volvió a subir: `dev` ya tiene la integración y está sincronizada con `origin/dev`.

## Comprobación en Unity (pasos 278–283)

- ✔ **La escena carga:** se recargó MainScene con los cambios integrados.
- ✔ **Player** muestra `Speed 6`, `Interpolate` y `Freeze Rotation X Y Z`.
- ✔ **El Player se mueve:** con W/D pasó de (0.35, 1, 0.35) a (0.82, 1, 0.69), sin caer ni volcarse.
- ✔ **La interacción funciona:** la consola muestra `Interaction key pressed: E` y la puerta gira.
- ✔ **El cofre y la puerta existen:** con Enter aparece "Puzzle resuelto: el cofre se abre".
- ✔ **Consola sin errores:** 0 errores. Solo queda el aviso de Unity sobre la cuenta (Account API), que no tiene que ver con el proyecto.

## Capturas

| Captura | Qué muestra |
|---|---|
| [01](Caso15_01_C_MergeBranch_Feature_Interaction.jpg) | C: Merge Branch: se eligen las ramas de A y B |
| [02](Caso15_02_C_MergeChanges_3Conflictos.jpg) | **Lista de múltiples conflictos** (3 archivos en Merge Changes) |
| [03](Caso15_03_C_MergeEditor_PlayerController_conflicto.jpg) | PlayerController en el Merge Editor (4f vs 6f) |
| [04](Caso15_04_C_PlayerController_resuelto.jpg) | **PlayerController resuelto** (6f + log de E) |
| [05](Caso15_05_C_MergeEditor_PlayerPrefab_2conflictos.jpg) | Player.prefab: 2 conflictos |
| [06](Caso15_06_C_PlayerPrefab_resuelto_Combinacion.jpg) | **Player.prefab resuelto** (Interpolate 1 + Constraints 112) |
| [07](Caso15_07_C_MergeEditor_MainScene_conflicto.jpg) | MainScene: intensidad de la luz 1.4 vs 1.2 |
| [08](Caso15_08_C_MainScene_resuelto.jpg) | **MainScene resuelto** (1.4) |
| [09](Caso15_09_C_SinConflictos_TodoStageado.jpg) | Sin conflictos: los 3 archivos en Staged Changes |
| [10](Caso15_10_C_EstadoLimpio_dev_sincronizado.jpg) | **Estado limpio:** dev = origin/dev con el merge |
| [11](Caso15_11_D_Unity_PlayerPrefab_valores_integrados.jpg) | Unity: Player con los valores integrados |
| [12](Caso15_12_D_PlayMode_PlayerSeMueve.jpg) | Play Mode: el Player se mueve |
| [13](Caso15_13_D_JuegoCompleto_Interaccion_Cofre_Puerta_0Errores.jpg) | **Juego completo:** interacción E, cofre abierto, puerta y 0 errores |

## Preguntas de reflexión

**284. ¿Cómo organizaste la resolución?**
Un archivo a la vez, en este orden: primero el **script**, porque define el comportamiento; luego el **Prefab**, que debe coincidir con el script (la misma `speed`); y al final la **escena**. En cada conflicto se revisó qué intentaba cada rama y se eligió Current, Incoming o la combinación según el sentido del cambio, no a ciegas. Cada archivo se cerró con *Complete Merge* antes de pasar al siguiente, y al final se comprobó que no quedaba ningún conflicto antes del commit.

**285. ¿Por qué conviene validar Unity después de resolver todos?**
Porque los archivos dependen unos de otros: el Prefab serializa valores del script, y la escena contiene la instancia del Prefab. Mientras queda un archivo a medio resolver, Unity puede mostrar errores que no son reales, o reimportar un estado incoherente. Al validar al final se prueba la combinación definitiva tal como quedará en dev: que compile, que la escena cargue y que el juego funcione completo.
