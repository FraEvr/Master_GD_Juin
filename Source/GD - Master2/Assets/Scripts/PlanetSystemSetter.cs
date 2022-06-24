using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlanetSystemSetter : MonoBehaviour
{
    [Range(2,5)]
    public int planetsNumber = 2;

    public Image mainStar;
    public Image[] planets;

    GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        SetPlanetSystem();
    }


    void SetPlanetSystem()
    {
        mainStar.sprite = GameManager.systemInfos.starType.starVisual;

        if (planetsNumber > 0)
        {
            for (int i = 0; i < planets.Length; i++)
            {
                if (i < planetsNumber)
                {
                    planets[i].sprite = gameManager.planetVisuals[Random.Range(0, gameManager.planetVisuals.Length)];
                    planets[i].rectTransform.sizeDelta *= Random.Range(0.5f, 1);
                }
                else
                {
                    planets[i].gameObject.SetActive(false);
                }
            }

            if (!GameManager.GetLivability())
            {
                int rand = Random.Range(0, gameManager.starVisuals.Length);
                planets[planetsNumber - 1].sprite = gameManager.starVisuals[rand];
                planets[planetsNumber - 1].rectTransform.sizeDelta *= Random.Range(0.75f, 1.25f);
            }
        }
    }
}
