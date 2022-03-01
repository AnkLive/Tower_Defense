using UnityEngine;

public class NormalMovement : Movement
{
    [SerializeField] private float speed;
    [SerializeField] private float speedDirection;
    public override float _speed { get => speed; set => speed = value; }
    public override float _speedDirection { get => speedDirection; set => speedDirection = value; }

    public void Start() => base.GetComponentData();

    private void Update() {
        Debug.Log(_speedDirection);
    }

    public void OnCollisionEnter(Collision collision) => base.CheckCollision(collision.gameObject);

    public void OnCollisionStay(Collision collision)
    {

        if (base.CheckCollision(collision.gameObject))
        {
            base.MovementObj();
        }
    }
}
