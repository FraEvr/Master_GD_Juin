using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public struct PlanetSystemInformations
    {
        public Sprite planetVisual;
        public float orientation;
        public float temperature;
        public StarType_SO starType;
    }

    public int life;

    public GameObject gameCanvas;
    public GameObject echecCanvas;

    public GameObject bluescreenPrefab;
    public int howManyBluescreen = 0;
    IEnumerator bluescreenCorout;
    bool alreadyHadBluescreen = false;

    public RectTransform transition;

    public CheckLivability livabilityWindow;
    public GameObject[] ParamWindows;
    public int nbrWindowToShow;

    public static PlanetSystemInformations systemInfos;
    public Sprite[] planetVisuals;
    public Sprite[] starVisuals;

    public Level_SO[] levels;
    static public int idActualLevel = 0;
    int remainingResolution = 0;
    float resolutionTime = 0;

    public Transform ongletsHolder;
    public static List<GameObject> onglets;

    List<GameObject> affichedWindows;

    static bool isPlanetLivable;
    public float remainingTime = 0;

    public bool inGame = true;

    public EndWindowSetter endWindow;
    public int goodAnswer;
    public int totalQuestion;

    private void Awake()
    {
        idActualLevel = 0;
    }

    void Start()
    {
        LeanTween.alpha(transition, 0f, 0.75f).setEase(LeanTweenType.linear).setOnComplete(DestroyTransition);

        affichedWindows = new List<GameObject>();
        onglets = new List<GameObject>();

        if (howManyBluescreen > 0)
        {
            bluescreenCorout = BluescreenCoroutine();
            StartCoroutine(bluescreenCorout);
        }

        remainingResolution = levels[idActualLevel].nbrResolution;
        resolutionTime = levels[idActualLevel].windowResolutionTime;

        NextLevel();
    }

    void StartNewGame()
    {
        totalQuestion++;

        ResetGameBoard();
        SetPlanetLivability();
        SetupLevel();
    }

    void SetPlanetLivability()
    {
        int rand = Random.Range(0, 11);

        if (rand >= 4)
        {
            isPlanetLivable = true;
        }
        else
        {
            isPlanetLivable = false;
        }

        Debug.Log("Habitable : " + isPlanetLivable);
    }

    public static bool GetLivability()
    {
        return isPlanetLivable;
    }

    void SetupLevel()
    {
        systemInfos.planetVisual = planetVisuals[Random.Range(0, planetVisuals.Length)];

        if (nbrWindowToShow > 0)
        {
            GameObject tempLivabilityWindow = Instantiate(livabilityWindow.gameObject, Vector3.zero, Quaternion.identity);
            SpawnWindowInGameCanvas(tempLivabilityWindow);

            for (int i = 0; i < nbrWindowToShow; i++)
            {
                GameObject temp = Instantiate(ParamWindows[i], Vector3.zero, Quaternion.identity);
                SpawnWindowInGameCanvas(temp);
                temp.GetComponent<OngletInformation>().gm = this;
            }
        }
    }

    public Sprite[] GetPlanetVisuals()
    {
        return planetVisuals;
    }

    void SpawnWindowInGameCanvas(GameObject _instantiatedObject)
    {
        _instantiatedObject.transform.SetParent(gameCanvas.transform, false);
        _instantiatedObject.transform.position = Random.insideUnitCircle * 3;
        affichedWindows.Add(_instantiatedObject);
    }

    public void NextLevel()
    {
        if (remainingResolution <= 0)
        {
            idActualLevel++;
            if (idActualLevel < levels.Length)
            {
                remainingResolution = levels[idActualLevel].nbrResolution;
                resolutionTime = levels[idActualLevel].windowResolutionTime;

                if (idActualLevel == levels.Length / 2)
                {
                    Instantiate(bluescreenPrefab);
                }
            }
        }

        if (idActualLevel < levels.Length)
        {
            remainingResolution--;
            nbrWindowToShow = levels[idActualLevel].nbrWindow;
            remainingTime = resolutionTime;

            StartNewGame();
        }
        else
        {
            EndGame(true);
        }
    }

    private void ResetGameBoard()
    {
        if (affichedWindows.Count > 0)
        {
            for (int i = 0; i < affichedWindows.Count; i++)
            {
                Destroy(affichedWindows[i]);
            }

            affichedWindows.Clear();
        }

        if (ongletsHolder.childCount > 0)
        {
            for (int i = 0; i < ongletsHolder.childCount; i++)
            {
                Destroy(ongletsHolder.GetChild(i).gameObject);
            }
        }

        affichedWindows = new List<GameObject>();
    }

    public void LoseLive()
    {
        life--;
        if (life <= 0)
        {
            EndGame(false);
        }
        else
        {
            NextLevel();
        }
    }

    void EndGame(bool win)
    {
        ResetGameBoard();
        inGame = false;
        StopCoroutine(bluescreenCorout);

        if (win)
        {
            GameObject tempEndWindow = Instantiate(endWindow.gameObject, Vector3.zero, Quaternion.identity);
            SpawnWindowInGameCanvas(tempEndWindow);
        }
        else
        {
            echecCanvas.SetActive(true);
        }
    }

    IEnumerator BluescreenCoroutine()
    {
        for (int i = 0; i < howManyBluescreen; i++)
        {
            float rand = Random.Range(360, 2820 / howManyBluescreen);

            yield return new WaitForSeconds(rand);

            if (inGame)
            {
                alreadyHadBluescreen = true;
                Instantiate(bluescreenPrefab);
            }
        }
    }

    void DestroyTransition()
    {
        Destroy(transition.gameObject);
    }
}
