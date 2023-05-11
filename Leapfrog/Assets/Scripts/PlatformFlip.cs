using UnityEngine;

public class PlatformFlip : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(transform.position.x > 0)
        {
            transform.localScale = new Vector3(-1f * Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (transform.position.x < 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }
}
