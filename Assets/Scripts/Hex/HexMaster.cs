using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexMaster: MonoBehaviour
{
    const int RingSize = 5;
    [SerializeField]
    GameObject HexObject;

    Hex selectedHex;
    Hex[] hices;
    Hex[] contacted;
    HexCoordinate hexCoordinate;
    HexCalculator hexCalc;
    DeckManager deck;
    public int ChainNum {get; private set;}

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

    public void Update(){
        void DeleteShade(){
            if(selectedHex == null) return;
            var targetSub = hexCoordinate.TryGetHex(selectedHex.Point + deck.Target);
            targetSub?.OnContactedExit();
        }
        void AddShade(){
            if(selectedHex == null) return;
            var targetSub = hexCoordinate.TryGetHex(selectedHex.Point + deck.Target);
            targetSub?.OnContacted();
        }
        if(Input.GetKeyDown(KeyCode.Space)){
            DeleteShade();
            deck.ChangeTarget();
            AddShade();
        }
    }

    public void PointerEnter(Hex hex){
        hex.OnContacted();
        selectedHex = hex;
        var targetSub = hexCoordinate.TryGetHex(hex.Point + deck.Target);
        targetSub?.OnContacted();
    }

    public void PointerExit(Hex hex){
        selectedHex = null;
        hex.OnContactedExit();
        var targetSub = hexCoordinate.TryGetHex(hex.Point + deck.Target);
        targetSub?.OnContactedExit();
    }

    public void HexClicked(int index){
        // Check if placable
        var target = hices[index];
        var targetSub = hexCoordinate.TryGetHex(target.Point + deck.Target);
        // Check
        if (targetSub == null) return;
        if (target.HexColor != HexColor.None) return;
        if (targetSub.HexColor != HexColor.None) return;
        // Place
        target.SetHex(deck.NowPair.Main);
        targetSub.SetHex(deck.NowPair.Sub);
        deck.Pop();
        // Chain Check
        ChainNum = 1;
        ContactCheck();
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
            if (hices[i].HexColor == HexColor.None) continue;
            if (hices[i].Vanished) continue;
            RefreshChecked();
            hices[i].StartCountCheck();
        }
        // Vanishing Check
        var vanishingSum = 0;
        for (int i = 0; i < hices.Length; i++)
        {
            if (hices[i].HexColor == HexColor.None) continue;
            if (!hices[i].Vanishing) continue;
            vanishingSum++;
            hices[i].Vanishing = false;
            hices[i].Vanished = true;
        }
        if (vanishingSum > 0){
            // Chain
            // Debug.Log($"{ChainNum} Chain!:{vanishingSum}");
            if(vanishingSum < 3){
                Debug.LogError("Chain Error");
            }
            for(int j=0; j<hices.Length; j++){
                // if(hices[j].Vanished) Debug.Log($"{j}:(React:{hices[j].ReactContact})");
            }
            ChainNum++;
            ContactCheck();
        }else{
            // Chain end
            // Elase Vanished Panel
            for (int i = 0; i < hices.Length; i++)
            {
                if (hices[i].HexColor == HexColor.None) continue;
                hices[i].Vanishing = false;
                if (!hices[i].Vanished) continue;
                hices[i].Vanished = false;
                hices[i].SetHex(HexColor.None);
            }
        }
    }
}
