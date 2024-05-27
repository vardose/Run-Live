using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lifeManager : MonoBehaviour
{
    public static bool shield;
    public GameObject deathScreen;
    
    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        shield = true;
        
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    { 
        if (Collectible.score >= 5 && shield == false)
        {
            shield = true;
            Collectible.score -= 5;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Respawn")
        {
            rb.position = new Vector3(0, 2, 0);
        }
        else if (other.transform.tag == "damage")
        {
            if (shield)
            {
                shield = false;
            }
            else
            {
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                deathScreen.SetActive(true);
            }
        }
    }
}
