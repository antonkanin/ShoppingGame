using UnityEngine;
using UnityEngine.EventSystems;

public class ItemPickableFromShelf : MonoBehaviour
{
    public GameEvent pickupEvent;

    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            pickupEvent.Raise();
            
            MakeTransparent();
        }
    }

    void MakeTransparent()
    {
        var color = GetComponent<MeshRenderer>().material.color;

        GetComponent<MeshRenderer>().material.color = 
            new Color(color.r, color.g, color.b, 0.01f);
    }
}