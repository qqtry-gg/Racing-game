using UnityEngine;

public class RaceStartingScript : MonoBehaviour
{
    public float Timer = 0f;
    public GameManagerScript gameManagerScript;
    public CarController carController;
    public AIscript aIscript;
    private bool CanRun = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car") && CanRun)
        {
            carController = other.GetComponent<CarController>();
            carController.enabled = false;  // Wy³¹cz kontrolê gracza
            Timer = 0f; // Reset licznika przy starcie
            Debug.Log("Car entered, starting countdown...");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Car") && CanRun)
        {
            Timer += Time.deltaTime;

            if (Timer >= 3f)
            {
                // Uruchom wyœcig
                aIscript.StartRacing();
                carController.enabled = true;
                CanRun = false;
                Debug.Log("Start!");
            }
        }
    }
}
