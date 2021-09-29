using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class attackCollider : MonoBehaviour
{
    Collider collider;

    float startOffset;
    float activeDuration;
    float timer;
    float strength;
    List<AttackEffectDelegate> activeEffects;
    float impulseForce;
    Vector2 impulseOrigin;
    
    Transform ownertransform;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider>();
        collider.enabled = false;
        activeEffects = new List<AttackEffectDelegate>();
        activeEffects.Capacity = 5;
        ownertransform = transform.parent;
        if(ownertransform == null)
            ownertransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < activeDuration)
        {
            timer += Time.deltaTime;

            if(timer > startOffset)
                collider.enabled = true;
        }
        else
        {
            collider.enabled = false;
            resetValues();
        }
    }

    /// <summary>
    /// enable collider with attacker's strength and the duration of animation. call after impulse and add effect
    /// </summary>
    public void SetColliderValues(float duration, float strength, float start = 0)
    {
        this.strength = strength;
        activeDuration = duration;
        startOffset = start;
        timer = 0;
    }

    /// <summary>
    /// passing Idamageable Functions to an Idamagable class in the hopes that they call it on themselves. I hope this works. 
    /// see Idamageable class for available functions, the individual IDamage classes will each have their own implementation
    public void addDamageEffect(AttackEffectDelegate effect)
    {
        activeEffects.Add(effect);
    }


    /// <summary>
    /// pass vector2.zero to use the collider's position, instead of the players
    /// </summary>
    /// <param name="impulseStrength"></param>
    /// <param name="ImpulseCenter"></param>
    public void AddImpulse(float impulseStrength, Vector2 ImpulseCenter)
    {
        impulseForce = impulseStrength;
        impulseOrigin = ImpulseCenter;
        if(ImpulseCenter == Vector2.zero )
        {
            impulseOrigin = new Vector2(transform.position.x, transform.position.z);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        IDamageable damageable = other.gameObject.GetComponent<IDamageable>();
        if (damageable != null)
        {
            //used to nudge the enemy with out grabbing exact locations
            Vector2 attackDir = (other.transform.position.x <= ownertransform.position.x) ? Vector2.left : Vector2.right;

            //send damage info
            damageable.TakeDamage(strength, attackDir);

            //possibly send impulse info
            if(impulseForce != 0)
            {
                Vector2 otherPos = new Vector2(other.transform.position.x, other.transform.position.z);
                damageable.AddImpulse((otherPos - impulseOrigin).normalized * impulseForce); 
            }

           //possibly send other damage effect info
            if(activeEffects.Count > 0)
            {
                damageable.AddDamageEffects(activeEffects);
            }
        }

    }

    private void resetValues()
    {
        impulseForce = 0;

        if (activeEffects != null)
        {
            activeEffects.Clear();
        }
    }

    private void OnDisable()
    {
        resetValues();
    }

}
