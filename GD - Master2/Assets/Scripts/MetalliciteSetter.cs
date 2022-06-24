using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MetalliciteSetter : MonoBehaviour
{
    public GameObject aiguille;
    public float speed = 5f;
    public int clickRestant = 3;

    public Text clickRestantText;
    public Text[] guess;

    float metallicite;
    float pourcentage = 0f;
    float speedFactor = 1f;

    bool canClick = true;

    Vector3 temp;

    void Start()
    {
        SetMetallicite();

        aiguille.LeanRotateAround(Vector3.back, 180, speed).setLoopPingPong();
        clickRestantText.text = clickRestant + "\a essai(s) restant(s)";
    }

    void SetMetallicite()
    {

        if (GameManager.GetLivability())
        {
            pourcentage = Random.Range(25, 100);
        }
        else
        {
            pourcentage = Random.Range(0, 25);
        }

        metallicite = (0.04f / 100) * pourcentage;
        metallicite = RoundTo3decimals(metallicite);
    }

    public void CheckValue()
    {
        if (canClick)
        {
            canClick = false;
            aiguille.LeanPause();

            float unroundedValue = (aiguille.GetComponent<RectTransform>().eulerAngles.z - 360f) * -1f;

            float pourcent = (unroundedValue / 180f) * 100f;
            float pourcentMetalliciteValue = (0.04f / 100) * pourcent;
            Debug.Log(Mathf.Round(unroundedValue));

            if (pourcent > pourcentage)
            {
                guess[clickRestant - 1].text = "Moins que \n" + RoundTo3decimals(pourcentMetalliciteValue);
            }

            if (pourcent < pourcentage)
            {
                guess[clickRestant - 1].text = "Plus haut que \n" + RoundTo3decimals(pourcentMetalliciteValue);
            }

            if (pourcent == pourcentage)
            {
                guess[clickRestant - 1].text = "Egal à \n" + RoundTo3decimals(pourcentMetalliciteValue);
            }


            clickRestant--;
            clickRestantText.text = clickRestant + "\a essai(s) restant(s)";

            if (clickRestant > 0)
            {
                Invoke("ResetClick", 2f);
            }
        }
    }

    void ResetClick()
    {
        canClick = true;
        aiguille.LeanResume();
    }

    float RoundTo3decimals(float _value)
    {
        return Mathf.Round(_value * 10000.0f) * 0.0001f;
    }


}
