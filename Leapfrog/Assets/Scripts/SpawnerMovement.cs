using UnityEngine;

public class SpawnerMovement : MonoBehaviour
{
    private Transform Player;
    private float HighestPoint;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.transform.position.y > HighestPoint)
        {
            transform.position = new Vector3(transform.position.x, Player.position.y, transform.position.z);
            HighestPoint = Player.transform.position.y;
        }
    }
}
