using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hex : MonoBehaviour
{
    HexMaster master;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseOver()
    {
        Contacted();
    }

    private void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }

    public void Contacted()
    {
        GetComponent<Renderer>().material.color = Color.gray;
    }

    public void SetHexMaster(HexMaster hm) => master = hm;
}
