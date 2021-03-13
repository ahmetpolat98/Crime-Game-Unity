using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{

    Inventory envanter;
    Player oyuncu;

    public Text maymuncuk_satınAl_text, maymuncuk_text;
    public double maymuncuk_fiyat;
    public int maymuncuk_miktarı;

    void Start()
    {
        envanter = this.GetComponent<Inventory>();
        oyuncu = this.GetComponent<Player>();

        maymuncuk_fiyat = 10;
        maymuncuk_miktarı = 0;

        maymuncuk_satınAl_text.text = "Satın Al";
        maymuncuk_text.text = "Maymuncuk: " + maymuncuk_fiyat + " Gold" + "  - Mevcut: " + maymuncuk_miktarı;

    }

    void Update(){
        maymuncuk_miktarı = envanter.getItemAmount(Item.ItemType.Maymuncuk);
        maymuncuk_text.text = "Maymuncuk: " + maymuncuk_fiyat + " Gold" + "  - Mevcut: " + maymuncuk_miktarı;
    }


    //maymuncuk satın al
    public void maymuncukSatınAl(){
        if(oyuncu.goldYeterliMi(oyuncu.golds, maymuncuk_fiyat)){
            oyuncu.golds -= maymuncuk_fiyat;
            envanter.AddItem(new Item {itemType = Item.ItemType.Maymuncuk, amount = 1});
        }
    }


}
