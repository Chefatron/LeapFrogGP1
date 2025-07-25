using UnityEngine;

public class Spike : MonoBehaviour
{
    private Rigidbody2D OBJrb;
    private Transform OBJtransform;
    private GameObject player;
    private PlayerDeath deathscript;

    void Start()
    {
        OBJrb = GetComponent<Rigidbody2D>();
        OBJtransform = GetComponent<Transform>();
        player = GameObject.FindWithTag("Player");
        deathscript = player.GetComponent<PlayerDeath>();
        
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

