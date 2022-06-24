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
        scoretext.text = "Félicitations, vous avez analysé toutes les planètes ! Vous avez \a" + gm.goodAnswer + "\a bonne(s) réponse(s) sur \a" + gm.totalQuestion + "\a planètes proposées";
    }

    public void CallGoToMenu()
    {
        gm.gameObject.GetComponent<UI_Interactions>().GoToMenu();
    }
}
