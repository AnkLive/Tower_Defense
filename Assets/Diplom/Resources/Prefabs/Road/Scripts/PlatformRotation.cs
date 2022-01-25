using UnityEngine;

public class PlatformRotation : MonoBehaviour
{
    private enum ROTATION
    {
        Left,
        Right,
        Top,
        Bottom,
    }
    [SerializeField]
    private ROTATION ERotation;

    void Start()
    {
        switch (ERotation)
        {
            case ROTATION.Left:
                gameObject.transform.rotation = Quaternion.Euler(0, 360, 0);
                break;
            case ROTATION.Right:
                gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
                break;
            case ROTATION.Top:
                gameObject.transform.rotation = Quaternion.Euler(0, 90, 0);
                break;
            case ROTATION.Bottom:
                gameObject.transform.rotation = Quaternion.Euler(0, 270, 0);
                break;
        }
    }
}
