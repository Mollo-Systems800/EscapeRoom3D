# Caso 13 — Archivo que debía estar en `.gitignore`

## Ejercicio realizado en `dev`

1. Se creó `TempLaboratorio/archivo_generado.txt` con contenido de prueba inocuo y se comprobó que al principio no estaba ignorado.
2. Se versionó deliberadamente en `test: add generated file before ignore rule` (`d2487b0`). `git ls-files` confirmó que estaba tracked.
3. Se añadió `/TempLaboratorio/` a `.gitignore`.
4. Como la regla no elimina por sí sola un archivo ya tracked, se ejecutó `git rm -r --cached -- TempLaboratorio`.
5. Se verificó que `git check-ignore -v` identifica la regla y que el archivo sigue existiendo localmente.
6. Se preparó el commit `chore: fix ignored files` para quitarlo del índice y conservar la regla.

## Resultado esperado

Tras el commit correctivo, el archivo permanece en `TempLaboratorio` en esta máquina, Git deja de seguirlo y nuevas salidas de esa carpeta quedan ignoradas. El commit inicial conserva la reproducción del error en el historial del ejercicio.

## Capturas

No había una ventana de VS Code o Unity accesible para capturar; el inventario de aplicaciones está vacío. El historial de Git, `git ls-files`, `git check-ignore -v` y esta bitácora documentan el procedimiento.
