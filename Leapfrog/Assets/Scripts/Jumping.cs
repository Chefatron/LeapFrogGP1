using System.Collections;
using UnityEngine;

[RequireComponent(typeof(GroundCheck),typeof(Rigidbody2D))]
public class Jumping : MonoBehaviour
{
    private Rigidbody2D rb;
    private GroundCheck ground;
    private bool Grounded;
    private Vector2 DesiredVelocity;

    public float JumpForce = 10f;
    public float JumpDelay = 0.2f;

    private Animator anim;

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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (rb.velocity.y <= 0)
        {
            StartCoroutine(Jump(JumpForce));
        }
    }

    public IEnumerator Jump(float _JumpForce)
    {
        yield return new WaitForSeconds(JumpDelay);

        if(Grounded)
        {
            DesiredVelocity = new Vector2(rb.velocity.x, _JumpForce);
            rb.velocity = DesiredVelocity;
        }
    }
}
