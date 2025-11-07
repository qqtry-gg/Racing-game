using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    private Rigidbody playerRB;
    public Vector3 Offset;
    public float speed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Car").transform;
        playerRB = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 playerForward = (playerRB.linearVelocity + playerRB.transform.forward).normalized;
        transform.position = Vector3.Lerp(transform.position, player.position+player.transform.TransformVector(Offset)+playerForward*(-5f), speed*Time.deltaTime);
        transform.LookAt(player);
    }
}
