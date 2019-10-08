using System;
using UnityEngine;

/// <summary>
/// Source: https://gist.github.com/gunderson/d7f096bd07874f31671306318019d996
/// Modified.
/// </summary>
public class CameraController : MonoBehaviour
{
    public float mainSpeed = 100.0f; //regular speed
    public float camSens = 0.25f; //How sensitive it with mouse

    private Vector3
        lastMouse = new Vector3(255, 255, 255); //kind of in the middle of the screen, rather than at the top (play)

    private float totalRun = 1.0f;
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
        lastMouse = Input.mousePosition;
    }

    private void Update()
    {
        lastMouse = Input.mousePosition - lastMouse;
        lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0);
        
        Transform currentTransform = transform;
        Vector3 eulerAngles = currentTransform.eulerAngles;
        
        lastMouse = new Vector3(eulerAngles.x + lastMouse.x, eulerAngles.y + lastMouse.y, 0);
        eulerAngles = lastMouse;
        currentTransform.eulerAngles = eulerAngles;
        lastMouse = Input.mousePosition;
        //Mouse  camera angle done.  

        //Keyboard commands
        Vector3 p = GetBaseInput();
        
        totalRun = Mathf.Clamp(totalRun * 0.5f, 1f, 1000f);
        
        p *= mainSpeed;
        p *= Time.deltaTime;

        transform.Translate(p);

        Vector3 currentTransformPosition = currentTransform.position;
        
        currentTransformPosition.y = startPosition.y;

        transform.position = currentTransformPosition;
    }

    private static Vector3 GetBaseInput()
    {
        //returns the basic values, if it's 0 than it's not active.
        Vector3 pVelocity = new Vector3();
        
        if (Input.GetKey(KeyCode.W))
        {
            pVelocity += new Vector3(0, 0, 1);
        }

        if (Input.GetKey(KeyCode.S))
        {
            pVelocity += new Vector3(0, 0, -1);
        }

        if (Input.GetKey(KeyCode.A))
        {
            pVelocity += new Vector3(-1, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            pVelocity += new Vector3(1, 0, 0);
        }

        return pVelocity;
    }
}