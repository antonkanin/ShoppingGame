using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CartManager : MonoBehaviour
{
    public GameObject[] cartGameObjects;

    private List<EShoppingItemType> cartItemTypes = new List<EShoppingItemType>();

    void Start()
    {
        SetDefaultValues();
    }

    void SetDefaultValues()
    {
        for (int index = 0; index < cartGameObjects.Length; ++index)
        {
            cartItemTypes.Add(EShoppingItemType.Empty);
        }

        foreach (var item in cartGameObjects)
        {
            item.GetComponentInChildren<Text>().text = "N/A";
            item.GetComponent<Button>().interactable = false;
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

        cartGameObjects[position].GetComponentInChildren<Text>().text = "N/A";
        cartGameObjects[position].GetComponent<Button>().interactable = false;

        cartItemTypes[position] = EShoppingItemType.Empty;
        
    }

    public EShoppingItemType GetItemType(int position)
    {
        CheckBounds(position);

        return cartItemTypes[position];
    }

    void CheckBounds(int position)
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

        cartGameObjects[position].GetComponentInChildren<Text>().text =
            ItemUtils.ItemName(itemType);

        cartGameObjects[position].GetComponent<Button>().interactable = true;
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
}