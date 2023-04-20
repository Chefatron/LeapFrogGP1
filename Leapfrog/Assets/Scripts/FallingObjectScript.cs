using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FallingObjectScript : MonoBehaviour
{
    private int DropPositon;
    private int DropDecide;
    private bool DropActive;
    [Min(2)]public int DropChance;
    private Rigidbody2D OBJrb;
    private Transform OBJtransform;
    private Transform playerTransform;
    public PlayerDeath deathscript; 

    // Start is called before the first frame update
    void Start()
    {
        OBJrb = GetComponent<Rigidbody2D>();
        OBJtransform = GetComponent<Transform>();
       //Finds player in the scene, chooses the first player it runs into
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();


    }

    // Update is called once per frame
    void Update()
    {
        //Obj follows the player on the x and y axis 
        if (DropActive == false)
        {
            OBJtransform.position = new Vector2(playerTransform.position.x, (playerTransform.position.y + 15));
            DropDecide = Random.Range(1, DropChance);
            //random number generator
            if (DropDecide == 1)
            {
                OBJrb.velocity = new Vector2(0, -15);
                DropActive = true;
            }
        }
        else if (DropActive == true)
        {
            if (OBJtransform.position.y< (playerTransform.position.y- 15)) 
            {
                OBJtransform.position = new Vector2(playerTransform.position.x, (playerTransform.position.y + 15));
                DropActive = false;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            deathscript.Die();
        }
        
        
    }
}


//If collision, player die, use death thing 

