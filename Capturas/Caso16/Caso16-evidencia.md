# Caso 16 — Accept Both rompe el juego

**Objetivo:** demostrar que una resolución que funciona en el texto puede ser incorrecta en el comportamiento del juego.

## Roles

| Rol | Rama | Qué hizo | Commit |
|---|---|---|---|
| Base | dev | `GameManager.cs` con `Initialize()` (cuenta las llamadas y crea la llave `Key`) y el objeto GameManager en MainScene | `9a41c37` |
| A | Feature_PlayerMovement | Agrega `Initialize();` en `Start()` | `c2e6e0b` |
| B | Feature_Interaction | Agrega otra llamada equivalente en el mismo punto: `Debug.Log("iniciando partida (B)")` + `this.Initialize();` | `aa8e4f3`, `32f5b9b` |
| C | dev | Integra: merge de A (fast-forward) y luego merge de B → conflicto | `ec4f583` |
| D | — | QA en Unity: reproduce el bug y valida la corrección | — |

Todo se hizo desde Source Control de VS Code y los commits están a nombre de **Keyra Felipez**.

## Problema

`GameManager.cs › Start()` tiene un conflicto: HEAD (A) trae `Initialize();` y Feature_Interaction (B) trae `Debug.Log(...)` + `this.Initialize();`.

Para el experimento se eligió **deliberadamente "Accept Both Changes"**. El conflicto desaparece (0 errores en VS Code), pero `Start()` queda así:

```csharp
Initialize();
Debug.Log("GameManager: iniciando partida (B)", this);
this.Initialize(); // B: prepara la partida al arrancar
```

## Bug en Unity

Con el archivo de Accept Both, en Play Mode pasa esto:

- La consola muestra `Initialize() llamada #1` y luego `llamada #2`.
- Aparece el error **"GameManager.Initialize() se ejecutó 2 veces: lógica duplicada"**.
- La Hierarchy tiene **dos objetos `Key`**: se crearon dos llaves.

## Corrección

1. Se volvió al código y se identificó la llamada duplicada.
2. Se editó el resultado a mano, dejando el log de B y **una sola** llamada:

```csharp
// Punto de arranque de la partida: Initialize() se llama UNA sola vez.
Debug.Log("GameManager: iniciando partida (B)", this);
Initialize();
```

3. Se guardó, se marcó como resuelto con Stage (+) y se completó el merge con **Continue**: `ec4f583 Merge branch 'Feature_Interaction' into dev`.
4. Se hizo **Sync/Push** de dev.

## Comprobación en Unity (pasos 299–301)

- ✔ **Initialize se ejecuta una sola vez:** la consola muestra solo `llamada #1`.
- ✔ **No hay duplicación:** hay una sola `Key` en la Hierarchy, en (-3, 1.2, 3), y 0 errores.
- ✔ **El juego funciona:** con Enter aparece "Puzzle resuelto: el cofre se abre".

## Capturas

| Captura | Evidencia |
|---|---|
| [01](Caso16_01_Base_GameManager_en_escena.jpg) | Base: GameManager en la escena |
| [02](Caso16_02_C_Merge_Feature_Interaction_commits_A_B.jpg) | C: merge de Feature_Interaction; se ven los commits de A y B |
| [03](Caso16_03_C_Conflicto_GameManager_Start.jpg) | **Conflicto** en `Start()` |
| [04](Caso16_04_C_AcceptBoth_sinConflicto_doble_Initialize.jpg) | **Accept Both**: sin conflicto, pero con `Initialize()` dos veces |
| [05](Caso16_05_D_Bug_Unity_Initialize_2veces_2Keys.jpg) | **Bug en Unity**: llamadas #1 y #2, error de lógica duplicada y 2 `Key` |
| [06](Caso16_06_C_Correccion_Result_una_sola_llamada.jpg) | **Corrección** manual: una sola llamada |
| [07](Caso16_07_C_Stage_y_completar_merge.jpg) | Stage y Continue para completar el merge |
| [08](Caso16_08_D_Resultado_Initialize_1vez_1Key.jpg) | **Resultado final**: Initialize #1, una `Key`, 0 errores |
| [09](Caso16_09_D_Juego_correcto_Key_y_Puzzle.jpg) | El juego funciona: llave creada y puzzle resuelto |

## Preguntas de reflexión

**302. ¿Por qué Accept Both no garantiza corrección?**
Porque Accept Both solo junta líneas de texto: pone una versión debajo de la otra. Git no entiende el significado del código: no sabe que `Initialize()` y `this.Initialize()` hacen lo mismo, ni que ese método debe ejecutarse una sola vez. El resultado compila y Git lo considera resuelto, pero el comportamiento es incorrecto (dos inicializaciones y dos llaves). La decisión correcta exige entender la regla del juego, y eso lo tiene que hacer una persona.

**303. ¿Qué pruebas detectaron el problema?**
La prueba manual en Play Mode de Unity:

- Los mensajes de la consola mostraron `Initialize() llamada #2`.
- La validación dentro de `Initialize()` lanzó el error "se ejecutó 2 veces: lógica duplicada".
- La Hierarchy mostró dos objetos `Key`.

La compilación no detectó nada, porque el código era válido. Por eso siempre hay que probar el juego después de resolver un conflicto.
