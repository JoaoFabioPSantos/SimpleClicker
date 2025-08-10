using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using DG.Tweening;
using UnityEditor;

namespace Screens
{
    public enum ScreenType 
    {
        Panel,
        Info_Panel,
        Options,
    }

    public class ScreenBase : MonoBehaviour
    {
        public ScreenType screenType;
        public List<Transform> listOfObjects;
        public List<Typer> listOfPhrases;
        public bool startHided = false;

        [Header("Animation")]
        public float animationDuration = .3f;
        public float delayBetweenObjects = .05f;

        private void Start()
        {
            if (startHided)
            {
                ForceHideObjects();
            }
        }

        [Button]
        protected virtual void Show()
        {
            if (!EditorApplication.isPlaying) return;
            ShowObjects();
            Debug.Log("SCREEN BASE Show"); 
        }

        [Button]
        protected virtual void Hide()
        {
            if (!EditorApplication.isPlaying) return;
            ForceHideObjects();
            Debug.Log("SCREEN BASE Hide");
        }

        private void ShowObjects()
        {
            for(int i = 0; i< listOfObjects.Count; i++)
            {

                listOfObjects[i].gameObject.SetActive(true);
                listOfObjects[i].DOScale(0, animationDuration).From().SetDelay(i*delayBetweenObjects);
            }
            Invoke(nameof(StartType), delayBetweenObjects * listOfObjects.Count);
        }

        private void StartType()
        {
            for (int i = 0; i < listOfPhrases.Count; i++)
            {
                listOfPhrases[i].StartType();
            }
        }

        private void ForceHideObjects()
        {
            listOfObjects.ForEach(i => i.gameObject.SetActive(false));
        }

        private void ForceShowObjects()
        {
            listOfObjects.ForEach(i => i.gameObject.SetActive(true));
        }
    }

}

