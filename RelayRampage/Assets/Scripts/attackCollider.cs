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
    

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider>();
        collider.enabled = false;
        activeEffects = new List<AttackEffectDelegate>();
        activeEffects.Capacity = 5;
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
        }
    }

    /// <summary>
    /// enable collider with attacker's strength and the duration of animation. call after impulse and add effect
    /// </summary>
    /// <param name="duration"></param>
    /// <param name="strength"></param>
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
    /// </summary>
    /// <param name="effect"></param>
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
            //send damage info
            damageable.TakeDamage(strength);

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
