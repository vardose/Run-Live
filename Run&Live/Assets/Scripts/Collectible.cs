using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collectible : MonoBehaviour
{
    public static int score = 0;
    public TMP_Text score_text;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "collectible")
        {
            score ++;
            score_text.text = "Score : " + score;
            Destroy(other.gameObject);
        }
    }
}
