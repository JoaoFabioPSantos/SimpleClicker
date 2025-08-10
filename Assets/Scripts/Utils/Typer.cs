using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using NaughtyAttributes;
using UnityEditor;

public class Typer : MonoBehaviour
{
    public TextMeshProUGUI textMesh;
    public float timeBetweenLetters = .1f;
    public string phrase;

    private void Awake()
    {
        textMesh.text = "";
    }

    [Button]
    public void StartType()
    {
        if (!EditorApplication.isPlaying) return;
        StartCoroutine(Type(phrase));
    }
    IEnumerator Type(string s)
    {
        textMesh.text = "";
        foreach(char l in s.ToCharArray())
        {
            textMesh.text += l;
            yield return new WaitForSeconds(timeBetweenLetters);
        }
    }
}
