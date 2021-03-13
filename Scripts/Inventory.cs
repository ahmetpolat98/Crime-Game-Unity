using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour{

    private List<Item> itemList;


    void Awake(){
        itemList = new List<Item>();

    }

    //item ekleme
    public void AddItem(Item item){
        bool itemAdded = false;
        foreach(Item inventoryItem in itemList){
            if(inventoryItem.itemType == item.itemType){
                inventoryItem.amount += item.amount;
                itemAdded = true;
            }
        }    
        if(!itemAdded){
            itemList.Add(item);
        }       
    }

    public List<Item> GetItemList(){
        return itemList;
    }

    
    //itemlistten istenen tipte ürünün sayısını döndürür
    public int getItemAmount(Item.ItemType item){
        foreach(Item inventoryItem in itemList){
            if(inventoryItem.itemType == item){
                return inventoryItem.amount;
            }
        }
        return 0;
    }

}
