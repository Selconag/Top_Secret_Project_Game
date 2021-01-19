using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Urun : MonoBehaviour
{
    private float movementSpeed = 14.0f;
    //Eşyaların türlerine göre kuşanılmasını ve kullanılmasını sağlayan kısım
    public string Tipi;//Ürünün türünün belirlendiği kısım
    public int ID;//Ürünün kimlik verisi belirleyen ID
    public string Tarih_Giris;//Sisteme giriş saati
    public string Tarih_Cikis;//Sistemden çıkış saati
    public string Durumu;//En son girdiği makine durumu
    public bool Hatalı = false;//Üründe hata var mı?
    public Sprite icon;//Ürünü gösteren ikonu
    //public GameObject obje;

    public void Update ()
        {
        transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
    }

}
