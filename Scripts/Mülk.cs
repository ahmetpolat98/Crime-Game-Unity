using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mülk : MonoBehaviour
{

    public bool bodrumKatı, bodrumKatıTimeKontrol;
    public double bodrumKatıFiyat, bodrumKatıEnerji, bodrumKatıAranma;
    public float bodrumKatıCooldown, bodrumKatıCooldownSüresi;
    Player oyuncu;
    public Text bodrumSatınAlText, bodrumKatıText;

    void Start()
    {
        oyuncu = this.GetComponent<Player>();
        bodrumSatınAlText.text = "Satın Al";
        bodrumKatıFiyat = 100;
        bodrumKatıEnerji = 10;
        bodrumKatıAranma = 10;
        bodrumKatıCooldownSüresi = 10;
        bodrumKatı = false;
        bodrumKatıTimeKontrol = true;
        bodrumKatıCooldown = bodrumKatıCooldownSüresi;

    }

    void Update()
    {
        if(bodrumKatı && bodrumKatıTimeKontrol){
            bodrumKatıCooldown = bodrumKatıCooldownSüresi;
            bodrumKatıTimeKontrol = false;
        }
        else if(bodrumKatı && !bodrumKatıTimeKontrol){
            bodrumKatıCooldown -= Time.deltaTime;
            if(bodrumKatıCooldown <= 0.0f){
                bodrumKatıGeliştirmeler();
                bodrumKatıTimeKontrol = true;
            }
        }

        if(bodrumKatı){
            bodrumSatınAlText.text = "Satın Alındı";
            bodrumKatıText.text ="Bodrum katı (Her " + bodrumKatıCooldownSüresi +  " saniyede " + bodrumKatıEnerji + " Enerji yeniler ve " + bodrumKatıAranma + " Aranma düşürür.)";
        }
        else{
            bodrumSatınAlText.text = "Satın Al";
            bodrumKatıText.text ="Bodrum katı (Her " + bodrumKatıCooldownSüresi +  " saniyede " + bodrumKatıEnerji + " Enerji yeniler ve " + bodrumKatıAranma + " Aranma düşürür. Fiyat: " + bodrumKatıFiyat + " )";
        }
    }

    public void bodrumSatınAl(){

        if(bodrumKatı != true){
            
            if(oyuncu.goldYeterliMi(oyuncu.golds, bodrumKatıFiyat)){
                oyuncu.golds -= bodrumKatıFiyat;
                bodrumKatı = true;
            }
        }
        else{
            Debug.Log("Zaten Bodrum Katına Sahipsin");
        }
    }

    void bodrumKatıGeliştirmeler(){

        if(oyuncu.maxMı(oyuncu.enerji, bodrumKatıEnerji, oyuncu.enerjiMax)){
            oyuncu.enerji += bodrumKatıEnerji;
        }
        else{
            oyuncu.enerji = oyuncu.enerjiMax;
        }

        if(!oyuncu.maxMı(oyuncu.aranma, -bodrumKatıAranma, oyuncu.aranmaMin)){
            oyuncu.aranma -= bodrumKatıAranma;
        }
        else{
            oyuncu.aranma = oyuncu.aranmaMin;
        }        
    }


}
