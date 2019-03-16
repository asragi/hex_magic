using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarnedScore : MonoBehaviour
{
    [SerializeField]
    ChainDisplay chainDisplay;
    [SerializeField]
    ScoreGetDisplay getDisplay;

    public void PopUp(int chainNum, int deleteNum, int score){
        chainDisplay.PopUp(chainNum);
        getDisplay.PopUp(score);
    }
}
