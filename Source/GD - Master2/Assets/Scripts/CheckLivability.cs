using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLivability : MonoBehaviour
{
    bool response;
    public GameManager gm;

    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
    }

    public void CheckLivabilityFunc(bool _response)
    {
        response = _response;
    }

    public void ValidateLivability()
    {
        if (GameManager.GetLivability() == response)
        {
            gm.NextLevel();
            gm.goodAnswer++;
        }
        else
        {
            gm.LoseLive();
        }
    }
}
