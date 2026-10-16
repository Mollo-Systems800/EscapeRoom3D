# Caso 10 — PuzzleManager y cofre

## Integración

- `PuzzleManager` valida el código `1234`, limita el juego a tres intentos y emite `onPuzzleSolved` cuando se resuelve.
- La tecla **1** simula un código incorrecto; **Enter** envía el código de prueba `1234`.
- `onPuzzleSolved` está conectado de forma persistente a `ChestController.OpenChest` en `Assets/Scenes/MainScene.unity`.
- El cofre tiene una tapa independiente con pivote para abrirse animadamente.
- El controlador del cofre y el `PuzzleManager` están adjuntos al objeto `Chest`.

## Validación disponible

- Se revisaron las referencias de los componentes, el objetivo del evento, la jerarquía del pivote y las referencias de scripts mediante inspección estática de archivos.
- No se pudo compilar ni probar en Play Mode desde esta sesión. Unity Batch Mode terminó con código 1 durante el inicio por un problema de licencia (sin entitlements disponibles), antes de ejecutar la validación.
- Las capturas existentes `Caso10_01`–`Caso10_08` documentan el proceso previo; no se generaron capturas nuevas que certifiquen la escena corregida.

## Criterios para verificación visual pendiente

1. Abrir `Assets/Scenes/MainScene.unity` en Unity.
2. Entrar a Play Mode y pulsar **1** para comprobar el rechazo de código incorrecto.
3. Pulsar **Enter** para confirmar el código de prueba y observar la tapa abrirse.
4. Acercarse a `Door` y pulsar **E** para comprobar el giro.
5. Guardar capturas actualizadas en `Capturas/Caso10` y `Capturas/Caso09-evidencia`.
