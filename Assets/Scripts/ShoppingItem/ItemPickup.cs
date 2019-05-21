using System;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public GameEvent pickupEvent;
    
    private void OnMouseDown()
    {
        pickupEvent.Raise();
        Debug.Log("Item picked");
        Destroy(gameObject);
    }
}
