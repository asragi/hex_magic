using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexMagic
{
    public HexColor HexColor {get; set;}

    public HexMagic(){
        Start();
    }
    // Start is called before the first frame update
    void Start()
    {
        HexColor = HexColor.None;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
