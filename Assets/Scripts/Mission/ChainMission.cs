using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainMission : MissionBase
{
    readonly int[] ChainNorm = new int[]{2, 3, 3, 4, 4, 5, 5, 6, 6, 7};
    int nowNorm;
    public override void DecideMission(int lv){
        var target = Mathf.Min(lv, ChainNorm.Length) - 1;
        nowNorm = ChainNorm[target];
    }

    public override string GetText(){
        return $"Make {nowNorm} Chain!";
    }

    public override bool CheckClear(ScoreStruct getScore){
        if (getScore.ChainNum >= nowNorm) return true;
        return false;
    }
}
