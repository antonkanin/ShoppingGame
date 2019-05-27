using UnityEngine;
using UnityEngine.EventSystems;

public class ItemPickableFromShelf : MonoBehaviour
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