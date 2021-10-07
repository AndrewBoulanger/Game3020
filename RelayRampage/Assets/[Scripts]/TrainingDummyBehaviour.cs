using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TrainingDummyBehaviour : MonoBehaviour, IDamageable
{
    int maxHealth = 300;
    int health = 500;
    float defence = 80;
    const int AvgDefence = 65;
    float weight = 40;
    const int AvgWeight = 20;

    bool isBurning = false;
    int effectFrameDuration = 1200;
    int frameCounter = 0;
    int burnFrequency = 120;
    int burnDamage = 5;

    bool isDead;

    [SerializeField]
    BattleSceneManager sceneManager;

    Rigidbody rb;
    DamageDisplay display;

    Animator anim;

    public void AddDamageEffects(List<AttackEffect> effects)
    {
        foreach (AttackEffect callEffect in effects)
        {
            if (callEffect == AttackEffect.LaunchUp)
                LaunchUp();
            else if(callEffect == AttackEffect.Burn)
                BurnStatus();
            else if(callEffect == AttackEffect.Freeze)
                FrozenStatus();
            else if(callEffect == AttackEffect.Stun)
                StunnedStatus();
        }
    }

    public void AddImpulse(Vector2 impulse)
    {
        rb.AddForce(impulse, ForceMode.VelocityChange);
    }

    public void BurnStatus()
    {
        isBurning = true;
        frameCounter = 0;
    }

    public void FrozenStatus()
    {
        throw new System.NotImplementedException();
    }

    public void LaunchUp()
    {
        throw new System.NotImplementedException();
    }

    public void StunnedStatus()
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

        anim.SetTrigger("hit");

        if(health <= 0)
        {
            anim.SetBool("dead", true);
           // rb.constraints = RigidbodyConstraints.None;
            frameCounter = 0;
            isDead = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.mass = weight;
        display = GetComponentInChildren<DamageDisplay>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isBurning)
        {
            frameCounter++;
            if(frameCounter % burnFrequency == 0)
                TakeDamage(burnDamage, Vector2.up);
            if(frameCounter >= effectFrameDuration)
                isBurning = false;
        }
        if(isDead)
        {
            frameCounter++;
            if(frameCounter > 260)
            {
               sceneManager.LoadPreviousScene();
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (rb.velocity.sqrMagnitude > 20)
        {

            TakeDamage(50, Vector3.zero);
        }
    }
}
