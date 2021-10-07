using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MageAttackBehaviour : PlayerAttackBehaviour
{
    [SerializeField]
    ObjectPool attackPool;
    [SerializeField]
    Transform attackSpawn;

    [SerializeField]
    float impulseStrength = 50f;
    [SerializeField]
    float bscDmgMod = 0.5f;
    [SerializeField]
    float spellSpeed = 15f;

    public override void OnBasicAttack(InputAction.CallbackContext context)
    {
        if (context.started && inputDelayTimer <= 0)
        {
            inputDelayTimer = inputDelay;

            anim.SetFloat("AttackSpeed", attackSpeed);
            anim.SetTrigger("Attack");
            GameObject fireball = attackPool.GetPooledObject();
            if(fireball != null)
            { 
                fireball.SetActive(true);
                fireball.transform.position = attackSpawn.position;
                attackCollider collider = fireball.GetComponent<attackCollider>();

                collider.addDamageEffect(AttackEffect.Burn);
                collider.SetColliderValues(100, stats.Magic * bscDmgMod);

                projectileCollider projectile = fireball.GetComponent<projectileCollider>();
                Vector3 projectileVelocity = (attackSpawn.position - transform.position) * spellSpeed;
                projectileVelocity.y = 0;
                projectile.setVelocity(projectileVelocity);

                OnTurnEnd(false);
            }
        }
    }

    public override void OnDefend(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            defending = true;
            anim.SetBool("Defending", true);
            OnTurnEnd(false);
        }
    }

    public override void OnSpecial1(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            OnTurnEnd(false);
        }
    }

    public override void OnSpecial2(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            OnTurnEnd(false);
        }
    }

}

