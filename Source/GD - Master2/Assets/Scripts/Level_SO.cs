using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Level")]
public class Level_SO : ScriptableObject
{
    public int nbrResolution;
    public int nbrWindow;
    public float windowResolutionTime;
}
