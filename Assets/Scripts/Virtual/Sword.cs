using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public Animator anim;
    private PlayerCenter playerCenter;
    [SerializeField] private Animation Attack1Anim, Attack2Anim, Attack3Anim;
    [SerializeField] private float Damage, CritDamage = 1.2f, ResetAnimationHit;
    float RangeAttack;
    private int ChangeAttackAnim = 1;
    private void Update()
    {
        if (this.ResetAnimationHit < 0) this.ResetAnimationHit -= Time.deltaTime;
    }
    public virtual void _Attack()
    {
        if (this.ResetAnimationHit <= 0) this.ChangeAttackAnim = 1;
        if (this.ChangeAttackAnim == 1) this._Attack1();
        else if (this.ChangeAttackAnim == 2) this._Attack2();
        else this._Attack3();
    }
    private void _Attack1()
    {
        this.ChangeAttackAnim = 2;
        this.ResetAnimationHit = 5f;
        this.anim.SetTrigger("Attack 1"); //Animation attack
    }
    private void _Attack2()
    {
        this.ChangeAttackAnim = 3;
        this.ResetAnimationHit = 5f;
        this.anim.SetTrigger("Attack 2"); //Animation attack
    }
    private void _Attack3()
    {
        this.ChangeAttackAnim = 1;
        this.anim.SetTrigger("Attack 3"); //Animation attack
    }
    public virtual void _Setup(Animator anim, PlayerCenter playerCenter)
    {
        this.anim = anim;
        this.playerCenter = playerCenter;
    }
}
