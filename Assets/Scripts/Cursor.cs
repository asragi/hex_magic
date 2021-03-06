﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cursor : MonoBehaviour
{
    const float XDiff = 60;
    const float YDiff = 36;
    [SerializeField]
    GameObject nextBase;
    [SerializeField]
    GameObject nextSub;
    Hex2Img mainImg;
    Hex2Img subImg;

    HexColorPair standBy;

    public void Init()
    {
        mainImg = nextBase.GetComponent<Hex2Img>();
        subImg = nextSub.GetComponent<Hex2Img>();
    }

    // Update is called once per frame
    void Update()
    {
        var tmp = Input.mousePosition;
        tmp.z = 0;
        transform.position = tmp;
    }

    public void Disable(){
        nextBase.SetActive(false);
        nextSub.SetActive(false);
    }

    public void SetImages(HexColorPair pair){
        mainImg.ChangeImage(pair.Main);
        subImg.ChangeImage(pair.Sub);
    }

    public void SetTargetPoint(RPoint point){
        var x = point.x * XDiff;
        var y = point.y * YDiff;
        var z = nextSub.transform.localPosition.z;
        nextSub.transform.localPosition = new Vector3(x, y, z);
    }
}
