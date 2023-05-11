using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject ObjectToFollow;
    private Transform FollowTransform;
    private float HighestPoint;
    private Transform Player;

    public bool FollowX;
    public bool FollowY;
    private Vector2 FollowTarget = new Vector2(0,0);

    // Start is called before the first frame update
    void Start()
    {
        FollowTransform = ObjectToFollow.transform;
        Player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(FollowX)
        {
            FollowTarget = new Vector2(FollowTransform.position.x,FollowTarget.y);
        }
        if(FollowY && Player.transform.position.y > HighestPoint)
        {
            FollowTarget = new Vector2(FollowTarget.x, FollowTransform.position.y);
            HighestPoint = Player.transform.position.y;
        }
        transform.position = FollowTarget;
    }
}
