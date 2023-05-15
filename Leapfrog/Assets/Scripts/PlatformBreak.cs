using UnityEngine;

public class PlatformBreak : MonoBehaviour
{
    public GameObject ParticleSystem;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y <= 0)
            {
                Instantiate(ParticleSystem, transform.position, Quaternion.identity);   
                Destroy(gameObject, 1);
            }
        }
    }
}
