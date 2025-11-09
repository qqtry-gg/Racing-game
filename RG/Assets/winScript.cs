using UnityEngine;

public class winScript : MonoBehaviour
{
    [SerializeField] GameManagerScript gameManagerScript;
    [SerializeField] Vector3 positionToTeleport;
    [SerializeField] GameObject Player;
    bool hasPlayerAlreadywon = false;
    [SerializeField]RaceStartingScript raceStartingScript;
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
        if (other.CompareTag("Ai"))
        {
            if (!hasPlayerAlreadywon)
            {
                Debug.Log("You lose");//to do logic of losing (animations, things like that)
                Player = GameObject.FindGameObjectWithTag("Car");
                Player.transform.position = positionToTeleport;
            }
            hasPlayerAlreadywon=false;
            raceStartingScript.CanStartRace();
        }
        else if (other.CompareTag("Car"))
        {

            Debug.Log("You win"); //to do logic of winning(animations, things like that)
            Player = GameObject.FindGameObjectWithTag("Car");
            gameManagerScript.EarningCoins(50);
            Player.transform.position = positionToTeleport;
            hasPlayerAlreadywon = true;
            raceStartingScript.CanStartRace();
        }
    }
}
