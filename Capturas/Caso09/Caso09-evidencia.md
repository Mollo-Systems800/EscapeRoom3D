# Caso 09 — Archivo eliminado vs. modificado

## Qué pasó
- Base: `b605874 chore: add old door controller base` crea `Assets/Scripts/OldDoorController.cs`.
- Rama A: `92fa6b7 refactor: remove old door controller` **elimina** el archivo.
- Rama B: `8f90fe9 fix: update old door controller` lo **modifica**.
- Al integrar apareció el conflicto *deleted by them / modified by us*. Se decidió **conservar** el archivo modificado porque la puerta lo necesita: `a1cef62 merge: resolve old door controller delete/modify`.

## Verificación en Unity (15/10)
- `Door` en `MainScene` tiene el componente **Old Door Controller** (Open Angle 90, Rotation Speed 2, Interaction Distance 3.5).
- En Play Mode, con el Player a menos de 3.5 unidades, al pulsar **E** la puerta gira a **Y = 90** y la consola tiene **0 errores**.
- Para poder probar se agregó un piso a la escena (`1a415a2 fix: add floor to MainScene and place Player above it`): sin piso el Player caía al vacío.

## Capturas

| Captura | Qué muestra |
|---|---|
| [Caso09_01_C_Graph_DeleteModify_Merge.jpg](Caso09_01_C_Graph_DeleteModify_Merge.jpg) | Graph de VS Code: base, eliminación, modificación y merge que resuelve el conflicto |
| [Caso09_02_D_Door_OldDoorController.jpg](Caso09_02_D_Door_OldDoorController.jpg) | Inspector de Door con Old Door Controller |
| [Caso09_03_D_PlayMode_PuertaAbierta_Y90.jpg](Caso09_03_D_PlayMode_PuertaAbierta_Y90.jpg) | Play Mode: puerta abierta (Rotation Y = 90) y consola sin errores |
