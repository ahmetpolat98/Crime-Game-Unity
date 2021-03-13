using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freelance : MonoBehaviour
{

    Player oyuncu;

    public double amelelikEnerji, amelelikAranmaAzalma;
    public int amelelikGoldKazanç;
    void Start()
    {
        amelelikEnerji = 5;
        amelelikGoldKazanç = 5;
        amelelikAranmaAzalma = 0.1f;
        oyuncu = this.GetComponent<Player>();
    }


    void Update()
    {
        
    }

    public void amelelikYap(){
        
        if(oyuncu.enerjiYeterliMi(oyuncu.enerji, amelelikEnerji)){
            oyuncu.enerji -= amelelikEnerji;
            oyuncu.golds += amelelikGoldKazanç;
            if(!oyuncu.maxMı(oyuncu.aranma, -amelelikAranmaAzalma, oyuncu.aranmaMin)){
                oyuncu.aranma -= amelelikAranmaAzalma;
            }
            else{
                oyuncu.aranma = oyuncu.aranmaMin;
            }
        }

    }

}
