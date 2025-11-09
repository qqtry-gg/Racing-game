using UnityEngine;
using UnityEngine.Rendering;

public class Race1ScriptStart : MonoBehaviour
{
    private float timer;
    public Vector3 CordsToTeleport;
    public Vector3 RotationToTeleport;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            timer += Time.deltaTime;
            if (timer >= 10)
            {
                Rigidbody rb = other.GetComponent<Rigidbody>();
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                other.gameObject.transform.position = CordsToTeleport;
                other.gameObject.transform.rotation = Quaternion.Euler(RotationToTeleport);
                rb.angularVelocity = Vector3.zero;
                rb.linearVelocity = Vector3.zero;
                timer = 0;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Car"))
        {
           
            timer = 0;
        }
    }

}
