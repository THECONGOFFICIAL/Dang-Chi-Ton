using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public Animator anim;
    private PlayerCenter playerCenter;
    [SerializeField] private Animation Attack1Anim, Attack2Anim, Attack3Anim;
    [SerializeField] private float Damage, CritDamage = 1.2f, TimeDelayAttack = 0.3f;
    private int ChangeAttackAnim = 1;
    private float DelayAttack, ResetAnimationHit;
    private void Update()
    {
        if (this.ResetAnimationHit < 0) this.ResetAnimationHit -= Time.deltaTime;
        if (this.DelayAttack > 0) this.DelayAttack -= Time.deltaTime;
    }
    public virtual void _Attack()
    {
        if (this.DelayAttack > 0) return;
        if (this.ResetAnimationHit <= 0) this.ChangeAttackAnim = 1;

        if (this.ChangeAttackAnim == 1) this._Combo_Attack(2, TimeDelayAttack, "Attack 1");
        else if (this.ChangeAttackAnim == 2) this._Combo_Attack(3, TimeDelayAttack, "Attack 2");
        else this._Combo_Attack(1, TimeDelayAttack, "Attack 3");
    }
    private void _Combo_Attack(int ChangeAttackAnim,float DelayAttack, string AnimAttack)
    {
        this.ChangeAttackAnim = ChangeAttackAnim;
        this.ResetAnimationHit = 5f;
        this.DelayAttack = DelayAttack;
        this.anim.SetTrigger(AnimAttack); //Animation attack

        this.playerCenter.NotMoveAnimation = true;
    }
    public virtual void _Setup(Animator anim, PlayerCenter playerCenter)
    {
        this.anim = anim;
        this.playerCenter = playerCenter;
    }
}
