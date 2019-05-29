using System;
using UnityEngine;

[RequireComponent(typeof(CartItemType))]
public class CartItemSelect : MonoBehaviour
{
    // Start is called before the first frame update
    private CartItemType cartItemType;

    public GameEvent fightModeOnEvent;

    public GameEvent fightModeOffEvent;

    private bool isSelected = false;

    private void Start()
    {
        cartItemType = GetComponent<CartItemType>();

        if (cartItemType == null)
        {
            throw new NullReferenceException("GameObject muse have a Cart Item Type component");
        }
    }

    private void OnMouseDown()
    {
        if (cartItemType.itemType == CartItemType.ItemType.Fighting)
        {
            if (isSelected)
            {
                fightModeOffEvent.Raise();
            }
            else
            {
                fightModeOnEvent.Raise();
            }

            isSelected = !isSelected;
        }
    }
}