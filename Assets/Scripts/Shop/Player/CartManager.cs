using System;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class CartManager : MonoBehaviour
{
    public GameEvent fightModeOnEvent;

    public CartItem[] cartGameObjects;

    private List<EShoppingItemType> cartItemTypes = new List<EShoppingItemType>();

    private CheckNeighbour neighbourUtils;

    private bool isFightModeOn = false;

    private bool canReturnItemsToShelf = false;

    private int fightingItemPosition;

    void Start()
    {
        neighbourUtils = Utils.FindPlayer().GetComponent<CheckNeighbour>();

        SetDefaultValues();
    }

    void SetDefaultValues()
    {
        for (int index = 0; index < cartGameObjects.Length; ++index)
        {
            cartItemTypes.Add(EShoppingItemType.Empty);

            cartGameObjects[index].ItemType = EShoppingItemType.Empty;
        }
    }

    public void AddItem(EShoppingItemType itemType)
    {
        int availablePosition = GetAvailablePosition();

        if (availablePosition < 0)
        {
            Debug.Log("Shopping cart if full");
            return;
        }

        AddItemToPosition(availablePosition, itemType);
    }

    public void RemoveItem(int position)
    {
        CheckBounds(position);

        cartGameObjects[position].SetCanClick(false);
        cartGameObjects[position].ItemType = EShoppingItemType.Empty;

        cartItemTypes[position] = EShoppingItemType.Empty;
    }

    public EShoppingItemType GetItemType(int position)
    {
        CheckBounds(position);

        return cartItemTypes[position];
    }

    private string GetItemName(int position)
    {
        return ItemUtils.ItemName(GetItemType(position));
    }

    static void CheckBounds(int position)
    {
        const int cartItemsMaxCount = 8;

        if (position < 0 || position >= cartItemsMaxCount)
        {
            throw new IndexOutOfRangeException("Item position " + position + " is out of bounds");
        }
    }

    void AddItemToPosition(int position, EShoppingItemType itemType)
    {
        cartItemTypes[position] = itemType;
        cartGameObjects[position].ItemType = itemType;

        if (canReturnItemsToShelf || neighbourUtils.IsTowerNearBy())
        {
            cartGameObjects[position].SetCanClick(true);
        }
    }

    int GetAvailablePosition()
    {
        int availablePosition = -1;

        for (int index = 0; index < cartItemTypes.Count; ++index)
        {
            if (cartItemTypes[index] == EShoppingItemType.Empty)
            {
                availablePosition = index;
                break;
            }
        }

        return availablePosition;
    }

    public void SelectItem(int position)
    {
        Debug.Log("Selecting item " + GetItemName(position));

        var itemType = GetItemType(position);

        if (ItemUtils.IsFightingItem(itemType))
        {
            if (!isFightModeOn)
            {
                TryInitializeFightMode(position);
            }
            else
            {
                Debug.Log("You are already in the fight mode");
            }
        }
        else
        {
            Debug.Log("Regular item - we will move it to the shelf....");
        }
    }

    void TryInitializeFightMode(int position)
    {
        if (neighbourUtils.IsTowerNearBy())
        {
            isFightModeOn = true;
            fightingItemPosition = position;

            fightModeOnEvent.Raise();
        }
    }

    public void FightModeOff()
    {
        if (isFightModeOn)
        {
            isFightModeOn = false;
            RemoveItem(fightingItemPosition);
            fightingItemPosition = -1;
        }
    }

    public void EnableReturnableItems()
    {
        SetReturnableItemsState(true);
    }

    public void DisableReturnableItems()
    {
        SetReturnableItemsState(false);
    }

    void SetReturnableItemsState(bool state)
    {
        canReturnItemsToShelf = state;

        for (int index = 0; index < cartItemTypes.Count; ++index)
        {
            if (false == ItemUtils.IsFightingItem(cartItemTypes[index]))
            {
                if (cartItemTypes[index] != EShoppingItemType.Empty)
                {
                    cartGameObjects[index].SetCanClick(state);
                }
            }
        }
    }
}