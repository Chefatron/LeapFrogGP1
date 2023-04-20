using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawn : MonoBehaviour
{
    private GameManager Manager;
    public List<Transform> HorizontalPlatformSpawners;
    public List<GameObject> Platforms;
    public List<GameObject> SidePlatforms;

    void Start()
    {
        Manager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    public void PlatformCalc(WallSpawn _Wall)
    {
        for (int i = 0; i < _Wall.VerticalPlatformSpawners.Count; i++)
        {
            int RandomPos = Random.Range(0,HorizontalPlatformSpawners.Count);
            
            if(RandomPos == 0 || RandomPos == HorizontalPlatformSpawners.Count - 1)
            {
                int RandomPlatform = Random.Range(0, SidePlatforms.Count);
                Spawn(SidePlatforms[RandomPlatform], HorizontalPlatformSpawners[RandomPos].position.x, _Wall.VerticalPlatformSpawners[i].position.y);
            }
            else
            {
                int RandomPlatform = Random.Range(0, Platforms.Count);
                Spawn(Platforms[RandomPlatform], HorizontalPlatformSpawners[RandomPos].position.x, _Wall.VerticalPlatformSpawners[i].position.y);
            }
        }
    }


    public void Spawn(GameObject _Platform, float _PosX, float _PosY)
    {
        Vector3 SpawnPos = new Vector3(_PosX, _PosY, 0);
        Instantiate(_Platform, SpawnPos, Quaternion.identity);
    }
}
