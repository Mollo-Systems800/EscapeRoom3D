# Caso 0 — Configuración inicial de Unity y del proyecto

Comprobación de la configuración pedida en la sección 3 de la guía antes de empezar los casos.

| Requisito | Estado | Dónde se ve |
|---|---|---|
| Una sola versión de Unity para el equipo | Unity 6000.5.5f1 | Barra de título de Unity |
| Asset Serialization = Force Text | ✔ | `ProjectSettings/EditorSettings.asset` → `m_SerializationMode: 2` |
| Version Control = Visible Meta Files | ✔ | `ProjectSettings/VersionControlSettings.asset` → `m_Mode: Visible Meta Files` |
| Escenas en `Assets/Scenes`, scripts en `Assets/Scripts`, prefabs en `Assets/Prefabs` | ✔ | Ventana Project |

## Capturas

| Captura | Qué muestra |
|---|---|
| [Caso00_01_Editor_AssetSerialization_ForceText.jpg](Caso00_01_Editor_AssetSerialization_ForceText.jpg) | Project Settings > Editor: Asset Serialization en Force Text |
| [Caso00_02_VersionControl_VisibleMetaFiles.jpg](Caso00_02_VersionControl_VisibleMetaFiles.jpg) | Project Settings > Version Control: Visible Meta Files |
| [Caso00_03_Estructura_Assets_Escena.jpg](Caso00_03_Estructura_Assets_Escena.jpg) | Estructura de Assets (Scenes, Scripts/Player, Scripts/Puzzle, Prefabs, Materials) y escena MainScene |
