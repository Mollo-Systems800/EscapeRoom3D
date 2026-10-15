# Caso 13 — Archivo que debía estar en .gitignore

## Ejercicio realizado en `dev`
1. Se creó `TempLaboratorio/archivo_generado.txt` y se versionó por error: `d2487b0 test: add generated file before ignore rule`.
2. Se agregó `/TempLaboratorio/` a `.gitignore`.
3. Como la regla no saca un archivo que ya está en seguimiento, se ejecutó `git rm -r --cached TempLaboratorio`.
4. Commit: `393f4dd chore: fix ignored files`. `git check-ignore -v` muestra la regla y el archivo sigue existiendo en la PC.

## Capturas

| Captura | Qué muestra |
|---|---|
| [Caso13_01_Antes_archivo_tracked.jpg](Caso13_01_Antes_archivo_tracked.jpg) | Antes: el archivo aparece versionado |
| [Caso13_02_gitignore_y_Despues.jpg](Caso13_02_gitignore_y_Despues.jpg) | Regla en .gitignore y commit de corrección |
| [Caso13_03_Despues_archivo_ignorado.jpg](Caso13_03_Despues_archivo_ignorado.jpg) | Después: el archivo queda ignorado |
