using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Makina : MonoBehaviour
{
    public insert ins;
    public int GirenToplamEsya = 0;//Gün içinde makinaya giren toplam ürün
    public bool Destroyer = false;//Yok edici makina ise true, değilse false
    private void OnTriggerEnter(Collider other)
    {
        string time = System.DateTime.UtcNow.ToLocalTime().ToString("dd-MM-yyyy HH:mm:ss");
        if (other.tag == "Urun")
        {
            GameObject Object = GameObject.FindGameObjectWithTag("Urun");
            Urun urun = Object.GetComponent<Urun>();
            urun.Durumu = "Trigger";
            urun.Tarih_Cikis = time;
            GirenToplamEsya++;
            if (Destroyer)
            {
                Destroy(Object);
            }
        }
    }

}
