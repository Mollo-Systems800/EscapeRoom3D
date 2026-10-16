# Revisión general (15/10)

| Problema encontrado | Corrección | Commit |
|---|---|---|
| La escena mostraba `Broken text PPtr ... (1839184021) doesn't exist!` al abrirse: el objeto Chest apuntaba a un componente que ya no existía | Se quitó la referencia rota de la lista de componentes de Chest | `ff24865 fix: remove missing component reference from Chest` |
| En Play Mode el Player caía al vacío porque la escena no tenía suelo | Se agregó `Floor` (Plane 30×30) y el Player se colocó en Y = 1 | `1a415a2 fix: add floor to MainScene and place Player above it` |

## Capturas

| Captura | Qué muestra |
|---|---|
| [Error_MainScene_BrokenPPtr.jpg](Error_MainScene_BrokenPPtr.jpg) | Antes: error Broken text PPtr en la consola |
| [Revision_02_Escena_Chest_SinErrores.jpg](Revision_02_Escena_Chest_SinErrores.jpg) | Después: Chest seleccionado y consola sin errores |
