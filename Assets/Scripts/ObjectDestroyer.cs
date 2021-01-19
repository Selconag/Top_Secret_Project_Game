using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    void OnTriggerEnter(Collider Col)
    {
        Debug.Log("Item Destroyed");
        if (Col.gameObject.tag == "Urun")
        {
            Destroy(Col.gameObject);
        }


    }
}
