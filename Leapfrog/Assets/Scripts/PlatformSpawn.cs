using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawn : MonoBehaviour
{
    private GameManager Manager;
    public List<Transform> HorizontalPlatformSpawners;
    public GameObject BasicPlatform;

    void Start()
    {
        Manager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    public void PlatformCalc(WallSpawn _Wall)
    {
        for (int i = 0; i < _Wall.VerticalPlatformSpawners.Count; i++)
        {
            int RandomNum = Random.Range(0,HorizontalPlatformSpawners.Count);
            Spawn(BasicPlatform, HorizontalPlatformSpawners[RandomNum].position.x, _Wall.VerticalPlatformSpawners[i].position.y);
        }
    }


    public void Spawn(GameObject _Platform, float _PosX, float _PosY)
    {
        Vector3 SpawnPos = new Vector3(_PosX, _PosY, 0);
        Instantiate(_Platform, SpawnPos, Quaternion.identity);
    }
}
