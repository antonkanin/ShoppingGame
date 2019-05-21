using System;
using UnityEngine;

public class ShoppingItem : MonoBehaviour
{
    public float distanceToPlayer = 1.0f;

    public Transform playerPosition;

    private void Start()
    {
        var player = GameObject.Find("Player");

        if (player == null)
        {
            throw new NullReferenceException("Cannot find Player object on the scene");
        }

        playerPosition = player.transform;
    }

    void Update()
    {
        if (Vector3.Distance(playerPosition.position, transform.position) <= distanceToPlayer)
        {
            SpotLightOn();  
        }
    }

    void SpotLightOn()
    {
        
        
    }
}