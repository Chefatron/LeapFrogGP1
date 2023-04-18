using UnityEngine;
using UnityEngine.Events;

public class PickupFly : MonoBehaviour
{
    public UnityEvent OnPickup;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            OnPickup.Invoke();
            Destroy(gameObject);
        }
    }
}
