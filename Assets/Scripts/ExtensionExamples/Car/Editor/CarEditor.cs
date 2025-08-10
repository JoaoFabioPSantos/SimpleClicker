using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Car))]
public class CarEditor : Editor
{
    //Toda vez que ocorre uma atualziação no GUI
    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        Car myTarget = (Car)target;

        myTarget.carPrefab = (GameObject)EditorGUILayout.ObjectField("Prefab Car",myTarget.carPrefab, typeof(GameObject), true);
        myTarget.canvasTransform = (Transform)EditorGUILayout.ObjectField("Transform Canvas", myTarget.canvasTransform, typeof(Transform),true);
        myTarget.speed = EditorGUILayout.IntField("Velocity", myTarget.speed);
        myTarget.gear = EditorGUILayout.IntField("Gear", myTarget.gear);

        //monta uma label
        EditorGUILayout.LabelField("Velocidade Total ", myTarget.TotalSpeed.ToString());

        //passamos a mensagem e o tipo dela
        EditorGUILayout.HelpBox("Calculando a velocidade total do carro", MessageType.Info);

        if (myTarget.TotalSpeed > 100)
        {
            EditorGUILayout.HelpBox("Calculando a velocidade total do carro", MessageType.Error);
        }
        //Trocando a cor do botão:
        //GUI.color = Color.blue;
        if (GUILayout.Button("CreateCar"))
        {
            myTarget.CreateCar();
        }
    }
}
