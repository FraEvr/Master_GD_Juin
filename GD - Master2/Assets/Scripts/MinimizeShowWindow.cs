using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinimizeShowWindow : MonoBehaviour
{
    public Sprite activatedSprite;
    public Sprite desactivatedSprite;
    public GameObject associatedWindow;

    public Text ongletNameText;
    public Image ongletImage;

    Image btn_image;
    
    bool isActivated = true;

    private void Start()
    {
        btn_image = GetComponent<Image>();
    }

    public void ChangeWindowActivation()
    {
        if (isActivated)
        {
            btn_image.sprite = desactivatedSprite;
            associatedWindow.SetActive(false);
            isActivated = false;
        }
        else
        {
            btn_image.sprite = activatedSprite;
            associatedWindow.SetActive(true);
            associatedWindow.transform.SetSiblingIndex(transform.parent.childCount);
            isActivated = true;
        }
    }
}
