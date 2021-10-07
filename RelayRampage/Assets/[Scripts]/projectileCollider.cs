using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileCollider : MonoBehaviour
{

    bool readyToDisable = false;
    Vector3 dir; 
    Rigidbody rb;
    float moveSpeed;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {
        if(readyToDisable)
        {
            readyToDisable = false;
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        readyToDisable = true;
    }

    public void setVelocity(Vector3 velocity)
    {
        if(rb != null)
        {
            rb.velocity = velocity;
        }
    }
}
