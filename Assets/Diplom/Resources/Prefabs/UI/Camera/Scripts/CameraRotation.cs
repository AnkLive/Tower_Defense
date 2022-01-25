using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [field: SerializeField]
    public GameObject _obj { get; private set; }
    [field: SerializeField]
    public float _sensitivity { get; private set; }
    private float _horizontalAxisRotation;
    public float yaw = 0.0f;

    void Update()
    {
        _horizontalAxisRotation += Input.GetAxis("Mouse X") * _sensitivity;
        Rotation();
    }

    private void Rotation()
    {
        if (Input.GetMouseButton(0))
        {
            transform.RotateAround(_obj.transform.position, new Vector3(0f, _horizontalAxisRotation, 0.0f),
                _sensitivity * Time.deltaTime);
        }
    }
}
