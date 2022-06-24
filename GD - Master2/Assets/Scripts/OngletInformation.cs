using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OngletInformation : MonoBehaviour
{
    public GameObject ongletPrefab;
    public Sprite visual;
    public string ongletName;
    public GameManager gm;

    MinimizeShowWindow ongletInformationScript;

    private void Start()
    {
        ongletInformationScript = Instantiate(ongletPrefab, gm.ongletsHolder).GetComponent<MinimizeShowWindow>();

        ongletInformationScript.ongletNameText.text = ongletName;
        ongletInformationScript.ongletImage.sprite = visual;
        ongletInformationScript.associatedWindow = gameObject;
    }

    public void CallChangeWindowActivation()
    {
        ongletInformationScript.ChangeWindowActivation();
    }
}
