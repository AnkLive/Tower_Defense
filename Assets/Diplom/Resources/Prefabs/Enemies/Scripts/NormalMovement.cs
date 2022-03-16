using UnityEngine;

public class NormalMovement : Movement
{
    [SerializeField] private float speed;
    [SerializeField] private float speedDirection;
    public override float _speed { get => speed; set => speed = value; }
    public override float _speedDirection { get => speedDirection; set => speedDirection = value; }

    public void Start() => base.GetComponentData();

    public void OnCollisionEnter(Collision collision) 
    {

        if (base.CheckCollision(collision.gameObject))
        {
            base.Rotation(collision.gameObject);
        }
    }

    public void OnCollisionStay(Collision collision)
    {

        if (base.CheckCollision(collision.gameObject))
        {
            base.MovementObj();
            base.Rotation(collision.gameObject);
        }
    }
}
