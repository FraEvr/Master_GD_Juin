using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/StarType")]
public class StarType_SO : ScriptableObject
{
    public Sprite starVisual;
    public Vector2 imageSize;
    public string spectralType;
    public float temperature;
    public float radius;
    public float mass;
    public float luminosity;
    public float lifetime;
    public float abundance;
}
