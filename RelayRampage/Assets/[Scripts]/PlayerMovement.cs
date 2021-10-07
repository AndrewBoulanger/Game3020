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
    InputAction.CallbackContext context;

    Vector3 velocity;
    float maxAcceleration;

    float moveSpeed;
    Vector2 direction;

    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        stats = GetComponent<CharacterStats>();
        moveSpeed = maxAcceleration = (float)stats.Speed * 0.1f;

        velocity = Vector3.zero;
      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetVelocity = Vector3.zero;
        targetVelocity.x = moveSpeed * direction.x;
        targetVelocity.z = moveSpeed * direction.y;

        Vector3 velocity = rigidbody.velocity;
        Vector3 DeltaVelocity = (targetVelocity - velocity);
        DeltaVelocity.x = Mathf.Clamp(DeltaVelocity.x, -maxAcceleration, maxAcceleration);
        DeltaVelocity.z = Mathf.Clamp(DeltaVelocity.z, -maxAcceleration, maxAcceleration);
        DeltaVelocity.y = 0;

        rigidbody.AddForce(DeltaVelocity, ForceMode.VelocityChange);
       
        anim.SetFloat("moveSpeed", rigidbody.velocity.sqrMagnitude);

    }

    public void setVelocity(InputAction.CallbackContext inputs)
    {
        setDirection(inputs.ReadValue<Vector2>());
        context = inputs;
    }
    private void OnEnable()
    {
       setDirection(context.ReadValue<Vector2>());
    }

    private void OnDisable()
    {
        direction = Vector2.zero;
        if(rigidbody != null)
            rigidbody.velocity = new Vector3(0, velocity.y, 0);
        if(anim != null)
            anim.SetFloat("moveSpeed", 0f);
    }

    private void setDirection(Vector2 dir)
    {
        direction = dir;
        if (direction.x > 0)
            transform.rotation = Quaternion.Euler(Vector3.up * 90);
        else if (direction.x < 0)
            transform.rotation = Quaternion.Euler(Vector3.down * 90);
    }

}
