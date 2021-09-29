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

    int moveSpeed;
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
        moveSpeed = stats.Speed /10;
      
    }

    // Update is called once per frame
    void FixedUpdate()
    {

       rigidbody.velocity = new Vector3(moveSpeed * direction.x, rigidbody.velocity.y, moveSpeed * direction.y);
        
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
