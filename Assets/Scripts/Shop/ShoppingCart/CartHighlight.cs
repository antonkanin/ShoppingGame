using UnityEngine;

public class CartHighlight : MonoBehaviour
{
    public MeshRenderer[] cartMesh;

    // TODO we need to optimize this code
    public void SetHighlight(bool enabled)
    {
        foreach (var cartItem in cartMesh)
        {
            if (cartItem.gameObject.activeSelf)
            {
                if (enabled)
                {
                    cartItem.material.color = Color.yellow;
                }
                else
                {
                    cartItem.material.color = Color.red;
                }
            }
        }
    }
}