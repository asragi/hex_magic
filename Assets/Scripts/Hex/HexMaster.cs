using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexMaster: MonoBehaviour
{
    const int RingSize = 5;
    [SerializeField]
    GameObject HexObject;

    Hex[] hices;
    Hex[] contacted;
    HexCoordinate hexCoordinate;
    HexCalculator hexCalc;
    DeckManager deck;

    private void Start()
    {
        var center = Vector3.zero;
        hexCalc = new HexCalculator();
        hexCoordinate = new HexCoordinate(RingSize - 1, (RingSize - 1) * 2);
        var proguression = hexCalc.CalcProgression(0, 6, RingSize);
        var hexNum = proguression[proguression.Length - 1] + 1;
        hices = new Hex[hexNum];
        for (int i = 0; i < hexNum; i++)
        {
            var obj = Instantiate(HexObject, transform);
            obj.name = "obj"  + i;
            obj.transform.localPosition = hexCalc.PositionFromIndex(i, center, 88, proguression);
            // obj.transform.SetParent(transform);
            hices[i] = obj.GetComponent<Hex>();
            hices[i].Point = hexCalc.CalcCoordinate(i, proguression);
            hices[i].SetHexMaster(this);
            hices[i].ID = i;
            hexCoordinate.SetHex(hices[i]);
        }
        for (int i = 0; i < hexNum; i++)
        {
            hices[i].SetContacted(hexCoordinate.GetContactedHex(hices[i].Point));
        }

        deck = GetComponent<DeckManager>();
    }

    public void HexClicked(int index){
        // Check if placable
        deck.Pop();
    }

    public void RefreshChecked(){
        for (int i = 0; i < hices.Length; i++)
        {
            hices[i].Checked = false;
        }
    }

    public void ContactCheck(){
        for (int i = 0; i < hices.Length; i++)
        {
            RefreshChecked();
            hices[i].StartCountCheck();
        }
    }
}
