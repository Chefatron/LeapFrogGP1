using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DeathDetection : MonoBehaviour
{
    public PlayerDeath DeathScript;
    public CameraFollow CameraFollowObject;
    private Jumping PlayerJumping;
    private SpriteRenderer PlayerRenderer;
    public Light2D LightObject;

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
            DeathScript.Die();
            /*
            CameraFollowObject.FollowX = false;
            CameraFollowObject.FollowY = false;
            Destroy(PlayerJumping);
            Destroy(PlayerRenderer);
            if(LightObject != null)
            {
                LightObject.intensity = 0;
            }
            */
        }
    }
}
