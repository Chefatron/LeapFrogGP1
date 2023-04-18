using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(Light2D))]
public class LightSize : MonoBehaviour
{
    private new Light2D light;
    public float StartRadius = 8;
    public float MaxRadius;
    [Min(0)]public float MinRadius;

    public float SizeDecreaseRate;

    private float Radius;


    // Start is called before the first frame update
    void Start()
    {
        light = GetComponent<Light2D>();
        Radius = StartRadius;
    }

    // Update is called once per frame
    void Update()
    {
        if(Radius > MinRadius)
        {
            Radius -= Time.deltaTime * SizeDecreaseRate;
        }
        else if(Radius < MinRadius)
        {
            Radius = MinRadius;
        }
        light.pointLightOuterRadius = Radius;

        if(Radius > MaxRadius)
        {
            Radius = MaxRadius;
        }
    }

    public void IncreaseLightRadius(float _AdditionalRadius)
    {
        Radius += _AdditionalRadius;
    }
}
