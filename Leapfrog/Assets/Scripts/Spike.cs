using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private Rigidbody2D OBJrb;
    private Transform OBJtransform;
    private Transform playerTransform;
    public PlayerDeath deathscript;

    void Start()
    {
        OBJrb = GetComponent<Rigidbody2D>();
        OBJtransform = GetComponent<Transform>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Hit");
            deathscript.Die();
        }
    }
       
}

