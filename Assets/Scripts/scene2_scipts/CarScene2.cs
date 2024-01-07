using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarScene2 : MonoBehaviour
{
    public enum Axel
    {
        Front,
        Rear
    }

    [Serializable]
    public struct Wheel
    {
        public GameObject wheelMeshes;
        public WheelCollider wheelCollider;
        public Axel wheelAxel;
    }

    public float maxAcceleration = 30.0f;
    public float breakAcceleration = 50.0f;
    public float turnSensitivity = 1.0f;
    public float maxSteerAngle = 30.0f;
    public Vector3 _centerOfMass;
    public GameObject scoreText;

    public List<Wheel> wheels;

    float moveInput;
    float steerInput;

    private const int targetScore = 12;
    private int score = 0;
    public Rigidbody rb;

    public GameObject getScoreText()
    {
        return scoreText;
    }

    public int getScore()
    {
        return score;
    }

    public int getTargetScore()
    {
        return targetScore;
    }


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = _centerOfMass;

    }

    private void Update()
    {
        GetInputs();
        WheelAnimation();
        restartGameByPressKey();
        backToMenu();

    }

    private void LateUpdate()
    {
        Move();
        Steer();
        Brake();
    }

    void GetInputs()
    {
        moveInput = Input.GetAxis("Vertical");
        steerInput = Input.GetAxis("Horizontal");
    }

    void Move()
    {
        foreach (var wheel in wheels)
        {
            wheel.wheelCollider.motorTorque = moveInput * 300 * maxAcceleration * Time.deltaTime;
        }
    }

    void Steer()
    {
        foreach (var wheel in wheels)
        {
            if (wheel.wheelAxel == Axel.Front)
            {
                var _steerAngle = steerInput * turnSensitivity * maxSteerAngle;
                wheel.wheelCollider.steerAngle = Mathf.Lerp(wheel.wheelCollider.steerAngle, _steerAngle, 0.6f);
            }
        }
    }

    void WheelAnimation()
    {
        foreach (var wheel in wheels)
        {
            Quaternion rot;
            Vector3 pos;
            wheel.wheelCollider.GetWorldPose(out pos, out rot);
            wheel.wheelMeshes.transform.position = pos;
            wheel.wheelMeshes.transform.rotation = rot;
        }
    }

    void Brake()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            foreach (var wheel in wheels)
            {
                wheel.wheelCollider.brakeTorque = 600 * breakAcceleration * Time.deltaTime;
            }
        }
        else
        {
            foreach (var wheel in wheels)
            {
                wheel.wheelCollider.brakeTorque = 0;
            }
        }
    }

    void restartGameByPressKey()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadSceneAsync(
                SceneManager.GetActiveScene().buildIndex);
        }
    }

    //back to menu if press 'esc' key
    void backToMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            FindObjectOfType<LoadScene>().backToMenu();
    }

    //disable zombie when collison occurs
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("zombie"))
        {
            score += 1;
            scoreText.GetComponent<TextMesh>().text = "Killed zombie: " + score + " / " + targetScore;
            other.gameObject.SetActive(false);
        }
    }
}
