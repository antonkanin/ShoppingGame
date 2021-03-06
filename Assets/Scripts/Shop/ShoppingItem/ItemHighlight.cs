﻿using System;
using UnityEngine;

public class ItemHighlight : MonoBehaviour
{
    public float minDistanceToPlayer = 1.0f;

    public GameObject highlightFX;

    private Transform playerPosition;

    private void Start()
    {
        var player = Utils.FindPlayer();

        playerPosition = player.transform;
        
        highlightFX.SetActive(false);
    }

    void Update()
    {
        var distanceToPlayer = Vector3.Distance(playerPosition.position, transform.position);
        
        if (distanceToPlayer <= minDistanceToPlayer)
        {
            if (!highlightFX.activeSelf)
            {
                highlightFX.SetActive(true);
            }
        }
        else
        {
            if (highlightFX.activeSelf)
            {
                highlightFX.SetActive(false);
            }
        }
    }
}