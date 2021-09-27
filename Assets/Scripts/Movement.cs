using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float boostPower = 1000f;
    [SerializeField] float turnPower = 100f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem mainBooster;
    [SerializeField] ParticleSystem leftBooster;
    [SerializeField] ParticleSystem rightBooster;

    Rigidbody rb;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessBoost();
        ProcessRotation();
    }

    void ProcessBoost()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartBoosting();

        }
        else
        {
            StopBoosting();
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            TurnLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            TurnRight();
        }
        else
        {
            StopTurning();
        }
    }

    private void TurnLeft()
    {
        ApplyRotation(turnPower);
        if (!rightBooster.isPlaying)
        {
            leftBooster.Stop();
            rightBooster.Play();
        }
    }

    private void TurnRight()
    {
        if (!leftBooster.isPlaying)
        {
            rightBooster.Stop();
            leftBooster.Play();
        }
        ApplyRotation(-turnPower);
    }

    void StartBoosting()
    {
        rb.AddRelativeForce(Vector3.up * boostPower * Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
        if (!mainBooster.isPlaying)
        {
            mainBooster.Play();
        }
    }
    private void StopBoosting()
    {
        audioSource.Stop();
        mainBooster.Stop();
    }

    private void StopTurning()
    {
        leftBooster.Stop();
        rightBooster.Stop();
    }



    public void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; // Freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; // Unfreezing rotation so the physics system can take over
    }
}
