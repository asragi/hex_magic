using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionBoardMaster : MonoBehaviour
{
    [SerializeField]
    MissionBoard[]  boards;
    MissionManager missionManager;
    IndexCounter index;
    Vector3[] initPos;
    // Start is called before the first frame update
    void Start()
    {
        index = new IndexCounter(boards.Length);
        missionManager = new MissionManager();
        boards[0].UpdateContent(missionManager.GetMission(0));
        boards[1].UpdateContent(missionManager.GetMission(1));

        initPos = new Vector3[2];
        initPos[0] = boards[0].transform.localPosition;
        initPos[1] = boards[1].transform.localPosition;
    }

    public bool MissionCheck(ScoreStruct score){
        var cleared = missionManager.MissionCheck(score);
        if(cleared) UpdateContent();
        return cleared;
    }

    private void UpdateContent(){
        index.Increment();
        Debug.Log(index.Index);
        boards[index.GetPrev()].gameObject.SetActive(false);
        boards[index.Index].UpdateContent(missionManager.GetMission(0));
        boards[index.Index].transform.localPosition = initPos[0];
        boards[index.GetNext()].gameObject.SetActive(true);
        boards[index.GetNext()].UpdateContent(missionManager.GetMission(1));
        boards[index.GetNext()].transform.localPosition = initPos[1];
    }
}
