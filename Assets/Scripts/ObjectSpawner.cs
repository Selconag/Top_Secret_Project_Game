using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ObjectSpawner : MonoBehaviour
{
    public float movementSpeed = 4.0f;
    public GameObject obj1;
    private Transform Main;
    public float spawnTime = 4f;
    private Vector3 Loc;
    [SerializeField]
    private GameObject Makina;
    public int i = 0, Makina_sayisi = 5;
    public bool routine = true;

    void Start()
    {
        Main = GameObject.Find("Giris").transform;
        Vector3 poson = Main.position;
        for(i=0;i< Makina_sayisi; i++)
        {
            //Instantiate(Makina);
        }
    }
    void Update()
    {
        if(routine)
        StartCoroutine(SpawnerCouroutine());
    }
    public void SpawnObject()
    {
        string time = System.DateTime.UtcNow.ToLocalTime().ToString("dd-MM-yyyy HH:mm:ss");
        GameObject yeni_Urun = Instantiate(obj1, Main);
        Urun urun = yeni_Urun.GetComponent<Urun>();
        urun.Tarih_Giris = time;
    }
    IEnumerator SpawnerCouroutine()
    {
        routine = false;
        yield return new WaitForSeconds(3);
        SpawnObject();
        routine = true;
    }
}