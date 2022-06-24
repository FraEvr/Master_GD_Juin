using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittlePlanetMass : MonoBehaviour
{
    public float massValue = 1;
    Vector3 initPosi;

    void Start()
    {
        initPosi = transform.position;
        massValue *= 6000000000000000000000000f;
    }

    private void OnBecameInvisible()
    {
        transform.position = initPosi;
    }
}
