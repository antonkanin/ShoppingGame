using UnityEngine;
using UnityEngine.EventSystems;

public class ItemPickableFromShelf : MonoBehaviour
{
    public ShoppingItemEvent pickupEvent;

    public EShoppingItemType itemType;

    public MeshRenderer itemBody;

    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            pickupEvent.Raise(itemType);
            
            MakeTransparent();
        }
    }

    void MakeTransparent()
    {
        var color = itemBody.material.color;

        itemBody.material.color = 
            new Color(color.r, color.g, color.b, 0.01f);
    }
}