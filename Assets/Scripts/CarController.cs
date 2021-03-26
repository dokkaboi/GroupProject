using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed = 17;


    Vector3 rotationRight = new Vector3(0, 60, 0);
    Vector3 rotationLeft = new Vector3(0, -60, 0);
    [SerializeField] private GameObject rearCamera;
    [SerializeField] private GameObject frontCamera;

    Vector3 forward = new Vector3(0, 0, 1);
    Vector3 backward = new Vector3(0, 0, -1);


    private float horizontalInput;
    private float verticalInput;
    private float steeringAngle;

    public WheelCollider frontDriverW, frontPassengerW;
    public WheelCollider rearDriverW, rearPassengerW;
    public Transform frontDriverT, frontPassengerT;
    public Transform rearDriverT, rearPassengerT;
    public float maxSteerAngle = 30;
    public float motorForce = 50;

    void Update()
    {
        if (Input.GetKey("w"))
        {
            transform.Translate(forward * speed * Time.deltaTime);
            if (Input.GetKey("d"))
            {
                Quaternion deltaRotationRight = Quaternion.Euler(rotationRight * Time.deltaTime);
                gameObject.GetComponent<Rigidbody>().MoveRotation(gameObject.GetComponent<Rigidbody>().rotation * deltaRotationRight);
            }

            if (Input.GetKey("a"))
            {
                Quaternion deltaRotationLeft = Quaternion.Euler(rotationLeft * Time.deltaTime);
                gameObject.GetComponent<Rigidbody>().MoveRotation(gameObject.GetComponent<Rigidbody>().rotation * deltaRotationLeft);
            }
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(backward * speed * Time.deltaTime);
            if (Input.GetKey("d"))
            {
                Quaternion deltaRotationRight = Quaternion.Euler(rotationRight * Time.deltaTime);
                gameObject.GetComponent<Rigidbody>().MoveRotation(gameObject.GetComponent<Rigidbody>().rotation * deltaRotationRight);
            }

            if (Input.GetKey("a"))
            {
                Quaternion deltaRotationLeft = Quaternion.Euler(rotationLeft * Time.deltaTime);
                gameObject.GetComponent<Rigidbody>().MoveRotation(gameObject.GetComponent<Rigidbody>().rotation * deltaRotationLeft);
            }
        }


        if (Input.GetKey("e"))
        {
            frontCamera.SetActive(false);
            rearCamera.SetActive(true);
        }
        else
        {
            rearCamera.SetActive(false);
            frontCamera.SetActive(true);
        }
    }

        public void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    private void Steer()
    {
        steeringAngle = maxSteerAngle * horizontalInput;
        frontDriverW.steerAngle = steeringAngle;
        frontPassengerW.steerAngle = steeringAngle;
    }

    private void Accelerate()
    {
        rearDriverW.motorTorque = verticalInput * motorForce;
        rearPassengerW.motorTorque = verticalInput * motorForce;
    }

    private void UpdateWheelPoses()
    {
        UpdateWheelPose(frontDriverW, frontDriverT);
        UpdateWheelPose(frontPassengerW, frontPassengerT);
        UpdateWheelPose(rearDriverW, rearDriverT);
        UpdateWheelPose(rearPassengerW, rearPassengerT);
    }

    private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
    {
        Vector3 _pos = _transform.position;
        Quaternion _quat = _transform.rotation;

        _collider.GetWorldPose(out _pos, out _quat);

        _transform.position = _pos;
        _transform.rotation = _quat;
    }

    private void FixedUpdate()
    {
        GetInput();
        Steer();
        Accelerate();
        UpdateWheelPoses();
    }
}
