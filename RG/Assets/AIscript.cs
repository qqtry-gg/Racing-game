using UnityEngine;
using UnityEngine.AI;

public class AIscript : MonoBehaviour
{
    public Transform[] WayPoints;

    NavMeshAgent agent;

    private int currentIndex = 0;

    private bool CanRace = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (WayPoints.Length >0)
        {
            agent.SetDestination(WayPoints[currentIndex].position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (CanRace == true)
        {
            if (currentIndex <= WayPoints.Length)
            {
                if (agent.remainingDistance <= agent.stoppingDistance)
                {
                    currentIndex = (currentIndex + 1);
                    agent.SetDestination(WayPoints[currentIndex].position);
                }
            }
            else
            {
                CanRace = false;
                Debug.Log("There's no more wayPoints");
            }
        }
    }
    public void StartRacing()
    {
        CanRace = true;
        currentIndex = 0;
    }
}
