using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    public Rigidbody _enemyMovement { get; set; }
    public abstract float _speed { get; set; }
    public abstract float _speedDirection { get; set; }

    public bool CheckCollision(GameObject obj) => obj.tag == "Platform" ? true : false;

    public void Rotation(GameObject obj)
    {

        if (transform.rotation != obj.transform.rotation)
        {
            transform.rotation = Quaternion.Slerp(
                transform.rotation, obj.transform.rotation, 
                Time.deltaTime * _speedDirection
                );
        }
    }

    public void MovementObj() => _enemyMovement.MovePosition(transform.position + transform.forward * _speed * Time.deltaTime);

    public void GetComponentData() => _enemyMovement = gameObject.GetComponent<Rigidbody>();
}
