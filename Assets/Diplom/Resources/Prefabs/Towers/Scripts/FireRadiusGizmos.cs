using UnityEngine;

public class FireRadiusGizmos : MonoBehaviour
{
    [field: SerializeField, HideInInspector]
    public SphereCollider _sphereCollider {get; set; }
    [field: SerializeField, HideInInspector]
    public float _radius {get; set; }
    
    void Awake()
    {
        _sphereCollider = gameObject.GetComponent<SphereCollider>();
        _radius = _sphereCollider.radius;
    }

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
