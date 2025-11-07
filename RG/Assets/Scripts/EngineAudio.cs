using UnityEngine;

public class EngineAudio : MonoBehaviour
{
    public AudioSource runningSound;
    public float runningMaxVolume;
    public float runningMaxPitch;
    public AudioSource idleSound;
    public float idleMaxVolume;

    public float revLimiter;
    public float LimiterSound = 1f;
    public float LimiterFrequency = 3f;
    public float LimiterEngage = 0.8f;

    public AudioSource ReverseSound;
    public float ReverseMaxVolume;
    public float ReverseMaxPitch;

    float speedRatio;

    private CarController carController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        carController = GetComponent<CarController>();

        ReverseSound.volume = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        float speedsign=0;
        if (carController)
        {
            speedsign = Mathf.Sign(carController.GetSpeedRatio());
            speedRatio = Mathf.Abs(carController.GetSpeedRatio());
        }
        if (speedRatio > LimiterEngage)
        {
            revLimiter = (Mathf.Sin(Time.time * LimiterFrequency) + 1f) * LimiterSound* (speedRatio-LimiterEngage);
        }
        if (speedsign > 0)
        {
            ReverseSound.volume = 0;
            runningSound.volume = Mathf.Lerp(0.3f, runningMaxVolume, speedRatio);

            runningSound.pitch = Mathf.Lerp(runningSound.pitch, Mathf.Lerp(0.3f, runningMaxPitch, speedRatio) + revLimiter, Time.deltaTime);
        }
        else
        {
            runningSound.volume = 0;
            ReverseSound.volume = Mathf.Lerp(0f, ReverseMaxVolume, speedRatio);

            ReverseSound.pitch = Mathf.Lerp(ReverseSound.pitch, Mathf.Lerp(0.3f, ReverseMaxPitch, speedRatio) + revLimiter, Time.deltaTime);
        }
        idleSound.volume = Mathf.Lerp(0.1f, idleMaxVolume, speedRatio);

        runningSound.volume = Mathf.Lerp(0.3f, runningMaxVolume, speedRatio);

        runningSound.pitch = Mathf.Lerp(runningSound.pitch, Mathf.Lerp(0.3f, runningMaxPitch, speedRatio)+revLimiter, Time.deltaTime);
    }
}
