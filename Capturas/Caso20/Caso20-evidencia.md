# Caso 20 — Pull Request y entrega final

**Estado:** Feature preparada y probada; PR `Feature_Interaction` → `dev` abierta, pendiente de aprobación formal de una cuenta distinta a la autora. Por ello todavía no se ha integrado a `dev` ni se ha abierto la PR `dev` → `main`.

## Roles simulados y trazabilidad

| Rol | Trabajo realizado |
|---|---|
| A, Hugo Nava | Actualizó la Feature existente con `dev` y publicó `5f9205c`, `c81baa6` y `4871791` para interacción, corrección de llave y conexión del script al prefab. |
| B, Keyra | Revisión simulada: comentó en la PR que la llave podía recogerse antes del puzzle. La corrección y el recorrido completo de Unity fueron comprobados. La aprobación formal de GitHub sigue pendiente. |
| C, Mollo | Integración pendiente de la aprobación formal. |
| D, QA/Release | Prueba en copia aislada de Unity, sin archivos temporales en la rama publicada. |

## Revisión y corrección

La [PR #1](https://github.com/Mollo-Systems800/EscapeRoom3D/pull/1) propone la nueva interacción. El comentario de revisión señaló que `GameManager` creaba la llave activa desde el inicio, lo que permitía saltarse el cofre. El commit `c81baa6` la desactiva al iniciar y la revela al dispararse `onPuzzleSolved`. La prueba detectó que `PlayerInteraction` no estaba conectado al prefab del jugador; `4871791` agregó ese componente y se repitió la prueba.

La cuenta que abrió la PR no puede aprobarla: GitHub deshabilita **Approve** y muestra que los autores no pueden aprobar sus propias PR. La revisión simulada no se presenta como aprobación de otra persona. El merge se dejó pendiente.

## Prueba del juego

Unity 6000.5.5f1 compiló el proyecto en la copia aislada y la prueba de `MainScene` terminó **APROBADO**, con cero errores de consola. Comprobó inicio único, llave oculta al principio, puerta cerrada sin llave, rechazo del código incorrecto, resolución del puzzle, apertura del cofre, aparición y recogida de la llave, y apertura de la puerta. El objeto `QA temporal Caso 20` y el script de verificación existen solo en una copia ignorada por Git.

## Evidencias disponibles

| Evidencia | Archivo |
|---|---|
| PR Feature → Dev | [01](Caso20_01_PR_Feature_dev.jpg) |
| Comentario útil de revisión | [02](Caso20_02_Comentario_revision.jpg) |
| Corrección en la PR | [03](Caso20_03_Correccion.jpg) |
| Aprobación formal pendiente | [04](Caso20_04_Aprobacion_pendiente.jpg) |
| Juego probado | [07](Caso20_07_Juego_final.png) |

Faltan las capturas de merge a `dev`, PR `dev` → `main` y `main` final, porque el flujo se detuvo antes de integrar sin aprobación.

## Reflexión

**389. Ventaja de revisar antes de integrar:** la revisión detectó que la llave aparecía antes del puzzle y evitó publicar un atajo que rompía la secuencia del juego.

**390. Diferencia entre `dev` y `main`:** `dev` recibe y verifica las Features integradas; `main` representa la versión final de entrega.

**391. Problema que evita el PR:** integrar cambios sin discusión ni comprobación de su efecto sobre el juego.

**392. Evidencia de colaboración:** la conversación del PR junto con los commits posteriores que responden al comentario, además de una aprobación formal hecha desde otra cuenta cuando se complete.
