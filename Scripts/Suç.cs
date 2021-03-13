using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suç : MonoBehaviour
{
    
    Player oyuncu;
    public double kapkaçSeviyesi, kapkaçBaşarıOranı, kapkaçEnerji, kapkaçAranmaMiktarı, kapkaçGoldKazancı;
    public double randomNum;

    void Start()
    {
        kapkaçEnerji = 5;
        kapkaçSeviyesi = 20;
        kapkaçAranmaMiktarı = 0.5;
        kapkaçGoldKazancı = 10;

        oyuncu = this.GetComponent<Player>();
        
        

    }

    void Update()
    {
        kapkaçBaşarıOranı = (oyuncu.şans / kapkaçSeviyesi) * 100;
    }

    public void kapkaçSuçİşle(){

        if(oyuncu.enerjiYeterliMi(oyuncu.enerji, kapkaçEnerji)){
            randomNum = Random.Range(1, 100);            
            if(kapkaçBaşarıOranı >= randomNum){
                Debug.Log("suç başarılı");
                oyuncu.golds += kapkaçGoldKazancı;
                oyuncu.enerji -= (int)(kapkaçEnerji / 2);
            }
            else{
                Debug.Log("suç başarısız");
                if(oyuncu.maxMı(oyuncu.aranma, kapkaçAranmaMiktarı, oyuncu.aranmaMax)){
                    oyuncu.aranma += kapkaçAranmaMiktarı;
                }
                else{
                    oyuncu.aranma = oyuncu.aranmaMax;
                }                
                oyuncu.enerji -= kapkaçEnerji;
            }
        }

    }
}
