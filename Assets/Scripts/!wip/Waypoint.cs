using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField]
    private float debugRadius = 1.0f;

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, debugRadius);
    }
}
