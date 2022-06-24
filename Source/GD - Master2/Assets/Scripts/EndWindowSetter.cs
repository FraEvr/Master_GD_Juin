using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndWindowSetter : MonoBehaviour
{
    public Text scoretext;
    public GameManager gm;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        scoretext.text = "F�licitations, vous avez analys� toutes les plan�tes ! Vous avez \a" + gm.goodAnswer + "\a bonne(s) r�ponse(s) sur \a" + gm.totalQuestion + "\a plan�tes propos�es";
    }

    public void CallGoToMenu()
    {
        gm.gameObject.GetComponent<UI_Interactions>().GoToMenu();
    }
}
