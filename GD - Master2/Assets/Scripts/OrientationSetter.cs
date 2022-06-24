using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrientationSetter : MonoBehaviour
{
    public Image planetVisual;
    public GameObject planete;

    float orientation;

    void Start()
    {
        SetPlanetVisual();
        SetOrientation();
    }

    void SetOrientation()
    {

        int rand = 0;

        if (GameManager.GetLivability())
        {
            rand = Random.Range(10, 41);
        }
        else
        {
            rand = Random.Range(5, 360);
        }

        planete.transform.Rotate(Vector3.back, rand);

        GameManager.systemInfos.orientation = orientation;
    }

    void SetPlanetVisual()
    {
        planetVisual.sprite = GameManager.systemInfos.planetVisual;
    }
}
