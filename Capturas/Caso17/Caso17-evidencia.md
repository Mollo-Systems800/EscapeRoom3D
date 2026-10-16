# Caso 17 — Revert de un cambio compartido

**Objetivo:** deshacer con **Revert** un cambio que ya estaba publicado en dev, sin borrar historia.

## Roles

| Rol | Qué hizo | Commit |
|---|---|---|
| A | En Feature_Animation cambió la comprobación de distancia de la puerta (`<=` → `>=`), lo integró en dev y lo subió | `e9d528b feat: adjust door interaction range check (A)` |
| B | Detectó en Unity que la puerta ya no abre con el Player al lado | — |
| C | Identificó el commit en History y lo revirtió | `aa5da35 Revert "feat: adjust door interaction range check (A)"` |
| D | QA: la puerta vuelve a abrir | — |

Todos los commits están a nombre de **Keyra Felipez**.

## Problema

En `OldDoorController.Update()` quedó:

```csharp
&& Vector3.Distance(player.position, transform.position) >= interactionDistance
```

Ahora la puerta solo responde cuando el jugador está **lejos**. Con el Player en (2, 1, 3), a 2.2 unidades de la puerta, la consola registra `Interaction key pressed: E`, pero la puerta se queda en **Rotation Y = 0**. El juego está roto y el commit ya está en `origin/dev`.

## Resolución

1. En **Source Control › Graph** se identificó el commit `e9d528b`: el diff muestra `<=` → `>=`, y el tooltip indica que ya está en `origin/dev`.
2. Revert del commit (`git revert e9d528b`). Git creó el commit nuevo `aa5da35` con el mensaje *This reverts commit e9d528b…*.
3. Se revisaron los cambios generados: `>=` vuelve a `<=`. No hubo conflictos.
4. **Sync/Push** de dev: `dev` = `origin/dev` = `aa5da35`.
5. History: el commit original `e9d528b` **sigue** en la historia, y encima está el revert.

## Comprobación en Unity (pasos 315–317)

- ✔ **La puerta vuelve a funcionar:** con el Player al lado, al pulsar E queda en **Rotation Y = 90**.
- ✔ **El commit original permanece en la historia:** `e9d528b`.
- ✔ **Existe un revert:** `aa5da35`.

## Capturas

| Captura | Evidencia |
|---|---|
| [01](Caso17_01_A_Commit_roto_en_History_diff.jpg) | **Commit roto:** diff `<=` → `>=`, ya en dev y origin/dev |
| [02](Caso17_02_B_Bug_puerta_no_abre_junto_al_Player.jpg) | **Bug:** E registrado, pero la puerta en Y = 0 con el Player al lado |
| [03](Caso17_03_C_Revert_cambios_generados.jpg) | **Revert:** cambios generados (`>=` → `<=`) |
| [04](Caso17_04_C_Historial_Revert_y_commit_original_en_origin.jpg) | **Historial:** el revert `aa5da35` en dev/origin y el original debajo |
| [05](Caso17_05_D_Puerta_funciona_Y90_tras_Revert.jpg) | **Puerta funcionando:** Rotation Y = 90 |

## Preguntas de reflexión

**318. ¿Por qué no borrar el commit original?**
Porque ya estaba publicado en `origin/dev` y los demás integrantes pueden tenerlo en su copia. Borrarlo (con reset y push --force) reescribiría la historia compartida: los demás tendrían commits que ya no existen en el remoto, y al sincronizar habría conflictos o se perdería trabajo. Además, el commit original documenta qué se intentó y por qué falló.

**319. ¿Qué ventaja tiene Revert en una historia compartida?**
Revert no reescribe nada: agrega un commit nuevo que deshace el efecto del anterior. Todos pueden hacer Pull normal, sin forzar nada. La historia queda completa y queda claro qué se rompió (`e9d528b`) y cómo se corrigió (`aa5da35`). Si más adelante el cambio se arregla bien, se puede volver a aplicar.
