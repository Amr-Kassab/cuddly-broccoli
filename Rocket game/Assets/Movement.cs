using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject launchPad;
    Rigidbody rb;
    Transform tr; 
    AudioSource audioo;
    [SerializeField] AudioClip mainengine;

    [SerializeField] private float velocity = 2000f;
    [SerializeField] private float rotation = 100f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioo = GetComponent<AudioSource>();
        AdjustStartingPosition();
    }


    // Update is called once per frame
    void Update()
    {
        processRotatin();
        processThrust();
    }
    
    void processThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * velocity * Time.deltaTime);
            if (!audioo.isPlaying)
            {
                audioo.PlayOneShot(mainengine);
            }
        }
        else
        {
            audioo.Stop();
        }
    }

    void processRotatin ()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotation);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotation);
        }
    }

    private void ApplyRotation(float rotationthisframe)
    {
        rb.freezeRotation = true;
        gameObject.transform.Rotate(Vector3.forward * rotationthisframe * Time.deltaTime);
        rb.freezeRotation = false;
    }

        private void AdjustStartingPosition()
    {
        transform.position = launchPad.transform.position + new Vector3(0, 9.9f, 0);
    }

}
