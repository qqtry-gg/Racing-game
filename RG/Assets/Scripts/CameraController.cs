using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    private Rigidbody playerRB;
    public Vector3 Offset;
    public float speed;
    bool isInShop = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Car").transform;
        playerRB = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!isInShop)
        {
            Vector3 playerForward = (playerRB.linearVelocity + playerRB.transform.forward).normalized;
            transform.position = Vector3.Lerp(transform.position, player.position + player.transform.TransformVector(Offset) + playerForward * (-5f), speed * Time.deltaTime);
            transform.LookAt(player);
        }
    }
    public void EnterShop()
    {
        isInShop = true;
    }
    public void ExitShop()
    {
        isInShop = false;
    }
}
