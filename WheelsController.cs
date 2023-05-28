using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelsController : MonoBehaviour
{
    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider backRight;
    [SerializeField] WheelCollider backLeft;

    [SerializeField] Transform frontRightTransform;
    [SerializeField] Transform frontLeftTransform;
    [SerializeField] Transform backRightTransform;
    [SerializeField] Transform backLeftTransform;

    public float acceleration =500;
    public float breakingForce =300;
    public float maxTurnAngle = 20f;

    private float currentAcceleration =0f;
    private float currentBrakeForce =0f;
    private float currentTurnAngle = 0f;
    private AudioClip carSound;
    private AudioSource carAudio;
    public Rigidbody rb;
    private float sesLeveli;

    public GameObject Player;
    public bool inCar = false;
    [SerializeField] Vector3 transofrmPlayer;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        carAudio = GetComponent<AudioSource>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        if (inCar) 
        {
            currentAcceleration = acceleration * Input.GetAxis("Vertical");
        }
        



        if (Vector3.Distance(Player.transform.position, this.transform.position) <= 5 && Input.GetKeyDown(KeyCode.E) && !inCar && Player.activeSelf)
        {
            inCar = true;
            Player.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.E) && inCar && !Player.activeSelf)
        {
            Player.transform.position = this.transform.position + new Vector3(5,5,5);
            Player.SetActive(true);
            inCar = false;
        }

        if (Input.GetKeyDown(KeyCode.W) && inCar)
        {

            sesLeveli = 0.8f;
            carAudio.volume = sesLeveli;
            carAudio.Play();
            if (rb.velocity.magnitude >=15)
            {
                sesLeveli = 1;
                carAudio.volume = sesLeveli;
                carAudio.Play();
            }
        }
        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyDown(KeyCode.Space) && inCar)
        {

            if (rb.velocity.magnitude <= 15 && rb.velocity.magnitude > 5)
            {
                sesLeveli = 0.6f;
                carAudio.volume = sesLeveli;
                carAudio.Play();
            }
            if (rb.velocity.magnitude <= 10 && rb.velocity.magnitude > 5)
            {
                sesLeveli = 0.4f;
                carAudio.volume = sesLeveli;
                carAudio.Play();
            }
            if (rb.velocity.magnitude <= 5 && rb.velocity.magnitude > 3)
            {
                sesLeveli = 0.1f;
                carAudio.volume = sesLeveli;
                carAudio.Play();
            }

            if (rb.velocity.magnitude <= 3)
            {
                sesLeveli = 0.01f;
                carAudio.volume = sesLeveli;
                carAudio.Play();
            }
        }


        if (Input.GetKey(KeyCode.Space) && inCar)
        {
            currentBrakeForce = breakingForce;
        }
        else
        {
            currentBrakeForce = 0f;
        }

        backRight.motorTorque = currentAcceleration;
        backLeft.motorTorque = currentAcceleration;

        frontRight.brakeTorque = currentBrakeForce;
        frontLeft.brakeTorque = currentBrakeForce;
        backRight.brakeTorque = currentBrakeForce;
        backLeft.brakeTorque = currentBrakeForce;

        if (inCar)
        {
            currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
        }

        frontLeft.steerAngle = currentTurnAngle;
        frontRight.steerAngle = currentTurnAngle;

        UpdateWheel(frontLeft, frontLeftTransform);
        UpdateWheel(frontRight, frontRightTransform);
        UpdateWheel(backLeft, backLeftTransform);
        UpdateWheel(backRight, backRightTransform);

    }

    void UpdateWheel(WheelCollider col, Transform trans)
    {
        Vector3 position;
        Quaternion rotation;
        col.GetWorldPose(out position, out rotation);

        trans.position = position;
        trans.rotation = rotation;
    }
}
