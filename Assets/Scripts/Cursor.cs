using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cursor : MonoBehaviour
{
    [SerializeField]
    GameObject nextBase;
    [SerializeField]
    GameObject nextSub;

    HexColorPair standBy;
    // Start is called before the first frame update
    void Start()
    {
        standBy = new HexColorPair(HexColor.Blue, HexColor.White);
        nextBase.GetComponent<Hex2Img>().ChangeImage(standBy.Main);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Input.mousePosition;
    }
}
