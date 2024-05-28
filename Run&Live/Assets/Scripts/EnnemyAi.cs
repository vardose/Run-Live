using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyAi : MonoBehaviour
{
    public GameObject player;
    
    private float timer = 2f;
    private float bulletTime;

    public GameObject ennemyBullet;
    public Transform spawnPoint;

    private void Update()
    {
        gameObject.transform.LookAt(player.transform);
        ShootAtPlayer();
    }

    void ShootAtPlayer()
    {
        bulletTime -= Time.deltaTime;
        if (bulletTime > 0) return;

        bulletTime = timer;

        GameObject bulletObj = Instantiate(ennemyBullet, spawnPoint.transform.position, Quaternion.identity) as GameObject;
        Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();
        bulletRig.AddForce( transform.forward * 15f, ForceMode.Impulse);
        
        Destroy(bulletObj, 5f);
    }
}
