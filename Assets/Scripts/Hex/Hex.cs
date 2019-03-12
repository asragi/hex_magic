using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hex : MonoBehaviour
{
    HexMaster master;
    public RPoint Point { get; set; }
    Hex[] contacted;

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
        for (int i = 0; i < contacted.Length; i++)
        {
            contacted[i]?.OnContacted();
        }
    }

    private void OnMouseExit()
    {
        for (int i = 0; i < contacted.Length; i++)
        {
            contacted[i]?.OnContactedExit();
        }
    }

    public void OnContacted()
    {
        GetComponent<Renderer>().material.color = Color.gray;
    }

    public void OnContactedExit()
    {
        GetComponent<Renderer>().material.color = Color.white;
    }

    public void SetHexMaster(HexMaster hm) => master = hm;
    public void SetContacted(Hex[] hices) => contacted = hices;
}
