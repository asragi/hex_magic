using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMission : MissionBase
{
    readonly int[] normArray = new int[]{
        1500,
        7000,
        10000,
        20000,
        25000,
        50000,
        60000,
        80000,
        100000
    };

    int nowNorm;
    int scoreSum;
    public override void DecideMission(int lv){
        var target = Mathf.Min(lv, normArray.Length) - 1;
        nowNorm = normArray[target];
        scoreSum = 0;
    }

    public override string GetText(){
        return $"Get {nowNorm} Point!";
    }

    public override bool CheckClear(ScoreStruct getScore){
        scoreSum += getScore.GainScore;
        if (scoreSum >= nowNorm){
            return true;
        }
        return false;
    }
}
