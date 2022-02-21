using System;
using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    public static event Action<float> isPlayerHealthAction;
    private void OnCollisionEnter(Collision collider) => DestroyGameObj(collider);

    private void DestroyGameObj(Collision collider) 
    {
        isPlayerHealthAction?.Invoke(1f);
        Destroy(collider.gameObject);
    }
}

