# Caso 11 — Cambios en ProjectSettings

## Qué se hizo
| Rol | Rama | Commit | Cambio en `ProjectSettings/ProjectSettings.asset` |
|---|---|---|---|
| A | Feature_PlayerMovement | `83d8844 chore: set Active Input Handling to Both (A)` | `activeInputHandler: 1 → 2` |
| B | Feature_Interaction | `79f4386 chore: set company name and version 0.2.0 (B)` | `companyName: UNIVALLE`, `bundleVersion: 0.2.0` |
| C | dev | `8832032` y `ff96f6a` (merges) | Se integraron las dos ramas |

Los cambios estaban en líneas distintas del mismo archivo, así que Git los combinó sin conflicto. Antes de aceptar se revisó el diff para comprobar que no se perdía ningún valor.

## Verificación en Unity (D)
- Project Settings > Player: Company Name **UNIVALLE**, Version **0.2.0**.
- Other Settings: Active Input Handling **Both**.
- Play Mode: el Player responde al teclado (Input System) y la consola no muestra errores de input.

## Capturas

| Captura | Qué muestra |
|---|---|
| [Caso11_01_A_Diff_ActiveInputHandling.jpg](Caso11_01_A_Diff_ActiveInputHandling.jpg) | A: diff de Active Input Handling |
| [Caso11_02_B_CompanyName_Version.jpg](Caso11_02_B_CompanyName_Version.jpg) | B: diff de Company Name y Version |
| [Caso11_03_C_Merge_Diff_Resultado.jpg](Caso11_03_C_Merge_Diff_Resultado.jpg) | C: resultado del merge en dev |
| [Caso11_04_D_ProjectSettings_UNIVALLE_0.2.0.jpg](Caso11_04_D_ProjectSettings_UNIVALLE_0.2.0.jpg) | D: Project Settings con UNIVALLE y 0.2.0 |
| [Caso11_05_D_PlayMode_InputSinErrores.jpg](Caso11_05_D_PlayMode_InputSinErrores.jpg) | D: Play Mode con la tecla E registrada y 0 errores |
| [Caso11_06_D_ProjectSettings_ActiveInput_Both.jpg](Caso11_06_D_ProjectSettings_ActiveInput_Both.jpg) | D: Active Input Handling = Both |
