using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bluescreen : MonoBehaviour
{
    public Canvas canvas;
    public GameObject continueBtn;
    public Text pourcentageText;

    float pourcentage = 0;

    void Start()
    {
        canvas.worldCamera = Camera.main;
        StartCoroutine("UpdatePourcentageCoroutine");
    }

    IEnumerator UpdatePourcentageCoroutine()
    {
        for (int i = 0; i < 11; i++)
        {
            yield return new WaitForSeconds(Random.Range(0f, 1.5f));
            pourcentage += 10;
            pourcentageText.text = pourcentage + "%";
        }

        pourcentageText.gameObject.SetActive(false);
        continueBtn.SetActive(true);
    }

    public void DestroyBlueScreen()
    {
        Destroy(gameObject);
    }
}
