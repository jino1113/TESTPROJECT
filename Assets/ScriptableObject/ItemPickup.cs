using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public ItemDate date;

    private void Start()
    {
        GetComponent<Renderer>().material.color = date.itemcolor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            Debug.Log("Pick up " + date.itemName + " score " + date.scoreValue);
            Destroy(gameObject);
        }
    }
}
