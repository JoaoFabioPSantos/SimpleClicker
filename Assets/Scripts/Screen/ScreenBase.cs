using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using DG.Tweening;

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
            ShowObjects();
            Debug.Log("Show"); 
        }

        [Button]
        protected virtual void Hide()
        {
            ForceHideObjects();
            Debug.Log("Hide");
        }

        private void ShowObjects()
        {
            for(int i = 0; i< listOfObjects.Count; i++)
            {

                listOfObjects[i].gameObject.SetActive(true);
                listOfObjects[i].DOScale(0, animationDuration).From().SetDelay(i*delayBetweenObjects);
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

