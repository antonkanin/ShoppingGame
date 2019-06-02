using UnityEngine;

public class CartItemPosition : MonoBehaviour
{
    // Start is called before the first frame update
    public CartManager cartManager;

    public void RemoveItem()
    {
        Debug.Log("Button siblings index " + transform.GetSiblingIndex());
        cartManager.RemoveItem(transform.GetSiblingIndex());
    }
}