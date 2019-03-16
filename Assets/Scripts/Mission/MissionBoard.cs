using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionBoard : MonoBehaviour
{
    [SerializeField]
    Text message;

    public void UpdateContent(MissionBase mission){
        message.text = mission.GetText();
    }
}
