using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private CameraFollow CameraFollowObject;
    private GameObject Player;

    private void Start()
    {
        CameraFollowObject = GameObject.Find("CameraFollowObject").GetComponent<CameraFollow>();
    }

    public void Die()
    {
        Debug.Log("Dead");
        CameraFollowObject.FollowX = false;
        CameraFollowObject.FollowY = false;
        Destroy(GetComponent<Jumping>());
        Destroy(GetComponent<SpriteRenderer>());
        if (transform.Find("PlayerLight") != null)
        {
            transform.Find("PlayerLight").GetComponent<Light2D>().intensity = 0;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
