using UnityEngine;

[RequireComponent(typeof(CartHighlight))]
public class CheckNeighbour : MonoBehaviour
{
    public float itemsRadius = 2.0f;
    public LayerMask mask;

    public CartHighlight cartHighlight;

    // Update is called once per frame
    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, itemsRadius, mask);

        cartHighlight.SetHighlight(hitColliders.Length > 0);
    }
}