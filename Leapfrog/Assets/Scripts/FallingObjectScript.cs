using UnityEngine;

public class FallingObjectScript : MonoBehaviour
{
    private int DropDecide;
    private bool DropActive;
    private Rigidbody2D OBJrb;
    private Transform OBJtransform;
    private Transform playerTransform;
    [Min(2)]public int DropChance;
    public float FollowDistanceOffset = 15f;
    public float DropSpeed = 15f;
    public PlayerDeath deathscript;
    private GameObject Warning;

    // Start is called before the first frame update
    void Start()
    {
        Warning = transform.GetChild(0).gameObject;
        Warning.SetActive(true);
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
            OBJtransform.position = new Vector2(playerTransform.position.x, (playerTransform.position.y + FollowDistanceOffset));
            DropDecide = Random.Range(1, DropChance);
            Warning.SetActive(false);
            //random number generator
            if (DropDecide == 1)
            {
                Warning.SetActive(true);
                OBJrb.velocity = new Vector2(0, -DropSpeed);
                DropActive = true;
            }
        }
        else if (DropActive == true)
        {
            if (OBJtransform.position.y< (playerTransform.position.y- 15)) 
            {
                OBJtransform.position = new Vector2(playerTransform.position.x, (playerTransform.position.y + FollowDistanceOffset));
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

