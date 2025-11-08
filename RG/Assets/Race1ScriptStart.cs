using UnityEngine;
using UnityEngine.Rendering;

public class Race1ScriptStart : MonoBehaviour
{
    private float timer;
    public Vector3 CordsToTeleport;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            timer += Time.deltaTime;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            timer += Time.deltaTime;
            if (timer >= 10)
            {
                other.gameObject.transform.position = CordsToTeleport;
                timer = 0;
                Debug.Log("Car stays in the area");
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            Debug.Log("Car Leaves the are");
            timer = 0;
        }
    }

}
