# Caso 06 — Conflicto en PlayerController.cs

- A modificó `Update()` en `Feature_PlayerMovement` (`Debug.Log("Movement system active")`) y B en `Feature_Interaction` (tecla E).
- Al integrar en `dev` hubo conflicto en `PlayerController.cs`.
- Se conservaron ambos cambios revisando el resultado (no solo Accept Both a ciegas) y se probó en Unity.

## Capturas

| Captura | Qué muestra |
|---|---|
| [Caso06_01.jpg](Caso06_01.jpg) | Merge Editor de PlayerController.cs: Incoming vs Current |
| [Caso06_02.jpg](Caso06_02.jpg) | Marcadores de conflicto con Accept Current / Incoming / Both |
| [Caso06_03.jpg](Caso06_03.jpg) | Resultado tras resolver y continuar el merge |
