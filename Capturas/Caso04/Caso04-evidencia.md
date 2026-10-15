# Caso 04 — Cambios locales y Stash

- Con cambios sin guardar en `PlayerInteraction.cs` se intentó cambiar de rama y VS Code mostró **"Your local changes would be overwritten by checkout"**.
- Se guardaron con Stash (`On Feature_Interaction: WIP Interaction`), se cambió de rama y luego se recuperaron con Pop.
- Commit final: `957a557 feat: add player interaction` y `16245d6 Cambios en PlayerInteraction`.

## Capturas

| Captura | Qué muestra |
|---|---|
| [Caso04_01.jpg](Caso04_01.jpg) | Cambios locales sin commit en Feature_Interaction |
| [Caso04_02.jpg](Caso04_02.jpg) | Advertencia: los cambios locales se sobrescribirían al cambiar de rama |
| [Caso04_03.jpg](Caso04_03.jpg) | PlayerInteraction.cs con los cambios pendientes |
| [Caso04_04.jpg](Caso04_04.jpg) | Lista de stash: 'WIP Interaction' |
| [Caso04_05.jpg](Caso04_05.jpg) | Graph después de recuperar el stash |
| [Caso04_06.jpg](Caso04_06.jpg) | Advertencia reproducida otra vez antes de usar Stash |
| [Caso04_07.jpg](Caso04_07.jpg) | Unity compila con PlayerInteraction |
