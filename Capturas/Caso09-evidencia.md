# Caso 09 — Evidencia

## Resultado

- Conflicto reproducido: `Assets/Scripts/OldDoorController.cs` fue eliminado en `Feature_PlayerMovement` y modificado en `dev`.
- Resolución: se conservó la versión modificada del script y su `.meta`, porque no existe un `DoorController` sustituto.
- Búsqueda de referencias: la única coincidencia en `Assets` es la declaración de la clase `OldDoorController`.

## Historial

- `b605874` — commit base del controlador.
- `92fa6b7` — eliminación en `Feature_PlayerMovement` (`refactor: remove old door controller`).
- `8f90fe9` — modificación en `dev` (`fix: update old door controller`).
- `a1cef62` — merge de resolución en `dev`, conservando la versión modificada.

## Validación

No se pudo abrir Play Mode: no había una ventana de Unity disponible y la escena no contiene una puerta. `dotnet build --no-restore` tampoco pudo compilar porque falta `Temp/obj/Assembly-CSharp-Editor/project.assets.json`; el intento de `dotnet restore` terminó sin diagnóstico.

## Capturas

No se generaron capturas de pantalla: esta sesión no expuso ventanas de VS Code o Unity (inventario de apps vacío). Esta bitácora deja los commits y la decisión verificables para el informe. La carpeta `Capturas` se creó porque no existía una carpeta de evidencias en la raíz del proyecto.
