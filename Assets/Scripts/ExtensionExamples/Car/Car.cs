using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Car : MonoBehaviour
{
    public GameObject carPrefab;
    public Transform canvasTransform;

    public int speed = 20;
    public int gear = 5;

    public int TotalSpeed
    {
        get { return speed * gear; }
    }

    public void CreateCar()
    {
        GameObject newUI = Instantiate(carPrefab, canvasTransform);
        newUI.transform.localPosition = Vector3.zero;
        newUI.transform.localScale = Vector3.one;
    }

}
