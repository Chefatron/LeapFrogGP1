using UnityEngine;

public class DestroyOldObjects : MonoBehaviour
{
    [Min(20f)]public float DestroyDist = 40f;
    private Transform Player;

    void Start()
    {
        Player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if(Mathf.Abs(transform.position.y - Player.position.y) > DestroyDist && transform.position.y < Player.position.y)
        {
            Destroy(this.gameObject);
        }
    }
}
