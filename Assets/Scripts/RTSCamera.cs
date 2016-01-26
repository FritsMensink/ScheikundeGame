using UnityEngine;
using System.Collections;

public class RTSCamera : MonoBehaviour
{
    public float ScrollSpeed = 15;
    public float ScrollEdge = 0.01f;

    public float PanSpeed = 10;

    private Vector2 ZoomRange = new Vector2(0, 8);
    public float CurrentZoom = 0;
    public float ZoomZpeed = 1;
    public float ZoomRotation = 1;

    private Vector3 InitPos;
    private Vector3 InitRotation;

    public float LeftEdge = -6;
    public float RightEdge = 36;
    public float TopEdge = 4;
    public float BottomEdge = -20;

    void Start()
    {
        InitPos = transform.position;
        InitRotation = transform.eulerAngles;
    }

    void Update()
    {
        if ((Input.GetKey("d") || Input.mousePosition.x >= Screen.width * (1 - ScrollEdge)) && transform.position.x < RightEdge)
        {
            transform.Translate(Vector3.right * Time.deltaTime * ScrollSpeed, Space.World);
        }
        else if ((Input.GetKey("a") || Input.mousePosition.x <= Screen.width * ScrollEdge) && transform.position.x > LeftEdge)
        {
            transform.Translate(Vector3.right * Time.deltaTime * -ScrollSpeed, Space.World);
        }

        if ((Input.GetKey("w") || Input.mousePosition.y >= Screen.height * (1 - ScrollEdge)) && transform.position.z < TopEdge)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * ScrollSpeed, Space.World);
        }
        else if ((Input.GetKey("s") || Input.mousePosition.y <= Screen.height * ScrollEdge) && transform.position.z > BottomEdge)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * -ScrollSpeed, Space.World);
        }

        //ZOOM IN/OUT

        CurrentZoom -= Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * 1000 * ZoomZpeed;

        CurrentZoom = Mathf.Clamp(CurrentZoom, ZoomRange.x, ZoomRange.y);

        float y = transform.position.y - (transform.position.y - (InitPos.y + CurrentZoom)) * 0.1f;
        Vector3 temp = new Vector3(transform.position.x, y, transform.position.z);
        transform.position = temp;
        float x = transform.eulerAngles.x - (transform.eulerAngles.x - (InitRotation.x + CurrentZoom * ZoomRotation)) * 0.1f;
        temp = new Vector3(x, transform.eulerAngles.y, transform.eulerAngles.z);

    }

}
