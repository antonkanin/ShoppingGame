using System;
using System.Collections;
using UnityEngine;

public class HitReaction : MonoBehaviour
{
    public float slowDownTime;

    private InputController input;

    private void Start()
    {
        input = Utils.FindInputController().GetComponent<InputController>();
    }

    void OnCollisionEnter(Collision other)
    {
        const string BULLET_TAG = "Bullet";

        if (other.gameObject.CompareTag(BULLET_TAG))
        {
            StartCoroutine("SlowDown");
        }
    }

    IEnumerator SlowDown()
    {
        var originalSpeed = input.playerSpeed;
        input.playerSpeed = 0;

        yield return new WaitForSeconds(slowDownTime);

        input.playerSpeed = originalSpeed;
    }
}