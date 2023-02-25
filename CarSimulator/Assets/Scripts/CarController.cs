using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
     private float moveInput;
     private float turnInput;
     private bool isCarGrounded;

     public float fwspd;
     public float bkwspd;
     public float turnspd;
     public Rigidbody SphereRB;
     public LayerMask groundLayer;
     public float AirDrag;
     public float GroundDrag;

    // Start is called before the first frame update
    void Start()
    {
        SphereRB.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxisRaw("Vertical");
        turnInput = Input.GetAxisRaw("Horizontal");

        //Speed of the car
        moveInput *= moveInput > 0 ? fwspd : bkwspd;

        //set the car position same as the sphere
        transform.position = SphereRB.transform.position;

        //turning of the car
        float newRotation = turnInput * turnspd * Time.deltaTime * Input.GetAxisRaw("Vertical");
        transform.Rotate(0,newRotation,0, Space.World);

        //Checking the ground
        RaycastHit hit;

        isCarGrounded = Physics.Raycast(transform.position,-transform.up,out hit, 1f,groundLayer);

        //Rotate Car Parallel to the Ground
        transform.rotation = Quaternion.FromToRotation(transform.up,hit.normal) * transform.rotation;

        if(isCarGrounded){
            SphereRB.drag = GroundDrag;
        }
        else{
            SphereRB.drag = AirDrag;
        }
    }

    private void FixedUpdate()
    {
        if(isCarGrounded)
        {
            SphereRB.AddForce(transform.forward * moveInput, ForceMode.Acceleration);
        }
        else{
        SphereRB.AddForce(transform.up * -30f);
        }       
        
    }
}
