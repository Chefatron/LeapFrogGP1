using UnityEngine;

public class PlatformBreak : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0)
            {
                Destroy(gameObject, 1);
            }
        }
    }
}
