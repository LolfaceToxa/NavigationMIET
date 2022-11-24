using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField]
    private float sensitivityX = 1.5F;

    [SerializeField]
    private float sensitivityY = 0.5F;

    [SerializeField]
    private float zoomSensitivity = 0.1F;

    [SerializeField]
    private float slideSensitivityX = 0.05F;
    [SerializeField]
    private float slideSensitivityY = 0.05F;




    Vector2 prevTouchPos1 = new Vector2();
    Vector2 prevTouchPos2 = new Vector2();

    public const float minimumX = -360F;
    public const float maximumX = 360F;
    public const float minimumY = -60F;
    public const float maximumY = 60F;
    float rotationX = 0F;
    float rotationY = 0F;

    Quaternion originalRotation;


    void Start()
    {

        originalRotation = this.gameObject.transform.rotation;
    }

    //public GameObject Camera => this.gameObject;

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
                    var diff1 = Input.GetTouch(0).deltaPosition;
                    var diff2 = Input.GetTouch(1).deltaPosition;
                    if (Vector2.Dot(diff1, diff2) > 0)
                    {
                        this.Slide(Input.GetTouch(0), Input.GetTouch(1));
                    }
                    else
                    {
                        this.Zoom(Input.GetTouch(0), Input.GetTouch(1));
                    }
                    break;
            }
        }

    }

    public void Zoom(Touch touch1, Touch touch2)
    {
        var diff1 = touch1.deltaPosition;
        var diff2 = touch2.deltaPosition;
        bool isIncreased = (Vector2.Distance(touch1.position, touch2.position) > Vector2.Distance(touch1.position - diff1, touch2.position - diff2));
        int direction = (isIncreased) ? 1 : -1;
        var zoom = -Vector2.Dot(diff1, diff2);

        zoom = Mathf.Clamp(zoom, 0f, 100f);
        this.gameObject.transform.position += direction * zoom * this.gameObject.transform.forward * zoomSensitivity;




    }

    public void Slide(Touch touch1, Touch touch2)
    {
        var diff1 = touch1.deltaPosition;
        var diff2 = touch2.deltaPosition;
        var avg = -(diff1 + diff2) / 2;
        this.gameObject.transform.position += Quaternion.AngleAxis(this.gameObject.transform.rotation.eulerAngles.y, Vector3.up) * new Vector3(avg.x * slideSensitivityX, 0, avg.y * slideSensitivityY);


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
