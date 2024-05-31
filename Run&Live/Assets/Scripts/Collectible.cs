using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collectible : MonoBehaviour
{
    public static int score;
    public TMP_Text score_text;

    private void Start()
    {
        score = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "collectible")
        {
            ParticleSystem particleSystem = other.gameObject.GetComponent<ParticleSystem>();
            score ++;
            score_text.text = "Score : " + score;

            ParticleSystem.EmissionModule em = particleSystem.emission;
            em.enabled = true;
            particleSystem.Play();
            
            Destroy(other.gameObject.GetComponent<SpriteRenderer>());
            Destroy(other.gameObject, particleSystem.main.duration);
        }
    }
}
