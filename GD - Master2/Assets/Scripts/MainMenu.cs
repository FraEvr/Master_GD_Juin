using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public RectTransform transition;

    public void QuitApplication()
    {
        Application.Quit();
    }

    public void PlayGame()
    {
        StartCoroutine("PlayGameCoroutine");
    }

    IEnumerator PlayGameCoroutine()
    {
        transition.gameObject.SetActive(true);
        LeanTween.alpha(transition, 1f, 0.75f).setEase(LeanTweenType.linear);
        yield return new WaitForSeconds(0.75f);
        SceneManager.LoadScene(1);
    }
}
