using Unity.VisualScripting;
using UnityEngine;

public class DeathDetection : MonoBehaviour
{
    public CameraFollow CameraFollowObject;
    private Jumping PlayerJumping;
    private SpriteRenderer PlayerRenderer;

    private void Start()
    {
        PlayerJumping = GameObject.FindGameObjectWithTag("Player").GetComponent<Jumping>();
        PlayerRenderer = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Dead");
            CameraFollowObject.FollowX = false;
            CameraFollowObject.FollowY = false;
            Destroy(PlayerJumping);
            Destroy(PlayerRenderer);
        }
    }
}
