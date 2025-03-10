using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{
    [SerializeField] GameObject mainCam;
    float sensitivityX = .1f, sensitivityY = .1f, camClampMin = 320, camClampMax = 45;
    
    // Start is called before the first frame update
    void Awake()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ClampCameraRotation();
    }

    public void MouseLookX(InputAction.CallbackContext context)
    {
        transform.Rotate(context.ReadValue<float>() * Vector3.up * sensitivityX);
    }

    public void MouseLookY(InputAction.CallbackContext context)
    {

        mainCam.transform.Rotate(context.ReadValue<float>() * Vector3.left * sensitivityY);
    }

    void ClampCameraRotation()
    {
        if (mainCam.transform.localEulerAngles.x > camClampMax && mainCam.transform.localEulerAngles.x < 180)
        {
            mainCam.transform.localEulerAngles = new Vector3(camClampMax, mainCam.transform.localEulerAngles.y, mainCam.transform.localEulerAngles.z);
        }
        else if (mainCam.transform.localEulerAngles.x < camClampMin && mainCam.transform.localEulerAngles.x >= 180)
        {
            mainCam.transform.localEulerAngles = new Vector3(camClampMin, mainCam.transform.localEulerAngles.y, mainCam.transform.localEulerAngles.z);
        }
    }
}
