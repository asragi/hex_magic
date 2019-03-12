using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    [SerializeField]
    GameObject cursor;
    HexDeck deck;
    // Start is called before the first frame update
    void Start()
    {
        deck = new HexDeck();
        deck.MakeDeck();
    }

    public HexColorPair Pop(){
        return new HexColorPair(deck.Pop(), deck.Pop());
    }
}
