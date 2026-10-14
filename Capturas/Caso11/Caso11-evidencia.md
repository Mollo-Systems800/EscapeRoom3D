# Caso 11 — Conflicto en ProjectSettings

## Objetivo

Revisar los cambios de configuración antes de integrarlos y conservar los que deben coexistir. Según la guía, no se fabrica un conflicto destructivo si Unity no lo produce automáticamente.

## Diff observado en `dev`

| Archivo | Cambio | Lectura del diff |
|---|---|---|
| `ProjectSettings/EditorBuildSettings.asset` | Se agregó `com.unity.dt.app-ui` a `m_configObjects`, apuntando al asset `App UI Settings`. | Registra en Unity la configuración del paquete App UI. |
| `ProjectSettings/ProjectSettings.asset` | Se agregó `APP_UI_EDITOR_ONLY` a los defines de `Standalone`. | Coincide con la opción `m_EditorOnly: 1` del asset de App UI. |

## Decisión de integración

Los dos valores aparecen juntos en el árbol de trabajo y forman una configuración relacionada: el paquete App UI configura el objeto de ajustes en `EditorBuildSettings` y sincroniza el define de compilación cuando está habilitado `Editor Only`. Se conservaron ambos cambios; eliminar uno por separado podría dejar desincronizada la configuración del paquete.

No hay evidencia en el historial de que estos cambios provengan de dos ramas o de dos autores distintos, y no apareció un conflicto automático. Por eso esta evidencia documenta el diff real observado en lugar de simular commits o fabricar un conflicto. Se mantuvo la rama existente `dev`.

## Comprobaciones

- `com.unity.dt.app-ui` figura en `Packages/packages-lock.json`.
- El GUID del objeto de configuración resuelve al asset `App UI Settings` disponible en el paquete de Unity instalado en `Library/PackageCache`.
- El asset tiene `m_EditorOnly: 1`, concordante con el define `APP_UI_EDITOR_ONLY`.
- Unity no pudo abrirse en modo por lotes en esta sesión: el inicio falló por el estado de licenciamiento antes de cargar la escena o ejecutar validaciones. Esta revisión es estática y no confirma que Unity abra ni que el juego se ejecute.

## Capturas

No se generaron capturas de la interfaz: no hay ventanas de Unity disponibles en esta sesión. La revisión reproducible queda registrada en este archivo; una captura de Unity debe añadirse cuando el editor pueda abrirse con una licencia activa.
