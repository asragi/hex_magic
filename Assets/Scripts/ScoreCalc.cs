using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCalc
{
    const int Base = 100;
    readonly int[] ChainPoint = {1, 10, 20, 40};
    public int Score(int deleteNum, int chainNum){
        var length = ChainPoint.Length;
        var rate = ChainPoint[length - 1];
        var chainP = (chainNum > length) ? rate * (chainNum - length + 1) : ChainPoint[chainNum - 1];
        return deleteNum * chainP * Base;
    }
}
