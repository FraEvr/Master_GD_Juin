using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExcentriciteSetter : MonoBehaviour
{
    public Image planet;
    public Image etoile;
    public Transform rotationCenter;
    public float decalageExcentriciteEtoile = 150f;
    public float rotationRadius = 2f;
    public float angularSpeed = 2f;

    [Range(0,0.95f)]
    public float excentricite = 0f;

    float posX = 0f;
    float posY = 0f;
    float angle = 0f;

    private void Start()
    {
        SetExcentricite();
    }

    void Update()
    {
        if (planet)
        {
            RotatePlanet();
        }
    }

    void SetExcentricite()
    {
        if (GameManager.GetLivability())
        {
            excentricite = Random.Range(0, 0.05f);
        }
        else
        {
            excentricite = Random.Range(0.5f, 0.95f);
        }

        etoile.sprite = GameManager.systemInfos.starType.starVisual;
        etoile.rectTransform.sizeDelta = GameManager.systemInfos.starType.imageSize / 2;
        etoile.transform.localPosition = new Vector3(decalageExcentriciteEtoile * excentricite, etoile.rectTransform.localPosition.y, etoile.rectTransform.localPosition.z);

        planet.sprite = GameManager.systemInfos.planetVisual;
        planet.transform.Rotate(Vector3.back, GameManager.systemInfos.orientation);
    }

    void RotatePlanet()
    {
        posX = rotationCenter.position.x + Mathf.Cos(angle) * rotationRadius;
        posY = rotationCenter.position.y + Mathf.Sin(angle) * rotationRadius / (1 + excentricite);

        planet.gameObject.transform.position = new Vector2(posX, posY);
        angle = angle + Time.deltaTime * angularSpeed;

        if (angle >= 360f)
        {
            angle = 0f;
        }
    }
}
