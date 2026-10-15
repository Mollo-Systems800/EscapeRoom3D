# Caso 05 — Push rechazado

- Hugo subió `31c9e4f docs: update project information` a `dev`. Alaitz/Keyra hizo `8eeee29 docs: add team information` sin traer ese cambio.
- El push fue rechazado: **"Can't push refs to remote. Try running Pull first"**.
- Se hizo Pull, apareció conflicto en `README.md`, se resolvió combinando ambas líneas en el Merge Editor y se hizo push (`096b97b`).

## Capturas

| Captura | Qué muestra |
|---|---|
| [Caso05_01.jpg](Caso05_01.jpg) | Estado inicial antes del push |
| [Caso05_02.jpg](Caso05_02.jpg) | Push rechazado: Can't push refs to remote |
| [Caso05_03.jpg](Caso05_03.jpg) | Push rechazado (otro intento) |
| [Caso05_04.jpg](Caso05_04.jpg) | Conflicto en README.md tras el Pull |
| [Caso05_05.jpg](Caso05_05.jpg) | GitHub: README con el cambio de Hugo |
| [Caso05_06.jpg](Caso05_06.jpg) | GitHub: rama dev con commits nuevos |
| [Caso05_07.jpg](Caso05_07.jpg) | Merge Editor: se combinan ambas versiones del README |
| [Caso05_08.jpg](Caso05_08.jpg) | Merge commit creado |
| [Caso05_09.jpg](Caso05_09.jpg) | Sync final de dev |
