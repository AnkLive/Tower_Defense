using UnityEngine;

public class Destroy : MonoBehaviour
{
    private void OnCollisionEnter(Collision collider)
    {
        DestroyGameObj(collider);
    }

    private void DestroyGameObj(Collision collider)
    {
        Destroy(collider.gameObject);
    }
}
