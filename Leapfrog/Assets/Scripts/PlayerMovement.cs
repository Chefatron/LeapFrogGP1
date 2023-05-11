using JetBrains.Annotations;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(GroundCheck))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private GroundCheck ground;
    public float MoveSpeed;
    private Vector2 DesiredMoveSpeed;
    private bool Grounded;
    public AudioSource audioPlayer; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ground = GetComponent<GroundCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        Grounded = ground.GetGrounded();
        if(!Grounded)
        {
            if(Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Vector3 touchpoint = Camera.main.ScreenToWorldPoint(touch.position);
                if(touchpoint.x > 0)
                {
                    DesiredMoveSpeed = new Vector2(MoveSpeed, rb.velocity.y);
                    rb.velocity = DesiredMoveSpeed;
                }
                if (touchpoint.x < 0)
                {
                    DesiredMoveSpeed = new Vector2(-MoveSpeed, rb.velocity.y);
                    rb.velocity = DesiredMoveSpeed;
                }
            }

            if(Input.GetAxisRaw("Horizontal") > 0)
            {
                DesiredMoveSpeed = new Vector2(MoveSpeed, rb.velocity.y);
                rb.velocity = DesiredMoveSpeed;
            }
            else if (Input.GetAxisRaw("Horizontal") < 0)
            {
                DesiredMoveSpeed = new Vector2(-MoveSpeed, rb.velocity.y);
                rb.velocity = DesiredMoveSpeed;
            }
             
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "CollisionTag") {
            audioPlayer.Play();
        }
        
    }
}


