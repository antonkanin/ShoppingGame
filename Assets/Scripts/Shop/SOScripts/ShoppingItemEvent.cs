using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ShoppingItemEvent : ScriptableObject
{
    private List<ShoppingItemEventListener> listeners = new List<ShoppingItemEventListener>();

    public void Raise(EShoppingItemType itemType)
    {
        for (int index = listeners.Count - 1; index >= 0; --index)
        {
            listeners[index].OnEventRaised(itemType);
        }
    }

    public void RegisterListener(ShoppingItemEventListener listener)
    {
        listeners.Add(listener);
    }

    public void UnRegisterListener(ShoppingItemEventListener listener)
    {
        listeners.Remove(listener);
    }
}