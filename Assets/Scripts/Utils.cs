using System;
using UnityEngine;

public class Utils : MonoBehaviour
{
    public static GameObject FindPlayer()
    {
        const string playerObjectName = "Player";

        var player = GameObject.Find(playerObjectName);

        if (player == null)
        {
            throw new NullReferenceException("Cannot find Player object on the scene");
        }

        return player;
    }
}