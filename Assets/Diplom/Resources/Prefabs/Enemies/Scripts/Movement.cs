using UnityEngine;

public class Movement : MonoBehaviour
{
    [field: SerializeField, HideInInspector]
    public Rigidbody _enemyMovement { get; set; }
    [field: SerializeField, HideInInspector]
    public float _speed { get; set; }
    [field: SerializeField, HideInInspector]
    public float _speedDirection { get; set; }
    [field: SerializeField, HideInInspector]
    public bool _isBoss { get; set; }
    [field: SerializeField, HideInInspector]    
    public bool _isMove { get; set; }

    private void Start() => _enemyMovement = gameObject.GetComponent<Rigidbody>();

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Platform")
        {
            Rotation(collision);
        }
            
    }

    private void OnCollisionStay(Collision collision)
    {

        if (collision.gameObject.tag == "Platform")
        {
            
            switch (_isBoss)
            {
                case false:
                    MovementObj();
                    break;
                case true:
                    BossMovement();
                    break;
            }
            Rotation(collision);
        }
    }

    private void Rotation(Collision collision)
    {

        if (transform.rotation != collision.gameObject.transform.rotation)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, collision.gameObject.transform.rotation, Time.deltaTime * _speedDirection);
        }
    }

    private void BossMovement()
    {
        Debug.Log(_isMove);
        if (_isMove) 
        {
            MovementObj();
        }
    }

    private void MovementObj() => _enemyMovement.MovePosition(transform.position + transform.forward * _speed * Time.deltaTime);
}
