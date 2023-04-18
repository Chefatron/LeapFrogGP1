using UnityEngine;

public class FireFly : MonoBehaviour
{
    private new LightSize light;
    public float LightGain;

    // Start is called before the first frame update
    void Start()
    {
        light = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<LightSize>();
    }

    public void OnPickUp()
    {
        light.IncreaseLightRadius(LightGain);
    }
}
