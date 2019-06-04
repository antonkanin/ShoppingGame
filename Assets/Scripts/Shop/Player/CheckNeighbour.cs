using UnityEngine;

public class CheckNeighbour : MonoBehaviour
{
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
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, towerRaius, towersMask);

        return hitColliders.Length > 0;
    }

    bool IsAvailableSpaceNearby()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, emptySlotRadius, emptyItemsMask);

        // Debug.Log(hitColliders.Length);

        return hitColliders.Length > 0;
    }
}