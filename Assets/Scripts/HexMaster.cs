using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexMaster: MonoBehaviour
{
    const int RingSize = 5;
    [SerializeField]
    GameObject HexObject;

    Hex[] hices;
    HexCalculator hexCalc;

    private void Start()
    {
        var center = Vector3.zero;
        hexCalc = new HexCalculator();
        var proguression = hexCalc.CalcProgression(0, 6, RingSize);
        var hexNum = proguression[proguression.Length - 1] + 1;
        hices = new Hex[hexNum];
        for (int i = 0; i < hexNum; i++)
        {
            var obj = Instantiate(HexObject, hexCalc.PositionFromIndex(i, center, 1, proguression), new Quaternion());
            obj.name = "obj"  + i;
            obj.transform.SetParent(transform);
            hices[i] = obj.GetComponent<Hex>();
            hices[i].SetHexMaster(this);
        }
    }

    private void Update()
    {

    }
}
