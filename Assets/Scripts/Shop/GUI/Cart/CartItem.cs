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
        var cartObject = GameObject.Find("ShoppingCart");

        if (cartObject == null)
        {
            throw new NullReferenceException("Cannot find Shopping Cart game object");
        }

        cartManager = cartObject.GetComponent<CartManager>();
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
        cartManager.SelectItem(transform.GetSiblingIndex());
    }
}