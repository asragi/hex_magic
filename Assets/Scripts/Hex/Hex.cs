﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hex : MonoBehaviour
{
    HexMaster master;
    public RPoint Point { get; set; }
    Hex[] contacted;
    HexMagic hexMagic;
    public HexColor HexColor => hexMagic.HexColor;
    // check
    public bool Checked;
    private int contactCount;
    public int ContactCount => contactCount;
    Image image;
    [SerializeField]
    Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        hexMagic = new HexMagic();
        image = GetComponent<Image>();
        image.sprite = sprites[(int)HexColor];
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartCountCheck(){
        contactCount = 0;
        Count(ref contactCount);
    }

    public void Count(ref int n)
    {
        n = n + 1;
        Checked = true;
        for (int i=0; i<contacted.Length; i++){
            if (contacted[i] == null) continue;
            if (contacted[i].HexColor != HexColor) continue;
            if (contacted[i].Checked) continue;
            contacted[i].Count(ref n);
        }
    }

    void OnMouseEnter(){
        master.ContactCheck();
        Debug.Log(ContactCount);
    }
    void OnMouseOver()
    {
        OnContacted();
        for (int i = 0; i < contacted.Length; i++)
        {
            contacted[i]?.OnContacted();
        }
    }

    private void OnMouseExit()
    {
        OnContactedExit();
        for (int i = 0; i < contacted.Length; i++)
        {
            contacted[i]?.OnContactedExit();
        }
    }

    public void OnContacted()
    {

    }

    public void OnContactedExit()
    {

    }

    public void SetHexMaster(HexMaster hm) => master = hm;
    public void SetContacted(Hex[] hices) => contacted = hices;
}
