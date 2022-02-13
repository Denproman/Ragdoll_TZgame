using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public float speedUp;
    public VariableJoystick variableJoystick;
    public Rigidbody rb;

    public void FixedUpdate()
    {
        Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;
       
        rb.AddForce(new Vector3(direction.x * speed, 0, direction.z * speed) * Time.fixedDeltaTime, ForceMode.Impulse);
        rb.AddForce(new Vector3(0, direction.y * speedUp, 0) * Time.fixedDeltaTime, ForceMode.Force);
    }
}