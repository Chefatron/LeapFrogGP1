using System.Collections.Generic;
using UnityEngine;

public class WallSpawn : MonoBehaviour
{
    public GameObject WallPrefab;
    public Transform SpawnPoint;
    private bool Spawned = false;
    private GameManager Manager;

    public List<Transform> VerticalPlatformSpawners;
    private PlatformSpawn Spawner;

    void Start()
    {
        Manager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        Spawner = GameObject.Find("PlatformSpawners").GetComponent<PlatformSpawn>();
    }

    public void Spawn()
    {
        if(!Spawned)
        {
            GameObject NewWall = Instantiate(WallPrefab,SpawnPoint.position,SpawnPoint.rotation);
            Manager.AddNewWall(NewWall);
            Spawner.PlatformCalc(NewWall.GetComponent<WallSpawn>());
            Spawned = true;
        }
    }
}
