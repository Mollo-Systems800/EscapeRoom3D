# Caso 12 — Commit incorrecto

## Ejercicio realizado en `dev`

1. El punto de partida era `de3faf2`, igual a `origin/dev`; no había un commit nuevo compartido.
2. Se preparó `feat: update player and docs` con `PlayerController.cs`, `README.md` y `archivo_de_prueba.txt` para reproducir el error.
3. Se identificó el archivo ajeno y, como el commit aún era local, se quitó y se corrigió con `git commit --amend --no-edit`.
4. El commit corregido fue `080156d`. Más tarde se integró en `origin/dev` dentro del commit `ecac5f0`, que también contiene la corrección del proyecto y esta evidencia.

## Resultado

El historial publicado conserva únicamente `PlayerController.cs` y `README.md` dentro del commit corregido; `archivo_de_prueba.txt` no está versionado ni existe en la carpeta de trabajo. No se reescribió historia después de que el commit llegó a `origin/dev`.

## Evidencia de historial

```text
Commit inicial: feat: update player and docs
Archivos iniciales: PlayerController.cs, README.md, archivo_de_prueba.txt
Corrección local: git rm archivo_de_prueba.txt
                  git commit --amend --no-edit
Commit corregido: 080156d
Integración posterior en origin/dev: ecac5f0
```

Los demás cambios del proyecto quedaron fuera del commit 080156d.

## Capturas

No había una ventana de VS Code o Unity accesible para capturar; el inventario de aplicaciones de esta sesión está vacío. Este registro de texto conserva el procedimiento y el resultado verificables en Git.
