using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemPickup : MonoBehaviour
{
    public GameEvent pickupEvent;

    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            pickupEvent.Raise();
            Destroy(gameObject);
        }
    }
}