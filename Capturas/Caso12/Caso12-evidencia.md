# Caso 12 — Commit incorrecto

## Ejercicio realizado en `dev`
1. Se preparó `feat: update player and docs` con `PlayerController.cs`, `README.md` y `archivo_de_prueba.txt` (archivo que no debía ir).
2. Como el commit aún no estaba publicado, se quitó el archivo con `git rm --cached archivo_de_prueba.txt` y se corrigió con `git commit --amend --no-edit`.
3. Commit corregido: `080156d`. Luego se integró en `origin/dev` (`ecac5f0`).

## Resultado
El historial publicado solo tiene `PlayerController.cs` y `README.md` en el commit corregido. No se reescribió historia ya compartida.

## Capturas

| Captura | Qué muestra |
|---|---|
| [Caso12_01_CommitIncorrecto_ecac5f0.jpg](Caso12_01_CommitIncorrecto_ecac5f0.jpg) | Commit con archivos de más (ecac5f0 en el Graph) |
| [Caso12_02_CommitCorregido_080156d.jpg](Caso12_02_CommitCorregido_080156d.jpg) | Commit corregido 080156d con solo los archivos correctos |
