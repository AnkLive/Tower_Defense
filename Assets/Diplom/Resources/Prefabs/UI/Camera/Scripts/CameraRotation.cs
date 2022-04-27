using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [field: SerializeField]
    public GameObject _obj { get; private set; }
    [field: SerializeField]
    public float _sensitivity { get; private set; }

    public float freezeStartX, freezeEndX;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) 
            {
                if (transform.position.z <= freezeStartX && Input.GetTouch(0).deltaPosition.x > 0)
                {
                    Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                    transform.Translate(-touchDeltaPosition.x * _sensitivity * Time.deltaTime, 0f, 0f);
                }
                else if (transform.position.z >= freezeEndX && Input.GetTouch(0).deltaPosition.x < 0) 
                {
                    Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                    transform.Translate(-touchDeltaPosition.x * _sensitivity * Time.deltaTime, 0f, 0f);
                }
            }
        }
        if (transform.position.z > freezeStartX) 
        {
            transform.Translate(freezeStartX * _sensitivity / 2 * Time.deltaTime, 0f, 0f);
        }
        else if (transform.position.z < freezeEndX) 
        {
            transform.Translate(freezeEndX * _sensitivity / 2 * Time.deltaTime, 0f, 0f);
        }
    }
}
