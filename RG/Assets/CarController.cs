using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour
{
    private Rigidbody playerRB;

    public WheelCollider FRwheel;
    public WheelCollider FLwheel;
    public WheelCollider BRwheel;
    public WheelCollider BLwheel;
    public MeshRenderer FRwheelMesh;
    public MeshRenderer FLwheelMesh;
    public MeshRenderer BRwheelMesh;
    public MeshRenderer BLwheelMesh;

    public float gasInput;
    public float steeringInput;
    public float brakepower;
    private float slipAngle;
    public float brakeInput;

    public float motorPower;
    float speed;
    public AnimationCurve steeringCurve;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRB = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        speed = playerRB.linearVelocity.magnitude;
        CheckInput();
        ApplyWheelPositions();
        ApplyMotor();
        ApplySteering();
        ApplyBreak();
    }
    void ApplyBreak()
    {
        FRwheel.brakeTorque = brakeInput * brakepower * 0.7f;
        FLwheel.brakeTorque = brakeInput * brakepower * 0.7f;
        BRwheel.brakeTorque = brakeInput * brakepower * 0.3f;
        BLwheel.brakeTorque = brakeInput * brakepower * 0.3f;
    }
    void ApplyWheelPositions()
    {
        UpdateWheel(FRwheel, FRwheelMesh);
        UpdateWheel(FLwheel, FLwheelMesh);
        UpdateWheel(BRwheel, BRwheelMesh);
        UpdateWheel(BLwheel, BLwheelMesh);
    }
    void ApplySteering()
    {
        float steeringangle = steeringInput * steeringCurve.Evaluate(speed);
        FRwheel.steerAngle= steeringangle;
        FLwheel.steerAngle = steeringangle;
    }
    void UpdateWheel(WheelCollider collider, MeshRenderer renderer)
    {
        Quaternion quat;
        Vector3 position;
        collider.GetWorldPose(out position, out quat);
        renderer.transform.position = position;
        renderer.transform.rotation = quat;

    }
    void CheckInput()
    {
        gasInput = Input.GetAxis("Vertical");
        steeringInput = Input.GetAxis("Horizontal");
        slipAngle = Vector3.Angle(transform.forward, playerRB.angularVelocity - transform.forward); //it might have to be linearVelocity this might be my mistake
        if (slipAngle < 120f)
        {
            if (gasInput < 0)
            {
                brakeInput = Mathf.Abs(gasInput);
                gasInput = 0;
            }
            else
            {
                brakeInput = 0;
            }
        }
        else
        {
            brakeInput = 0;
        }
    }
    void ApplyMotor()
    {
        BRwheel.motorTorque = motorPower * gasInput;
        BLwheel.motorTorque = motorPower * gasInput;
    }
}
