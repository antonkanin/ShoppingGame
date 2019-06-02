using System.Collections.Generic;
using UnityEngine;

public class CartHighlight : MonoBehaviour
{
    public MeshRenderer[] cartMesh;

    private List<CartItemType> cartItemTypes = new List<CartItemType>();

    private void Start()
    {
        foreach (var cartObject in cartMesh)
        {
            var cartItemType = cartObject.gameObject.GetComponent<CartItemType>();
            cartItemTypes.Add(cartItemType);
        }
    }

    public void SetHighlight(bool enabled)
    {
        for (int index = 0; index < cartMesh.Length; ++index)
        {
            if (cartMesh[index].gameObject.activeSelf &&
                cartItemTypes[index].itemType == CartItemType.ItemType.Regular)
            {
                if (enabled)
                {
                    cartMesh[index].material.color = Color.yellow;
                }
                else
                {
                    cartMesh[index].material.color = Color.red;
                }
            }
        }
    }
}