using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Hex : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
{
    [SerializeField]
    ParticleSystem particle;
    Animator anim;
    HexMaster master;
    public RPoint Point { get; set; }
    Hex[] contacted;
    HexMagic hexMagic;
    public HexColor HexColor => hexMagic.HexColor;
    // check
    public bool Checked;
    private int contactCount;
    public int ContactCount => contactCount;
    Image image;
    public int ID {get; set;}
    Hex2Img hex2Img;
    public bool Vanishing {get; set;} // 前の連鎖で消えたもの
    public bool vanish;
    public bool Vanished {
        get => vanish;
        set { vanish = value; anim.SetBool("Vanishing", value); }
    } // 2つ以上前の連鎖で消えたもの
    public bool ReactContact;

    // Start is called before the first frame update
    void Start()
    {
        hexMagic = new HexMagic();
        image = GetComponent<Image>();
        image.alphaHitTestMinimumThreshold = 0.5f;
        hex2Img = GetComponent<Hex2Img>();
        anim = GetComponent<Animator>();
    }

    public void StartCountCheck(){
        contactCount = 0;
        ReactContact = false;
        Count(ref contactCount, ref ReactContact);
        if(contactCount >= VanishNum()) OnVanish();
    }

    private int VanishNum() {
        if (ReactContact) return 3;
        return 4;
    }

    public void OnVanish(){
        Vanishing = true;
        particle.Play();
    }

    public void Count(ref int n, ref bool contact)
    {
        n = n + 1;
        Checked = true;
        for (int i=0; i<contacted.Length; i++){
            if (contacted[i] == null) continue;
            if (contacted[i].HexColor != HexColor) continue;
            contact = contact || ContactVanished();
            if (contacted[i].Checked) continue;
            contacted[i].Count(ref n, ref contact);
        }
    }

    private bool ContactVanished(){
        for(int i=0; i<contacted.Length; ++i){
            if(contacted[i] == null) continue;
            if(contacted[i].Vanished) return true;
        }
        return false;
    }

    public void OnContacted()
    {
        image.color = Color.red;
    }

    public void OnContactedExit()
    {
        image.color = Color.white;
    }

    public void SetHexMaster(HexMaster hm) => master = hm;
    public void SetContacted(Hex[] hices) => contacted = hices;

    // オブジェクトの範囲内にマウスポインタが入った際に呼び出されます。
    // this method called by mouse-pointer enter the object.
    public void OnPointerEnter( PointerEventData eventData )
    {
        master.PointerEnter(this);
    }

    // オブジェクトの範囲内からマウスポインタが出た際に呼び出されます。
    //
    public void OnPointerExit( PointerEventData eventData )
    {
        master.PointerExit(this);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        master.HexClicked(ID);
    }

    public void SetHex(HexColor color){
        hexMagic.HexColor = color;
        hex2Img.ChangeImage(HexColor);
    }
}
