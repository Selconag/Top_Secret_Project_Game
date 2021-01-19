using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private int i;
    private bool inventoryEnabled;
    public GameObject inventory;
    private int allSlots;
    private int enabledSlots;
    private GameObject[] slot;//Paneldeki slotlar
    public GameObject slotHolder;//Paneldeki slotları tutan slotholder    
    //Start => Envanterdeki bütün slotları tara
    //Obje varsa slota gönder
    //Obje yoksa empty değerini true ata
    //İkonları envanterde göster
    void Start()
    {
        allSlots = 40;
        slot = new GameObject[allSlots];
        for(i = 0; i < allSlots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i).gameObject;
            if (slot[i].GetComponent<Slot>().item == null)
            {
                slot[i].GetComponent<Slot>().empty = true;

            }
        }
    }
    //Update => Envanterin açık olup olmadığını kontrol et
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryEnabled = !inventoryEnabled;
            if(inventoryEnabled == true)
            {
                inventory.SetActive(true);  
            }
            else
            {
                inventory.SetActive(false);
            }
        }
    }
    //Playerin herhangi bir objeye çarptığını kontrol et
    //Eğer obje "item" tagına sahipse ekleme olaylarını başlat
    public void OnTriggerEnter(Collider col)
    {
        if(col.tag == "item")
        {
            GameObject ItemPickedUp = col.gameObject;
            Item item = ItemPickedUp.GetComponent<Item>();
            AddItem(ItemPickedUp, item.ID,item.type, item.icon,item.description);
        }
    }
    //Ekleme olaylarının gerçekleştiği yer
    public void AddItem(GameObject itemObject,int ItemID,string ItemType, Sprite icon,string ItemDescription)
    {

        for (i = 0; i < allSlots; i++)
        {
            if (slot[i].GetComponent<Slot>().empty == true)
            {
                //Burası slot'a itemin scriptine göre eklendiği kısım
                itemObject.GetComponent<Item>().pickedUp = true;
                slot[i].GetComponent<Slot>().item = itemObject;
                slot[i].GetComponent<Slot>().icon = icon;
                slot[i].GetComponent<Slot>().ID = ItemID;
                slot[i].GetComponent<Slot>().type = ItemType;
                slot[i].GetComponent<Slot>().description = ItemDescription;
                //Burası slotun yenilendiği,boş olmadığı ve inaktif edildiği kısım
                itemObject.transform.parent = slot[i].transform;
                itemObject.SetActive(false);
                slot[i].GetComponent<Slot>().UpdateSlot();//Bu kısma 1.den sonra giriş yapmıyor
                slot[i].GetComponent<Slot>().empty = false;//Bu kısma 1.den sonra giriş yapmıyor
                return;
            }
            else
            {
                continue;
            }
        }
    }
}
