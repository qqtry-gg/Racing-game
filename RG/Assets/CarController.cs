using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour
{
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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        ApplyWheelPositions();
    }
    void ApplyWheelPositions()
    {
        UpdateWheel(FRwheel, FRwheelMesh);
        UpdateWheel(FLwheel, FLwheelMesh);
        UpdateWheel(BRwheel, BRwheelMesh);
        UpdateWheel(BLwheel, BLwheelMesh);
    }
    void CheckInput()
    {
        gasInput = Input.GetAxis("Vertical");
        steeringInput = Input.GetAxis("Horizontal");
    }
    void UpdateWheel(WheelCollider collider, MeshRenderer renderer)
    {
        Quaternion quat;
        Vector3 position;
        collider.GetWorldPose(out position, out quat);
        renderer.transform.position = position;
        renderer.transform.rotation = quat;

    }
}
