using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Interactions : MonoBehaviour
{
    public GameObject wallpapersWindow;
    public GameObject explicationsWindow;
    public Text timeText;
    GameManager gm;

    public Button[] explicationsBtn;
    public GameObject[] explications;

    private void Start()
    {
        gm = GetComponent<GameManager>();
    }

    void Update()
    {
        if (gm.inGame)
        {
            ActualizeTime();
        }
    }

    void ActualizeTime()
    {
        gm.remainingTime -= Time.deltaTime;

        if (gm.remainingTime <= 0)
        {
            gm.remainingTime = 0;
            gm.LoseLive();
        }

        timeText.text = "<size=25>Temps restant</size>\n" + FormatTime(gm.remainingTime);
    }

    string FormatTime(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float secondes = Mathf.FloorToInt(time % 60);

        return string.Format("{0:00} : {1:00}", minutes, secondes);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene(); 
        SceneManager.LoadScene(scene.name);
    }

    public void ShowHideWallpapersWindow()
    {
        wallpapersWindow.SetActive(!wallpapersWindow.activeSelf);
    }

    public void ShowHideExplicationsWindow()
    {
        explicationsWindow.SetActive(!explicationsWindow.activeSelf);
    }

    public void ShowExplication(int ind)
    {

    }
}
