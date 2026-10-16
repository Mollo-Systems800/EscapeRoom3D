# Caso 18 — Recuperación de trabajo aparentemente perdido

**Objetivo:** demostrar que un commit que dejó de estar visible en una rama puede localizarse con `git reflog` y recuperarse.

## Roles simulados

| Rol | Acción |
|---|---|
| A | Creó `RECOVERY_TEST.md` y el commit `ece7c388ec3e65331626a6736a92ffbfcf24cdfb` (`test: recovery point`). |
| B | Movió `dev` temporalmente al commit anterior con un `git reset --hard` local. El commit de prueba todavía no estaba publicado. |
| C | Localizó el hash en `git reflog` y restauró `dev` exactamente a ese commit. |
| D | Comprobó el archivo, el hash y la integridad del repositorio; guardó las capturas. |

La guía no especifica la operación concreta que indicaría el docente en el paso 323. Se utilizó un reset local controlado como equivalente reversible. No se borró `.git`, no se forzó ninguna rama remota y no se creó una rama nueva. Los comandos se ejecutaron en una terminal del proyecto; la salida de `reflog` se guardó temporalmente y se abrió en VS Code para la captura.

## Procedimiento (320–334)

1. Estado inicial de `dev`: `a1f9c791d79d4b10e5552032579930f8996b1de6`, sincronizado y limpio.
2. Se creó `RECOVERY_TEST.md` y se registró el commit `test: recovery point`, hash `ece7c388ec3e65331626a6736a92ffbfcf24cdfb`.
3. Se movió `dev` al estado anterior. El archivo dejó de existir en el árbol de trabajo y el commit desapareció del historial visible de la rama.
4. En `git reflog` apareció la entrada `ece7c38 ... commit: test: recovery point`, inmediatamente después de la entrada del reset. Esto permitió ubicar el commit que ya no tenía la referencia `dev`.
5. Se restauró `dev` al hash completo `ece7c388ec3e65331626a6736a92ffbfcf24cdfb`. VS Code volvió a mostrar el commit y `RECOVERY_TEST.md` reapareció.
6. El hash de `HEAD` recuperado coincide con el anotado. El hash del archivo en disco coincide con `HEAD:RECOVERY_TEST.md` (`8372e90356bf7c9458f9d073061357454042fa3e`). `git fsck --full --no-reflogs` terminó correctamente; informó objetos históricos no referenciados, sin errores de integridad. Unity conserva `MainScene` y los archivos de juego: este caso solo agregó un Markdown en la raíz y no modificó assets.

## Capturas obligatorias

| Evidencia | Archivo |
|---|---|
| Estado de pérdida: el commit ya no aparece en `dev` | [01](Caso18_01_Perdida.png) |
| `reflog` muestra el reset y el hash recuperable | [02](Caso18_02_Reflog.png) |
| Recuperación: el commit vuelve al historial de `dev` | [03](Caso18_03_Recuperacion.png) |
| Archivo `RECOVERY_TEST.md` restaurado | [04](Caso18_04_Archivo_recuperado.png) |

## Preguntas de reflexión

**335. ¿Qué registra reflog?**

Registra los movimientos locales de referencias y de `HEAD`, por ejemplo commits, cambios de rama y resets. Así puede conservar la ubicación anterior de un commit aunque ya no aparezca en el historial recorrido desde la punta actual de una rama.

**336. ¿Por qué guardar el hash fue importante?**

Porque identifica exactamente el commit buscado. Tras el reset, `dev` apuntaba a otro lugar, pero el hash anotado permitió reconocerlo en `reflog` y restaurar la referencia sin adivinar ni recrear el archivo.
