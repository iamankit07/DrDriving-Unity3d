using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEditor.AnimatedValues;
using UnityEngine;

public class carMove : MonoBehaviour
{
    public WheelCollider FrontRightwheelcollider;
    public WheelCollider RearRightwheelcollider;
    public WheelCollider FrontLeftwheelcollider;
    public WheelCollider RearLeftwheelcollider;

    public Transform FrontRightwheelTransform;
     public Transform ReartRightwheelTransform;
      public Transform FrontLeftwheelTransform;
       public Transform RearLeftwheelTransform;
       public Transform carCentreOfMassTransform;
       public Rigidbody rigidbody1;

       float verticalInput;
       float horizontalInput;
       public float breakforce=1000f;
       public float motionforce=50f;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody1.centerOfMass=carCentreOfMassTransform.localPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      Motorforce();
      UpdateWheels();
      GetInputs();
      Steering();
      Brakes();
    }
    void GetInputs()
    {
      verticalInput=Input.GetAxis("Vertical");
      horizontalInput= Input.GetAxis("Horizontal");
    }
    void Brakes(){
      if(Input.GetKey(KeyCode.Space)){
      FrontRightwheelcollider.brakeTorque=breakforce;
      FrontLeftwheelcollider.brakeTorque=breakforce;
      RearLeftwheelcollider.brakeTorque=breakforce;
      RearRightwheelcollider.brakeTorque=breakforce;
      rigidbody1.drag=1f;
      }
      else{
         FrontRightwheelcollider.brakeTorque=0f;
      FrontLeftwheelcollider.brakeTorque=0f;
      RearLeftwheelcollider.brakeTorque=0f;
      RearRightwheelcollider.brakeTorque=0f;
      rigidbody1.drag=0f;
      }
    }
    void Motorforce(){
         FrontRightwheelcollider.motorTorque=100f*verticalInput;
        FrontLeftwheelcollider.motorTorque=100f*verticalInput;
    }
    void Steering(){
      FrontRightwheelcollider.steerAngle=motionforce* horizontalInput;
       FrontLeftwheelcollider.steerAngle=motionforce* horizontalInput;
    }
    void PowerSteering(){
      if(horizontalInput==0){
       transform.rotation=UnityEngine.Quaternion.Slerp(transform.rotation,UnityEngine.Quaternion.Euler(0,0,0),Time.deltaTime);
      }
    }
    void UpdateWheels()
    {
      RotateWheel(FrontRightwheelcollider, FrontRightwheelTransform);
    }

    void RotateWheel(WheelCollider wheelCollider,Transform transform)
    {
      UnityEngine.Vector3 pos;
      UnityEngine.Quaternion rotation;
      
      wheelCollider.GetWorldPose(out pos,out rotation );  //store position and rotation in variable pos and rot.
      transform.position=pos;
      transform.rotation=rotation;
    }
}
