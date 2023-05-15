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
    public PlayerAnimation Anim;

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
        if (rb.velocity.y == 0)
        {
            Anim.ChangeAnimationState("Player_Idle");
        }
        if (!Grounded)
        {
            if(Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Vector3 touchpoint = Camera.main.ScreenToWorldPoint(touch.position);
                if(rb.velocity.y > 0)
                {
                    Anim.ChangeAnimationState("Player_Jump");
                }
                else if(rb.velocity.y < 0)
                {
                    Anim.ChangeAnimationState("Player_Fall");
                }
                
                if(touchpoint.x > 0)
                {
                    DesiredMoveSpeed = new Vector2(MoveSpeed, rb.velocity.y);
                    rb.velocity = DesiredMoveSpeed;
                    transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                }
                if (touchpoint.x < 0)
                {
                    DesiredMoveSpeed = new Vector2(-MoveSpeed, rb.velocity.y);
                    rb.velocity = DesiredMoveSpeed;
                    transform.localScale = new Vector3(-1f * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                }
            }

            if(Input.GetAxisRaw("Horizontal") > 0)
            {
                DesiredMoveSpeed = new Vector2(MoveSpeed, rb.velocity.y);
                rb.velocity = DesiredMoveSpeed;
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                if (rb.velocity.y > 0)
                {
                    Anim.ChangeAnimationState("Player_Jump");
                }
                else if (rb.velocity.y < 0)
                {
                    Anim.ChangeAnimationState("Player_Fall");
                }
            }
            else if (Input.GetAxisRaw("Horizontal") < 0)
            {
                DesiredMoveSpeed = new Vector2(-MoveSpeed, rb.velocity.y);
                rb.velocity = DesiredMoveSpeed;
                transform.localScale = new Vector3(-1f * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                if (rb.velocity.y > 0)
                {
                    Anim.ChangeAnimationState("Player_Jump");
                }
                else if (rb.velocity.y < 0)
                {
                    Anim.ChangeAnimationState("Player_Fall");
                }
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


