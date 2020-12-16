using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    public float speed = 5f;

    private PlayerMotor motor;
    public Joystick movement;

    public Joystick cam;
    public float lookSensitivity = 3f;

    // Start is called before the first frame update
    void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        //calculate movement velocity as a 3d vector
        float xMov = movement.Horizontal;
        float zMov = movement.Vertical;



        Vector3 moveHorizontal = transform.right * xMov;

        Vector3 moveVertical = transform.forward * zMov;

        //final movement vector
        Vector3 velocity = (moveHorizontal + moveVertical).normalized *speed;

        motor.Move(velocity);


        //calculate rotation as a 3d vector. This applies to turning around
        float yRot = cam.Horizontal;
           
        Vector3 rotation = new Vector3(0f, yRot , 0f) * lookSensitivity;
        
        motor.Rotate(rotation);
        
        //calculate  cam rotation as a 3d vector.
        float xRot = cam.Vertical;
           
        Vector3 camera_rotation = new Vector3(xRot, 0f , 0f) * lookSensitivity;
        
        motor.cameraRotate(-camera_rotation);

            }
}
