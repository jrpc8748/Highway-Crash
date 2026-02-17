using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CarSounds : MonoBehaviour
{
    public CarController car;
    public AudioClip engineClip;

    [Header("Tuning")]
    public float minPitch = 0.75f;  
    public float maxPitch = 2.0f;
    public float maxSpeedForPitch = 100f;

    private AudioSource engineAudio;

    void Awake()
    {
        engineAudio = GetComponent<AudioSource>();
        engineAudio.loop = true;
        engineAudio.playOnAwake = false;

        if(engineClip != null)
        {
            engineAudio.clip = engineClip;
            engineAudio.Play();
        }
    }

 
    void Start()
    {
        if(car == null)
        {
            car = GetComponentInParent<CarController>();
        }

        if(engineAudio.clip != null)
        {
            engineAudio.Play(); 
        }
    }

    void Update()
    {
        if (car == null) return;

        float speed = car.CarSpeed();
        float t = Mathf.Clamp01(speed / maxSpeedForPitch);

        engineAudio.pitch = Mathf.Lerp(minPitch, maxPitch, t);
        engineAudio.volume = Mathf.Lerp(0.5f, 1.0f, t);

    }
}
