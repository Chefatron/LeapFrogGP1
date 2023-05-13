using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(GroundCheck))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private GroundCheck ground;
    public float MoveSpeed;
    private Vector2 DesiredMoveSpeed;
    private bool Grounded;
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
=======

>>>>>>> Stashed changes
    private GameObject FollowObject;
    public AudioSource audioPlayer;

    private Animator anim;
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======

>>>>>>> Stashed changes

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ground = GetComponent<GroundCheck>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Grounded = ground.GetGrounded();
        if(!Grounded)
        {
            if(Input.GetAxisRaw("Horizontal") > 0)
            {
                DesiredMoveSpeed = new Vector2(MoveSpeed, rb.velocity.y);
                rb.velocity = DesiredMoveSpeed;

                anim.SetBool("isMoving", true);
            }
            else if (Input.GetAxisRaw("Horizontal") < 0)
            {
                DesiredMoveSpeed = new Vector2(-MoveSpeed, rb.velocity.y);
                rb.velocity = DesiredMoveSpeed;

                anim.SetBool("isMoving", true);
            }
            else
            {
                anim.SetBool("isMoving", false);
            }
        }
    }
}
