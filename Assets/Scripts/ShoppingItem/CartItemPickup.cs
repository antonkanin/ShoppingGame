using UnityEngine;
using UnityEngine.EventSystems;

public class CartItemPickup : MonoBehaviour
{
    private bool isFollowMouse = false;

    void Update()
    {
        var c = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Debug.Log("x: " + Input.mousePosition.x + ", y: "
                  + Input.mousePosition.y + ", z: "
                  + Input.mousePosition.z
                  + "; x: " + c.x
                  + ", y: " + c.y
                  + ", z: " + c.z);

        if (isFollowMouse)
        {
            // Debug.Log("CartItemPickup::Update()");

            var camPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            transform.position =
                new Vector3(camPos.z, 0.0f, camPos.x);
        }
    }

    private void OnMouseDown()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            isFollowMouse = true;
        }
    }
}