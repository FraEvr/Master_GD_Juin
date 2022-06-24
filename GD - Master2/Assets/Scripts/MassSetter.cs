using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MassSetter : MonoBehaviour
{
    public Image rotationBarre;
    public Image plateauGauche;
    public Image plateauDroite;

    Vector3 initPosiPlateauGauche;
    Vector3 initPosiPlateauDroite;

    public float rotMaxAngle = 25f;
    public float yMaxMover = 40f;

    public Text poidsText;
    float poids = 0f;

    float actualMass;

    private void Start()
    {
        initPosiPlateauGauche = plateauGauche.rectTransform.localPosition;
        initPosiPlateauDroite = plateauDroite.rectTransform.localPosition;


        SetMass();
    }

    void SetMass()
    {

        if (GameManager.GetLivability())
        {
            actualMass = Random.Range(0.8f, 4f);
        }
        else
        {
            actualMass = Random.Range(0.1f, 10f);
        }

        actualMass = RoundTo2decimals(actualMass);
        PlayRotationAnimation();
    }


    public void SetPower(float _powerToAdd)
    {
        poids += _powerToAdd;
        poids = Mathf.Clamp(poids, 0f, 12f);
        poidsText.text = poids + "t";
        PlayRotationAnimation();
    }

    float RoundTo2decimals(float _value)
    {
        return Mathf.Round(_value * 100.0f) * 0.01f;
    }

    void PlayRotationAnimation()
    {
        float temp = actualMass - poids;

        temp *= rotMaxAngle;
        temp = Mathf.Clamp(temp, -25f, 25f);
        temp *= -1;

        rotationBarre.rectTransform.localRotation = Quaternion.Euler(new Vector3(0, 0, temp));

        plateauGauche.rectTransform.localRotation = Quaternion.Euler(new Vector3(0, 0, temp * -1));
        plateauDroite.rectTransform.localRotation = Quaternion.Euler(new Vector3(0, 0, temp * -1));

        if (temp < 0)
        {
            plateauGauche.rectTransform.localPosition = new Vector3(initPosiPlateauGauche.x + temp * -1, initPosiPlateauGauche.y - (temp / 2), initPosiPlateauGauche.z);
            plateauDroite.rectTransform.localPosition = new Vector3(initPosiPlateauDroite.x + temp * -1, initPosiPlateauDroite.y - (temp / 2), initPosiPlateauDroite.z);
        }

        if (temp > 0)
        {
            plateauGauche.rectTransform.localPosition = new Vector3(initPosiPlateauGauche.x + temp * -1, initPosiPlateauGauche.y + (temp / 2), initPosiPlateauGauche.z);
            plateauDroite.rectTransform.localPosition = new Vector3(initPosiPlateauDroite.x + temp * -1, initPosiPlateauDroite.y + (temp / 2), initPosiPlateauDroite.z);
        }

        if (temp == 0)
        {
            plateauGauche.rectTransform.localPosition = initPosiPlateauGauche;
            plateauDroite.rectTransform.localPosition = initPosiPlateauDroite;
        }
    }
}
