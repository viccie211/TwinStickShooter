using UnityEngine;
using System.Collections;

public class rotateCube : MonoBehaviour
{

    // Maximum turn rate in degrees per second.
    public float turningRate = 90f;
    // Rotation we should blend towards.
    private Quaternion _targetRotation = Quaternion.identity;
    // Call this when you want to turn the object smoothly.
    public void SetBlendedEulerAngles(Vector3 angles)
    {
        _targetRotation = Quaternion.Euler(angles);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            SetBlendedEulerAngles(new Vector3(90, 0, 0));
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            SetBlendedEulerAngles(new Vector3(0, 90, 0));
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            SetBlendedEulerAngles(new Vector3(-90, 0, 0));
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            SetBlendedEulerAngles(new Vector3(0, -90, 0));
        }

        // Turn towards our target rotation.
        transform.rotation = Quaternion.RotateTowards(transform.rotation, _targetRotation, turningRate * Time.deltaTime);
    }
}

