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
    Hex2Img mainImg;
    Hex2Img subImg;

    HexColorPair standBy;
    // Start is called before the first frame update
    void Start()
    {
        mainImg = nextBase.GetComponent<Hex2Img>();
        subImg = nextSub.GetComponent<Hex2Img>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Input.mousePosition;
    }

    public void SetImages(HexColorPair pair){
        mainImg.ChangeImage(pair.Main);
        subImg.ChangeImage(pair.Sub);
    }
}
