using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject ObjectToFollow;
    private Transform FollowTransform;

    public bool FollowX;
    public bool FollowY;
    private Vector2 FollowTarget = new Vector2(0,0);

    // Start is called before the first frame update
    void Start()
    {
        FollowTransform = ObjectToFollow.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(FollowX)
        {
            FollowTarget = new Vector2(FollowTransform.position.x,FollowTarget.y);
        }
        if(FollowY)
        {
            FollowTarget = new Vector2(FollowTarget.x, FollowTransform.position.y);
        }
        transform.position = FollowTarget;
    }
}
