using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexMaster: MonoBehaviour
{
    const int RingSize = 5;
    [SerializeField]
    GameObject HexObject;

    HexCalculator hexCalc;

    private void Start()
    {
        var center = Vector3.zero;
        hexCalc = new HexCalculator(1, center);
        var proguression = hexCalc.CalcProgression(0, 6, RingSize);
        var hexNum = proguression[proguression.Length - 1];
        for (int i = 0; i < hexNum; i++)
        {
            Instantiate(HexObject, center + new Vector3(i, 0, 0), new Quaternion());
        }
        // Instantiate(HexObject, center, new Quaternion());
    }

    private void Update()
    {

    }
}
