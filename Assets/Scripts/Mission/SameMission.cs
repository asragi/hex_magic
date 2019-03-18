using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SameMission : MissionBase
{
    int nowNorm;
    public override void DecideMission(int lv){
        nowNorm = (lv + 1) / 2 + 4;
    }

    public override string GetText(){
        return $"{nowNorm}パネル同時に消せ！";
    }

    public override bool CheckClear(ScoreStruct getScore){
        if (getScore.DeleteNum >= nowNorm) return true;
        return false;
    }
}
