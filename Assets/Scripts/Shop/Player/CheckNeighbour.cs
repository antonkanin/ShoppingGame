using UnityEngine;

public class CheckNeighbour : MonoBehaviour
{
    public Transform playerCenter;

    public float emptySlotRadius = 2.0f;

    public float towerRaius = 10.0f;

    public LayerMask emptyItemsMask;

    public LayerMask towersMask;

    public GameEvent AvailableShelfSpaceEvent;

    public GameEvent noAvailableShelfSpaceEvent;

    private bool isShelfSpaceAvailable = false;

    void Update()
    {
        if (IsAvailableSpaceNearby())
        {
            if (!isShelfSpaceAvailable)
            {
                Debug.Log("AvailableShelfSpaceEvent.Raise();");
                isShelfSpaceAvailable = true;
                AvailableShelfSpaceEvent.Raise();
            }
        }
        else if (isShelfSpaceAvailable)
        {
            isShelfSpaceAvailable = false;
            noAvailableShelfSpaceEvent.Raise();
            Debug.Log("noAvailableShelfSpaceEvent.Raise();");
        }
    }

    public bool IsTowerNearBy()
    {
        Collider[] hitColliders = 
            Physics.OverlapSphere(playerCenter.position, towerRaius, towersMask);

        return hitColliders.Length > 0;
    }

    bool IsAvailableSpaceNearby()
    {
        Collider[] hitColliders = 
            Physics.OverlapSphere(playerCenter.position, emptySlotRadius, emptyItemsMask);

        return hitColliders.Length > 0;
    }

    public bool TryReturnItem(EShoppingItemType itemType)
    {
        Collider[] hitColliders = 
            Physics.OverlapSphere(playerCenter.position, emptySlotRadius, emptyItemsMask);

        if (hitColliders.Length <= 0)
        {
            return false;
        }

        var parentObject = hitColliders[0].gameObject.transform.parent.gameObject;
        parentObject.GetComponent<ShelfItem>().SetItemType(itemType);

        return true;
    }
}