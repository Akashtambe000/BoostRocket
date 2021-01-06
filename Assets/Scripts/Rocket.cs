using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{

    Rigidbody rocketBody;
    AudioSource rocketAudio;

    // Start is called before the first frame update
    void Start()
    {
        rocketBody = this.gameObject.GetComponent<Rigidbody>();
        rocketAudio = this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        processInput();
    }

    public void processInput()
    {
        Thrust();
        Rotate();
    }

    private void Rotate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            this.gameObject.transform.Rotate(Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            this.gameObject.transform.Rotate(Vector3.back);
        }
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))
        {
            rocketBody.AddRelativeForce(Vector3.up);
            if (!rocketAudio.isPlaying)
            {
                rocketAudio.Play();
            }
        }
        else
        {
            if (rocketAudio.isPlaying)
            {
                rocketAudio.Stop();
            }
        }
    }
}
