using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BirdCollision : MonoBehaviour
{
    public PlayerDeath DeathScript;

    private void Start()
    {
     
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            DeathScript.Die();
        }
    }
}
