using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ShoppingItemUnityEvent : UnityEvent<EShoppingItemType>
{}

public class ShoppingItemEventListener : MonoBehaviour
{
    public ShoppingItemEvent Event;

    public ShoppingItemUnityEvent Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnRegisterListener(this);
    }

    public void OnEventRaised(EShoppingItemType itemType)
    {
        Response.Invoke(itemType);
    }
}
