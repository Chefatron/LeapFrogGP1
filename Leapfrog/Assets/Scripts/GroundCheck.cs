using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private bool Grounded;

    private void OnCollisionStay2D(Collision2D collision)
    {
        
        EvaluateCollision(collision);
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Grounded = false;
    }

    private void EvaluateCollision(Collision2D collision)
    {
        for (int i = 0; i < collision.contactCount; i++)
        {
            Vector2 normal = collision.GetContact(i).normal;
            Grounded |= Mathf.Abs(normal.y) >= 0.9f;
        }
    }

    public bool GetGrounded()
    {
        return Grounded;
    }
}
