using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnnemyAi : MonoBehaviour
{
    public GameObject player;
    public LayerMask whatisplayer;
    private float timer = 2f;
    private float bulletTime;
    private float range = 50f;
    public Animator animator;

    private Vector3 direction;

    public GameObject ennemyBullet;
    public Transform spawnPoint;

    private void Update()
    {
        gameObject.transform.LookAt(player.transform);
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        
        bool inRange = Physics.CheckSphere(transform.position, range, whatisplayer);
        if (inRange)
        {
            animator.SetBool("inRange", true);
            ShootAtPlayer();
        }
        else
        {
            animator.SetBool("inRange", false);
        }
    }

    void ShootAtPlayer()
    {
        bulletTime -= Time.deltaTime;
        if (bulletTime > 0) return;

        bulletTime = timer;

        GameObject bulletObj = Instantiate(ennemyBullet, spawnPoint.transform.position, Quaternion.identity) as GameObject;
        Rigidbody bulletRig = bulletObj.GetComponent<Rigidbody>();
        direction = player.transform.position - gameObject.transform.position;
        
        bulletRig.AddForce( direction.normalized * 30f, ForceMode.Impulse);
        
        Destroy(bulletObj, 5f);
    }
}
