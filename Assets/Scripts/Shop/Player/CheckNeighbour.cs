using UnityEngine;

public class CheckNeighbour : MonoBehaviour
{
    public float itemsRadius = 2.0f;
    
    public LayerMask emptyItemsMask;
    
    public LayerMask towersMask;

    public CartHighlight cartHighlight;

//    void Update()
//    {
//        Collider[] hitColliders = Physics.OverlapSphere(transform.position, itemsRadius, emptyItemsMask);
//
//        cartHighlight.SetHighlight(hitColliders.Length > 0);
//    }

    public bool IsTowerNearBy()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, itemsRadius, towersMask);

        return hitColliders.Length > 0;
    }
}