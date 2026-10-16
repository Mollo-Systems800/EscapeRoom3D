# Caso 19 — Cherry-pick de una corrección

**Objetivo:** llevar una corrección puntual de `Feature_Puzzle` a `dev` sin integrar el resto del trabajo de la Feature.

## Roles simulados

| Rol | Acción |
|---|---|
| A | Preparó tres commits independientes en la rama existente `Feature_Puzzle`. |
| B | Identificó el commit correctivo `1d83c82b59adfee150895bbb82b8ed74be91cbaf`. |
| C | Lo aplicó con **Git: Cherry Pick...** en VS Code sobre `dev`. |
| D | Verificó la corrección y comprobó que los otros commits quedaron fuera de `dev`. |

## Procedimiento (337–353)

Se actualizó `Feature_Puzzle` con `dev` mediante merge, conservando sus commits previos. Después se prepararon y publicaron estos tres commits nuevos:

| Commit en Feature_Puzzle | Contenido | ¿Integrado en dev? |
|---|---|---|
| `4e413de` `docs: draft puzzle hint progression` | Borrador de pistas | No |
| `1d83c82` `fix: correct puzzle validation` | Rechaza códigos vacíos sin consumir intento y acepta el código correcto con espacios alrededor | Sí, mediante cherry-pick |
| `8c6d3d8` `feat: draft second puzzle hint` | Segunda pista experimental | No |

Tras volver a `dev` se hizo pull. En la interfaz de VS Code se eligió **Git: Cherry Pick...** y se introdujo el hash completo del fix. Git creó `6830af2` en `dev`, con el mismo cambio en `Assets/Scripts/Puzzle/PuzzleManager.cs` y un hash nuevo. No hubo conflicto. El commit se publicó en el remoto.

La comparación entre el estado anterior y `6830af2` contiene solo `PuzzleManager.cs`. Los hashes `4e413de` y `8c6d3d8` no son ancestros de `dev`; el borrador de pistas y la segunda pista no aparecen allí.

## Prueba del puzzle

Unity 6000.5.5f1 compiló sin errores y se ejecutó `MainScene` en Play Mode. En una copia aislada del mismo proyecto, una prueba temporal llamó al `PuzzleManager` y verificó que un código compuesto solo de espacios fue rechazado sin consumir intentos (`Attempts = 0`); después, `" 1234 "` resolvió el puzzle, abrió el cofre y dejó `Attempts = 1`. La consola mostró los tres resultados verdaderos y cero errores. El objeto `QA temporal` visible en la captura pertenece únicamente a esa copia aislada e ignorada por Git; no se incluyó en el proyecto publicado.

## Capturas obligatorias

| Evidencia | Archivo |
|---|---|
| Commit original en `Feature_Puzzle` | [01](Caso19_01_Commit_original.png) |
| Acción Cherry Pick con el hash del fix | [02](Caso19_02_Cherry_pick.png) |
| History de `dev` con el nuevo commit | [03](Caso19_03_History_dev.png) |
| Prueba del puzzle | [04](Caso19_04_Puzzle.png) |

## Preguntas de reflexión

**354. ¿Por qué no hacer merge?**

Porque el merge incorporaría también el borrador de pistas, la segunda pista y los cambios anteriores exclusivos de `Feature_Puzzle`. `dev` solo necesitaba la corrección de validación.

**355. ¿Qué diferencia hay entre cherry-pick y merge?**

Cherry-pick copia el cambio de un commit concreto y crea otro commit sobre la rama actual, con un hash diferente. Merge une las historias de dos ramas y trae todos los commits alcanzables de la rama integrada que todavía faltan en la rama destino.
