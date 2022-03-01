using UnityEngine;

public class BossMovement : Movement
{
    [SerializeField] private float speed;
    [SerializeField] private float speedDirection;
    public override float _speed { get => speed; set => speed = value; }
    public override float _speedDirection { get => speedDirection; set => speedDirection = value; }
    public bool _isMove { get; set; }

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

            if (_isMove)
            {
                base.MovementObj();
            }
        }
    }
}
