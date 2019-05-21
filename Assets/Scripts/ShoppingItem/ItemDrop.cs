using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        rb.isKinematic = false;
    }
}
