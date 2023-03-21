using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(GroundCheck))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private GroundCheck ground;
    public float MoveSpeed;
    private Vector2 DesiredMoveSpeed;
    private bool Grounded;

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
}
