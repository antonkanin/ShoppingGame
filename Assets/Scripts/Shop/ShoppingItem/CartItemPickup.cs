using UnityEngine;

public class CartItemPickup : MonoBehaviour
{
    private Vector3 mOffset;

    private float mZCoord;

    private Rigidbody rigidBody;

    private float shootingForce = 10.0f;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void OnMouseDown()
    {
        mZCoord = Camera.main.WorldToScreenPoint(
            gameObject.transform.position).z;

        // Store offset = gameobject world pos - mouse world pos
        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();
    }

    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;

        // z coordinate of game object on screen
        mousePoint.z = mZCoord;

        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    void OnMouseDrag()
    {
        transform.position = GetMouseAsWorldPoint() + mOffset;
    }

    private void OnMouseUp()
    {
        rigidBody.isKinematic = false;
        rigidBody.AddForce(transform.forward * shootingForce, ForceMode.Impulse);
    }
}