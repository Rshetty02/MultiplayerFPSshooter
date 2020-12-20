using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 camerarotation = Vector3.zero;

    private Rigidbody rb;
    

    public Camera cam;
    // Start is called before the first frame update
    void Start()
    {
     rb = GetComponent<Rigidbody>();

    }

    //Gets a movement Vector
    public void Move(Vector3 _velocity){
        velocity = _velocity;
    }

    public void Rotate(Vector3 _rotation){
        rotation = _rotation;
    }

    public void cameraRotate(Vector3 _camerarotation){
        camerarotation = _camerarotation;
    }


    //Run every Physics iteration
    void FixedUpdate()
    {
        PerformMovement();
        PerformRotation();
    }

    //Performs movement based on velocity variable
    private void PerformMovement()
    {
        if(velocity != Vector3.zero){
            rb.MovePosition(rb.position + velocity * Time.deltaTime);
        }
    }

    void PerformRotation(){
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        if(cam != null){
            cam.transform.Rotate(camerarotation);            
        }
    }

}

