# Caso 12 — Commit incorrecto

## Ejercicio realizado en `dev`

1. El punto de partida era `de3faf2`, igual a `origin/dev`; no había un commit nuevo compartido.
2. Se preparó el commit `feat: update player and docs` con `PlayerController.cs`, `README.md` y `archivo_de_prueba.txt` para reproducir el error del caso.
3. Al revisar el contenido, se identificó que `archivo_de_prueba.txt` no correspondía al propósito del commit.
4. Como el commit seguía únicamente en el repositorio local, se quitó el archivo y se corrigió con `git commit --amend --no-edit`.

## Resultado

El commit corregido conserva los cambios del controlador y la documentación, y excluye `archivo_de_prueba.txt`. El commit corregido está en `dev`, aún no se ha publicado en `origin/dev`. No se reescribió historia compartida y no se creó otra rama.

## Evidencia de historial

```text
Commit inicial: feat: update player and docs
Archivos iniciales: PlayerController.cs, README.md, archivo_de_prueba.txt
Acción correctiva: git rm archivo_de_prueba.txt
                   git commit --amend --no-edit
Resultado: commit local con PlayerController.cs y README.md; sin archivo de prueba
```

Los demás cambios pendientes del proyecto quedaron fuera de este commit.

## Capturas

No había una ventana de VS Code o Unity accesible para capturar; el inventario de aplicaciones de esta sesión está vacío. Este registro de texto conserva el procedimiento y el resultado verificables en Git.
