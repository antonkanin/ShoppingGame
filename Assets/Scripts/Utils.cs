using System;
using UnityEngine;

public class Utils : MonoBehaviour
{
    public static GameObject FindPlayer()
    {
        return FindSceneObject("Player");
    }

    public static GameObject FindInputController()
    {
        return FindSceneObject("InputController");
    }

    static GameObject FindSceneObject(string objectName)
    {
        var sceneObject = GameObject.Find(objectName);

        if (sceneObject == null)
        {
            throw new NullReferenceException("Cannot find " + objectName + " object on the scene");
        }

        return sceneObject;
    }
}