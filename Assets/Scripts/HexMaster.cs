﻿using System.Collections;
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
        hexCalc = new HexCalculator();
        var proguression = hexCalc.CalcProgression(0, 6, RingSize);
        var hexNum = proguression[proguression.Length - 1];
        for (int i = 0; i < hexNum + 1; i++)
        {
            var obj = Instantiate(HexObject, hexCalc.PositionFromIndex(i, center, 1, proguression), new Quaternion());
            obj.name = "obj"  + i;
        }
    }

    private void Update()
    {

    }
}
