using System;
using System.Collections;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform shootFromPos;

    public float distanceToPlayer;

    public GameObject bulletPrefab;

    public float shootingInterval;

    public float shootingForce;

    public float bulletLifeTime;

    private GameObject player;

    private GameObject bulletsParent;

    private float lastShotTime;

    private bool isShotFired = false;

    private Vector3 debug_bulletforce_direction;

    void Start()
    {
        player = Utils.FindPlayer(); 

        bulletsParent = GameObject.Find("Bullets");

        if (bulletsParent == null)
        {
            throw new NullReferenceException("Bullets game object not found");
        }
    }

    void Update()
    {
        TryShootAtPlayer();
    }

    void TryShootAtPlayer()
    {
        var distance = (player.transform.position - shootFromPos.position).magnitude;

        if (distance <= distanceToPlayer && !isShotFired)
        {
            StartCoroutine("Shoot");
        }
    }

    IEnumerator Shoot()
    {
        isShotFired = true;
        var bullet = Instantiate(bulletPrefab, shootFromPos.position, Quaternion.identity);
        bullet.transform.parent = bulletsParent.transform;

        bullet.transform.LookAt(player.transform.position);

        bullet.GetComponent<Rigidbody>().AddForce(shootingForce * bullet.transform.forward,
            ForceMode.Impulse);
        
        Destroy(bullet, bulletLifeTime);

        yield return new WaitForSeconds(shootingInterval);

        isShotFired = false;
    }
}