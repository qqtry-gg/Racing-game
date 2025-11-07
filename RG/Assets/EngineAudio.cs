using UnityEngine;

public class EngineAudio : MonoBehaviour
{
    public AudioSource runningSound;
    public float runningMaxVolume;
    public float runningMaxPitch;
    public AudioSource idleSound;
    public float idleMaxVolume;

    float speedRatio;

    private CarController carController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        carController = GetComponent<CarController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (carController)
        {
            speedRatio = carController.GetSpeedRatio();
        }
        idleSound.volume = Mathf.Lerp(0.1f, idleMaxVolume, speedRatio);

        runningSound.volume = Mathf.Lerp(0.3f, runningMaxVolume, speedRatio);

        runningSound.pitch = Mathf.Lerp(runningSound.pitch, Mathf.Lerp(0.3f, runningMaxPitch, speedRatio), Time.deltaTime);
    }
}
