using UnityEngine;

public class TextRotation : MonoBehaviour
{
    private Transform playerTransform;

    private void Start()
    {
        playerTransform = Utils.FindPlayer().transform;
    }

    void Update()
    {
        transform.LookAt(playerTransform);
    }
}