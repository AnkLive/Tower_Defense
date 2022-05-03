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
       if (Input.touchCount > 0) 
 {
        Touch touch = Input.GetTouch(0); // get first touch since touch count is greater than zero
     
        if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) 
        {
            // get the touch position from the screen touch to world point
            Vector2 touchedPos = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y));
            // lerp and set the position of the current object to that of the touch, but smoothly over time.
            transform.position = Vector3.Lerp(transform.position, touchedPos, Time.deltaTime);
        }
 }


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
