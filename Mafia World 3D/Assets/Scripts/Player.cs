using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{


    
    //public GameObject a;
    public double golds, xp, şans, itibar, racon, aranma, level, enerji, güç, enerjiMax, aranmaMax, enerjiMin, aranmaMin;
    public double levelOranı, itibarOranı, raconOranı, güçOranı, enerjiOranı, aranmaOranı, enerjiTimerEklenenMiktar;
    public float enerjiTimer, enerjiTimerSüresi;
    //private Inventory inventory;
    //[SerializeField] private MenuManager envanterMenüsü;


    public void Awake()
    {
        golds = 100;
        level = 1;
        itibar = 0;
        enerji = 50;
        güç = 1;
        xp = 0;
        aranma = 0;
        racon = 0;
        levelOranı = 10;
        itibarOranı = 1.5;
        raconOranı = 1.75;
        güçOranı = 5;
        enerjiOranı = 10;
        aranmaOranı = 1;
        enerjiTimerSüresi = 100;
        enerjiTimer = enerjiTimerSüresi;
        enerjiMax = 100;
        aranmaMax = 100;
        enerjiMin = 0;
        aranmaMin = 0;
        enerjiTimerEklenenMiktar = 1;


        //inventory = new Inventory();


    }

    
    public void Update()
    {
    
        enerjiTimer -= Time.deltaTime;
        if(enerjiTimer <= 0.0f){
            enerjiEkle();
        }

        //suçu işleyebilmek için gereken şans oranı
        şans = (level * levelOranı) + ( itibar * itibarOranı) + ( racon * raconOranı) + ( güç * güçOranı) - ( enerjiOranı / enerji) - (aranma * aranmaOranı);

    }

    //enerjinin yeterli olup olmadığını kontrol eder
    public bool enerjiYeterliMi(double mevcutEnerji, double gerekenEnerji){

        if(mevcutEnerji >= gerekenEnerji){
            return true;
        }
        else{
            Debug.Log("Enerji yetersiz");
            return false;
        }
    }

    //goldun yeterli olup olmadığını kontrol eder
    public bool goldYeterliMi(double mevcutGold, double gerekenGold){
        
        if(mevcutGold >= gerekenGold){
            return true;
        }
        else{
            Debug.Log("Gold yetersiz");
            return false;
        }
    }

    public bool maxMı(double mevcut, double eklenenMiktar, double maxSeviyesi){
    //çıkarma işleminde eklenen miktar eksi gönderilir ve false dönüşünde işlem yapılır. true dönüşünde min değere eşitlenir.

        if(mevcut + eklenenMiktar <= maxSeviyesi){
            return true;
        }
        else{
            return false;
        }
    }

    //oyuncuya timer sonunda enerji ekler
    void enerjiEkle(){
        if(maxMı(enerji, enerjiTimerEklenenMiktar, enerjiMax)){
            enerji += enerjiTimerEklenenMiktar;
        }
        else{
            enerji = enerjiMax;
        }
        enerjiTimer = enerjiTimerSüresi;
    }


}
