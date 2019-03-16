using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SameMission : MissionBase
{
    public override void DecideMission(int lv){

    }

    public override string GetText(){
        return "Same Mission";
    }

    public override bool CheckClear(ScoreStruct getScore){
        return true;
    }
}
