using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CharacterStats))]
public class PlayerMovement : MonoBehaviour
{
    Rigidbody rigidbody ;
    CharacterStats stats;

    int moveSpeed;
    Vector2 dir;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        stats = GetComponent<CharacterStats>();
        moveSpeed = stats.Speed;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

       rigidbody.velocity = new Vector3(moveSpeed * dir.x, rigidbody.velocity.y, moveSpeed * dir.y);
    }

    public void setVelocity(InputAction.CallbackContext inputs)
    {
        
        dir = inputs.ReadValue<Vector2>();

    }

    public void Enable()
    {
        moveSpeed = stats.Speed;
    }
    public void Disable()
    {
        
    }
}
