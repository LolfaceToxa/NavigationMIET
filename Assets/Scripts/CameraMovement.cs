using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    public const float sensitivityX = 10F;

    [SerializeField]
    public const float sensitivityY = 10F;

    Vector2 prevTouchPos1 = new Vector2();
    Vector2 prevTouchPos2 = new Vector2();

    public const float minimumX = -360F;
    public const float maximumX = 360F;
    public const float minimumY = -60F;
    public const float maximumY = 60F;
    float rotationX = 0F;
    float rotationY = 0F;

    Quaternion originalRotation;

    [SerializeField]
    Camera camera;

    void Start()
    {
        Debug.Assert(camera != null);
        originalRotation = this.gameObject.transform.rotation;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            var touches = Input.touchCount;

            switch (touches)
            {
                case 1:
                    this.Rotate(Input.GetTouch(0));
                    break;
                case 2:
                    this.Zoom(Input.GetTouch(0), Input.GetTouch(1));
                    break;
            }
        }

    }

    public void Zoom(Touch touch1, Touch touch2)
    {

        //Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        //float zoomDistance = zoomSpeed * Input.GetAxis("Vertical") * Time.deltaTime;
        //GetComponent<Camera>().transform.Translate(ray.direction * zoomDistance, Space.World);

    }

    public void Rotate(Touch touch)
    {
        var diff = touch.deltaPosition;
        rotationX += diff.x * sensitivityX * Time.deltaTime;
        rotationY += diff.y * sensitivityY * Time.deltaTime;
        rotationX = ClampAngle(rotationX, minimumX, maximumX);
        rotationY = ClampAngle(rotationY, minimumY, maximumY);
        Quaternion xQuaternion = Quaternion.AngleAxis(rotationX, Vector3.up);
        Quaternion yQuaternion = Quaternion.AngleAxis(rotationY, -Vector3.right);


        this.gameObject.transform.rotation = originalRotation * xQuaternion * yQuaternion;
    }


    public static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360F)
            angle += 360F;
        else if (angle > 360F)
            angle -= 360F;
        return Mathf.Clamp(angle, min, max);
    }
}
