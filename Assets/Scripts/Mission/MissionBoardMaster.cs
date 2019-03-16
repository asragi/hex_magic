using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionBoardMaster : MonoBehaviour
{
    [SerializeField]
    MissionBoard[]  boards;
    MissionManager missionManager;
    // Start is called before the first frame update
    void Start()
    {
        missionManager = new MissionManager();
        boards[0].UpdateContent(missionManager.GetMission(0));
        // boards[1].UpdateContent(missionManager.GetMission(1));
    }

    public void MissionCheck(ScoreStruct score){
        missionManager.MissionCheck(score);
    }
}
