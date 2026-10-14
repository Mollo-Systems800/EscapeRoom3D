# Caso 09 — Evidencia actualizada

## Integración en `dev`

- Se conservó y actualizó `Assets/Scripts/OldDoorController.cs`.
- `OldDoorController` está conectado al objeto `Door` de `Assets/Scenes/MainScene.unity`.
- La puerta gira al pulsar **E** cuando el jugador está a 3.5 unidades o menos.
- Se migró la lectura de teclado de los scripts de jugador y puerta al paquete Input System, coherente con `Active Input Handling = Input System Package`.

## Validación disponible

- Referencias estáticas de escena y script: `Door` contiene `OldDoorController`; el objeto jugador de la escena mantiene el nombre `Player` que usa el controlador.
- No pude ejecutar Play Mode ni volver a capturar la interfaz de Unity: el arranque por lotes terminó con código 1 antes de ejecutar el método de reparación, debido al error del cliente de licencias de Unity (sin entitlements disponibles). Las imágenes previas en `Capturas/Caso08` son evidencia histórica y no documentan esta corrección.

## Capturas

No se generaron capturas nuevas en esta sesión porque no hubo una ventana de Unity accesible. La evidencia visual del caso 09 queda pendiente de tomar en Unity con la licencia del editor activa.
