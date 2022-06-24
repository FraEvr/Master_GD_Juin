using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExplicationsSetter : MonoBehaviour
{
    public Image explicationFrame;
    public Sprite[] explications;

    public Sprite hidedBtnImage;
    public Sprite showedBtnImage;
    public Image[] btnImages;

    private void Start()
    {
        ChangeExplication(0);
    }

    public void ChangeExplication(int ind)
    {
        explicationFrame.sprite = explications[ind];

        for (int i = 0; i < btnImages.Length; i++)
        {
            print(ind + " / " + i);
            if (i == ind)
            {
                btnImages[i].sprite = showedBtnImage;
            }
            else
            {
                btnImages[i].sprite = hidedBtnImage;
            }
        }
    } 
}
