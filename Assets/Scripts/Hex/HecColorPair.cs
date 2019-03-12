using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct HexColorPair
{
    public HexColor Main;
    public HexColor Sub;
    public HexColorPair(HexColor main, HexColor sub){
        Main = main;
        Sub = sub;
    }
}
