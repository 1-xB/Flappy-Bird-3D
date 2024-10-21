using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bird : MonoBehaviour
{
    
    Rigidbody Rigidbody;
    AudioSource audioSource;

    [SerializeField] AudioClip jumpSound;
    bool isAlive = true;
    float currectRotation = 0;
    [SerializeField] float jumpForce = 500f;
    [SerializeField] float rotationUpSpeed = 5f;
    [SerializeField] float rotationDownSpeed = 2f;


    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        ProcessJump();
    }


    void ProcessJump() {
        // If bird is not alive, return
        if (!isAlive) return;

        // If space key is pressed
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            ExecuteJump();
        }
        RotationUpdate();
    }

    private void RotationUpdate()
    {
        // If bird is going up
        if (Rigidbody.velocity.y > -2) // -2 to zapobiega przekręceniu ptaka w dół zbyt wcześnie
        {
            /* 

                Mathf.Lerp(currectRotation, 30, Time.deltaTime * rotationUpSpeed);

                Wyjaśnienie:
                currectRotation -- aktualna rotacja
                30 -- docelowa rotacja
                Time.deltaTime * rotationUpSpeed -- prędkość rotacji

            */
            

            // calculate smooth up rotation
            currectRotation = Mathf.Lerp(currectRotation, 30, Time.deltaTime * rotationUpSpeed);
        }

        // If bird is going down
        else
        {
            // calculate smooth down rotation
            currectRotation = Mathf.Lerp(currectRotation, -90, Time.deltaTime * rotationDownSpeed);
        }
        // Rotate bird
        transform.rotation = Quaternion.Euler(0, 0, currectRotation);

    }

    private void ExecuteJump()
    {
        audioSource.PlayOneShot(jumpSound);
        Rigidbody.velocity = new Vector3(Rigidbody.velocity.x, 0, Rigidbody.velocity.z);
        Rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    

}
