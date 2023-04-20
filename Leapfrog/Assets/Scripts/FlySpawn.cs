using UnityEngine;

public class FlySpawn : MonoBehaviour
{
    public float SpawnChance;
    public GameObject Fly;
    private Transform SpawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPoint = transform.GetChild(0).transform;
        int RandomNum = Mathf.RoundToInt(Random.Range(1, SpawnChance));
        if (RandomNum == 1 && Fly != null)
        {
            Instantiate(Fly, SpawnPoint.position, SpawnPoint.rotation);
        }
    }
}
