# Caso 03 — Commit en la rama equivocada

- Problema provocado: el commit `feat: add player movement` se hizo estando en `dev`.
- Solución: se movió el trabajo a `Feature_PlayerMovement` (commit `6997a61`) y `dev` quedó sin ese commit antes de compartirlo.
- Lección: revisar la rama en la barra de estado antes de hacer commit.

## Capturas

| Captura | Qué muestra |
|---|---|
| [Caso03_01.jpg](Caso03_01.jpg) | Rama dev activa en VS Code |
| [Caso03_02.jpg](Caso03_02.jpg) | Selector de ramas: se trabaja por error en dev |
| [Caso03_03.jpg](Caso03_03.jpg) | Unity: proyecto abierto |
| [Caso03_04.jpg](Caso03_04.jpg) | PlayerController con el movimiento |
| [Caso03_05.jpg](Caso03_05.jpg) | Commit 'feat: add player movement' preparado en dev (rama equivocada) |
| [Caso03_06.jpg](Caso03_06.jpg) | Graph: el commit quedó en dev y no en la Feature |
| [Caso03_07.jpg](Caso03_07.jpg) | GitHub antes de corregir |
| [Caso03_08.jpg](Caso03_08.jpg) | Corrección: llevar el commit a Feature_PlayerMovement y publicar |
| [Caso03_09.jpg](Caso03_09.jpg) | Corrección: llevar el commit a Feature_PlayerMovement y publicar |
| [Caso03_10.jpg](Caso03_10.jpg) | Corrección: llevar el commit a Feature_PlayerMovement y publicar |
| [Caso03_11.jpg](Caso03_11.jpg) | Corrección: llevar el commit a Feature_PlayerMovement y publicar |
| [Caso03_12.jpg](Caso03_12.jpg) | Corrección: llevar el commit a Feature_PlayerMovement y publicar |
| [Caso03_13.jpg](Caso03_13.jpg) | Corrección: llevar el commit a Feature_PlayerMovement y publicar |
| [Caso03_14.jpg](Caso03_14.jpg) | dev sin el commit de movimiento |
| [Caso03_15.jpg](Caso03_15.jpg) | Graph después de la corrección |
| [Caso03_16.jpg](Caso03_16.jpg) | Unity: Player y PlayerController en Assets/Scripts |
| [Caso03_17.jpg](Caso03_17.jpg) | GitHub: Feature_PlayerMovement con 'feat: add player movement' |
