using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> Walls = new List<GameObject>();
    private Transform Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.position.y > Walls[Walls.Count - 1].transform.position.y)
        {
            Walls[Walls.Count - 1].GetComponent<WallSpawn>().Spawn();
        }
    }

    public void AddNewWall(GameObject _NewWall)
    {
        Walls.Add(_NewWall);
    }

    public void removeLowestWall()
    {
        Walls.RemoveAt(0);
    }
}
