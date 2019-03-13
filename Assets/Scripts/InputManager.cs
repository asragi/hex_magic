using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField]
    GameMaster master;
    [SerializeField]
    HexMaster hexMaster;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        void InputKey(){
            if(master.PuzzleState != PuzzleState.Play) return;
            if(Input.GetKeyDown(KeyCode.Q)){
                hexMaster.RotateInput(false);
            }
            if(Input.GetKeyDown(KeyCode.E)){
                hexMaster.RotateInput(true);
            }
        }
        InputKey();
    }
}
