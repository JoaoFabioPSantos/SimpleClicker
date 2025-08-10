using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public static class StudioUtil
{
    //Ele tem q estar dentro de um editor, se não ele vai dar erro na compilação da build, logo criar este if
#if UNITY_EDITOR
    [UnityEditor.MenuItem("Studio/Test")]
    public static void Test()
    {
        Debug.Log("Test");
    }
    [UnityEditor.MenuItem("Studio/CreateObject %G")]
    public static void TestCreateObject()
    {
        // Cria um novo GameObject
        GameObject newObj = new GameObject("New Game Object");

        // Garante que ele aparece na hierarquia como objeto selecionado
        Selection.activeGameObject = newObj;

        // Registra para poder desfazer no Unity (Ctrl+Z)
        Undo.RegisterCreatedObjectUndo(newObj, "Create New Game Object");
    }
#endif

    //T é para aceitar qualquer tipo de item dentro da lista
    public static T GetRandom<T>(this List<T> list)
    {
        return list[Random.Range(0, list.Count)];
    }

    public static T GetRandomUnique<T>(this List<T> list, T unique)
    {
        if (list.Count == 1) return unique;
        
        int randomIndex = Random.Range(0, list.Count);
        return list[randomIndex];
    }
}
