using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    
    public Text goldsText, levelText, itibarText, enerjiText, güçText, raconText, şansText, aranmaText, suçKapkaçText, enerjiTimerText, envanterİçerikText;
    public GameObject SuçİşleMenüsü, freelanceİşMenüsü, mülkMenüsü, envanterMenüsü, marketMenüsü;
    Player oyuncu;
    Suç suç;
    Inventory envanter;
    
    string minutes, seconds, envanterText;

    void Start()
    {
        oyuncu = this.GetComponent<Player>();
        suç = this.GetComponent<Suç>();
        envanter = this.GetComponent<Inventory>();


    }

    
    void Update()
    {
        goldsText.text = "Golds: " + oyuncu.golds;
        levelText.text = "Level: " + oyuncu.level;
        itibarText.text = "İtibar: " + oyuncu.itibar;
        enerjiText.text = "Enerji: " + oyuncu.enerji;
        güçText.text = "Güç: " + oyuncu.güç;
        raconText.text = "Racon: " + oyuncu.racon;
        şansText.text = "Şans: "+ oyuncu.şans;
        aranmaText.text ="Aranma: " + oyuncu.aranma;
        suçKapkaçText.text ="Kapkaç yap. Başarı oranı: %" + suç.kapkaçBaşarıOranı;
        
        refreshInventory();
        envanterİçerikText.text = envanterText;

        minutes = ((int) oyuncu.enerjiTimer / 60).ToString();
        seconds = (oyuncu.enerjiTimer % 60).ToString("F0");
        enerjiTimerText.text = minutes + ":" + seconds;

        
    }

    private void refreshInventory(){
        envanterText = "";
        foreach (Item item in envanter.GetItemList()){
            envanterText += item.itemType + " = " + item.amount + System.Environment.NewLine;
        }         
    }

    public void SuçİşleMenüsüAç(){
        SuçİşleMenüsü.SetActive(true);
    }
    public void SuçİşleMenüsüKapat(){
        SuçİşleMenüsü.SetActive(false);
    }

    public void freelanceİşMenüsüAç(){
        freelanceİşMenüsü.SetActive(true);
    }
    public void freelanceİşMenüsüKapat(){
        freelanceİşMenüsü.SetActive(false);
    }

    public void mülkMenüsüAç(){
        mülkMenüsü.SetActive(true);
    }
    public void mülkMenüsüKapat(){
        mülkMenüsü.SetActive(false);
    }

    public void envanterMenüsüAç(){
        envanterMenüsü.SetActive(true);
    }
    public void envanterMenüsüKapat(){
        envanterMenüsü.SetActive(false);
    }

    public void marketMenüsüAç(){
        marketMenüsü.SetActive(true);
    }
    public void marketMenüsüKapat(){
        marketMenüsü.SetActive(false);
    }

}
