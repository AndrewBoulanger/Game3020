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
    const int AvgWeight = 65;

    Rigidbody rb;

    public void AddDamageEffects(List<AttackEffectDelegate> effects)
    {
        foreach(AttackEffectDelegate callEffect in effects)
        {
            callEffect(this); 
        }
    }

    public void AddImpulse(Vector2 impulse)
    {

        rb.AddForce(impulse);
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

    public void TakeDamage(float strength)
    {
        int damage = (int)(strength * (AvgDefence / defence));
        health -= damage;
        print(health);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.mass = weight;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
