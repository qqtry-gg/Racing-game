using UnityEngine;

public class SmokeDetectorScript : MonoBehaviour
{
    public GameObject Smoke;
    public float TimeBeforeDisappering = 1f;
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
        GameObject Deleting = Instantiate(Smoke, transform.position, Quaternion.identity);

        Destroy(Deleting, TimeBeforeDisappering);
    }

}
