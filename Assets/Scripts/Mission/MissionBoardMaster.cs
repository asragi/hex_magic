﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionBoardMaster : MonoBehaviour
{
    MissionManager missionManager;
    // Start is called before the first frame update
    void Start()
    {
        missionManager = new MissionManager();
    }

    public void MissionCheck(ScoreStruct score){
        missionManager.MissionCheck(score);
    }
}