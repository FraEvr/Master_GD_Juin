using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarTypeSetter : MonoBehaviour
{
    public StarType_SO[] allStarTypes;
    public StarType_SO[] goodStarTypes;
    public StarType_SO[] badStarTypes;
    StarType_SO actualStartype;

    [Header("UI")]
    public Image starImage;
    public Text temperatureText;
    public Text radiusText;
    public Text massText;
    public Text luminosityText;
    public Text lifetimeText;
    public Text abundanceText;

    private void Start()
    {
        SelectStar();
        
    }

    void SelectStar()
    {
        if (GameManager.GetLivability())
        {
            actualStartype = goodStarTypes[Random.Range(0, goodStarTypes.Length)];
        }
        else
        {
            if (GameManager.idActualLevel <= 2)
            {
                actualStartype = badStarTypes[Random.Range(0, badStarTypes.Length)];
            }
            else
            {
                actualStartype = allStarTypes[Random.Range(0, allStarTypes.Length)];
            }
        }

        GameManager.systemInfos.starType = actualStartype;

        SetStarInfos();
    }

    void SetStarInfos()
    {
        starImage.sprite = actualStartype.starVisual;
        starImage.rectTransform.sizeDelta = actualStartype.imageSize;

        temperatureText.text = actualStartype.temperature + "";
        radiusText.text = actualStartype.radius + "";
        massText.text = actualStartype.mass + "";
        luminosityText.text = actualStartype.luminosity + "";
        lifetimeText.text = actualStartype.lifetime + "millions";
        abundanceText.text = actualStartype.abundance + "";
    }

}
