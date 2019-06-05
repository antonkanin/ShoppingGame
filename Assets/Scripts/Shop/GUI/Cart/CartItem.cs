using System;
using UnityEngine;
using UnityEngine.UI;

public class CartItem : MonoBehaviour
{
    public Text itemText;

    public Image image;

    public Button button;

    private CartManager cartManager;

    private EShoppingItemType itemType;

    void Start()
    {
        Debug.Log("CartItem::Start()");

        var cartObject = GameObject.Find("ShoppingCart");

        if (cartObject == null)
        {
            throw new NullReferenceException("Cannot find Shopping Cart game object");
        }

        cartManager = cartObject.GetComponent<CartManager>();

        if (cartManager == null)
        {
            throw new NullReferenceException("Cannot find CartManager component " +
                                             "attached to Shopping Cart game object");
        }
    }

    public EShoppingItemType ItemType
    {
        get { return itemType; }
        set
        {
            itemType = value;

            if (itemType == EShoppingItemType.Empty)
            {
                button.interactable = false;
                itemText.text = "N/A";
            }
            else
            {
                button.interactable = true;
                itemText.text = ItemUtils.ItemName(itemType);
            }
        }
    }

    public void SetCanClick(bool state)
    {
        if (ItemType == EShoppingItemType.Empty)
        {
            return;
        }

        if (state)
        {
            if (ItemUtils.IsFightingItem(ItemType))
            {
                image.color = Color.red;
            }
            else
            {
                image.color = Color.green;
            }
        }
        else
        {
            image.color = Color.white;
        }
    }

    public void RemoveItem()
    {
        Debug.Log("CartItem::RemoveItem()");

        if (cartManager != null)
        {
            cartManager.SelectItem(transform.GetSiblingIndex());
        }
        else
        {
            throw new NullReferenceException("cartManager is null, but that should have never happened. " +
                                             "Only god can help us.");
        }
    }
}