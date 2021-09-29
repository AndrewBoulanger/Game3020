using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TrainingDummyBehaviour : MonoBehaviour, IDamageable
{
    int maxHealth = 300;
    int health = 1000;
    float defence = 80;
    const int AvgDefence = 65;
    float weight = 40;
    const int AvgWeight = 20;

    Rigidbody rb;
    DamageDisplay display;

    public void AddDamageEffects(List<AttackEffectDelegate> effects)
    {
        foreach(AttackEffectDelegate callEffect in effects)
        {
            callEffect(this); 
        }
    }

    public void AddImpulse(Vector2 impulse)
    {
        rb.AddForce(impulse, ForceMode.VelocityChange);
    }

    public void BurnStatus(IDamageable objectBeingHit)
    {
        throw new System.NotImplementedException();
    }

    public void FrozenStatus(IDamageable objectBeingHit)
    {
        throw new System.NotImplementedException();
    }

    public void LaunchUp(IDamageable objectBeingHit)
    {
        throw new System.NotImplementedException();
    }

    public void StunnedStatus(IDamageable objectBeingHit)
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(float strength, Vector2 impulse)
    {
        int damage = (int)(strength * (AvgDefence / defence));
        health -= damage;
        if(display != null)
        {
            display.gameObject.SetActive(true);
            display.SetDamage(damage);
        }
        rb.AddForce(damage * impulse.normalized, ForceMode.Impulse);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.mass = weight;
        display = GetComponentInChildren<DamageDisplay>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
