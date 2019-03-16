using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainMission : MissionBase
{
    public override void DecideMission(int lv){

    }

    public override string GetText(){
        return "hoge";
    }

    public override bool CheckClear(ScoreStruct getScore){
        return true;
    }
}
