using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Slot : MonoBehaviour , IPointerClickHandler
{
    //Inventory panelinde bulunan slotların addItem() sayesinde eşyaların eklendiği ve tutulduğu yerdir.
    //Buraya gelen itemler her bir slotta farklı veya aynı değerlerle bulunabilir
    public bool empty;
    public Sprite icon;
    public string type;
    public int ID;
    public string description;
    public GameObject item;
    public Transform slotIconGO;
    public GroundPlacementController A;

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        UseItem();
    }
    private void Start()
    {
        slotIconGO = transform.GetChild(0);
    }
    //Slottaki resmin nerede ve hangi ikonla gösterilmesini sağlayan kısım
    public void UpdateSlot()
    {
        slotIconGO.GetComponent<Image>().sprite = icon;
    }
    //Eşyaya tıklandığında Item scriptinden ele alarak kullanmayı sağlayan kısım
    public void UseItem()
    {
        item.GetComponent<Item>().ItemUsage();
        //A.ChangeCurrentPlaceableObject(item);
    }
}
