using UnityEngine;

public class CursorCoordsTest : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;

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


    void DragObject_01()
    {
        Vector3 mousePosition =
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.localPosition.z);

        Vector3 objectPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector3 cameraRelative = Camera.main.transform.InverseTransformPoint(objectPosition);

        transform.localPosition =
            new Vector3(cameraRelative.x, cameraRelative.y, transform.localPosition.z);
    }
}