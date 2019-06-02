using UnityEngine;

public class CartItemPosition : MonoBehaviour
{
    public CartManager cartManager;

    public void RemoveItem()
    {
        cartManager.SelectItem(transform.GetSiblingIndex());
    }
}