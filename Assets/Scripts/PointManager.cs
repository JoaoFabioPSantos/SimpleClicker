using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using TMPro;

public class PointManager : MonoBehaviour
{
    private int numberPoint = 0;
    private int clickValue = 1;
    private float delayInvalidText = 1.0f;
    private bool mythicalValue = false;

    public int valueUpgrade = 5;
    public int valueMythicalPoint = 100;

    [Header("Text HUD References")]
    public TMP_Text pointText;
    public TMP_Text clickValueText;

    [Header("Buttons Cost Text")]
    public TMP_Text upgradeCostText;
    public TMP_Text mythicalCostText;

    [Header("Buttons Invalid Text GameObject")]
    public GameObject upgradeInvalidText;
    public GameObject mythicalInvalidText;

    private void Update()
    {
        if(!mythicalValue)ShowPoints();
    }

    public void ShowPoints()
    {
        pointText.text = numberPoint + " Pontinhos";
        clickValueText.text = clickValue + " pontinhos p/ click";

        upgradeCostText.text = valueUpgrade + " pontinhos";
        mythicalCostText.text = valueMythicalPoint + " pontinhos";

    }

    public void PlusPoint()
    {
        if (!mythicalValue)
        {
            numberPoint += clickValue;
        }
    }

    public void UpgradeClick()
    {
        if (numberPoint < valueUpgrade)
        {
            StartCoroutine(ShowInvalidText(upgradeInvalidText));
        }
        else
        {
            numberPoint -= valueUpgrade;
            clickValue++;
            valueUpgrade *= 2;
        }
    }

    public void MythicalPoint()
    {
        if(numberPoint < 100)
        {
            StartCoroutine(ShowInvalidText(mythicalInvalidText));
        }
        else
        {
            mythicalValue = true;
            numberPoint = 1000;

            pointText.text = "Parabéns você conseguiu o ponto lendário !";
            upgradeCostText.text = " ";
            mythicalCostText.text = " ";
        }
    }

    IEnumerator ShowInvalidText(GameObject buttonText)
    {
        buttonText.SetActive(true);
        yield return new WaitForSeconds(delayInvalidText);
        buttonText.SetActive(false);
    }

}
