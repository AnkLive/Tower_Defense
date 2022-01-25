using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _enemyMovement;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _speedDirection;
    [SerializeField]
    private bool _isBoss;
    [SerializeField]
    private bool _isMove;
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
        if (_isMove) 
        {
            MovementObj();
        }
    }
    private void MovementObj()
    {
        _enemyMovement.MovePosition(transform.position + transform.forward * _speed * Time.deltaTime);
    }
}
