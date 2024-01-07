using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CarEngineSound : MonoBehaviour
{
    public float minSpeed;
    public float maxSpeed;
    private float currentSpeed;

    private Rigidbody rb;
    private AudioSource carEngineAudio;

    public float minPitch;
    public float maxPitch;
    private float pitchFromCar;

    private void Start()
    {
        carEngineAudio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        PlayEngineSound();
    }

    void PlayEngineSound()
    {
        currentSpeed = rb.velocity.magnitude;
        pitchFromCar = rb.velocity.magnitude / 50.0f;

        if (currentSpeed < minSpeed)
            carEngineAudio.pitch = minPitch;

        if (currentSpeed > minSpeed && currentSpeed < maxSpeed)
            carEngineAudio.pitch = minPitch + pitchFromCar;

        if (currentSpeed > maxSpeed)
            carEngineAudio.pitch = maxPitch;
    }
}
