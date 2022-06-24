using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TemperatureSetter : MonoBehaviour
{
    public float temperature;
    public float initialPosi;
    public Image slider;

    private void Start()
    {
        SetTemperature();
    }

    void SetTemperature()
    {
        if (GameManager.GetLivability())
        {
            temperature = Random.Range(180, 281);
        }
        else
        {
            temperature = Random.Range(0, 500);
        }

        slider.rectTransform.localPosition = new Vector3(0, initialPosi + temperature, 0);

        GameManager.systemInfos.temperature = temperature;
    }

}
