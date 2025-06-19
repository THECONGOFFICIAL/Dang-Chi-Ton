using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InformationVir : MonoBehaviour
{
    [Header("Componenet")]
    public Rigidbody myBody;
    public Animator myAnim;

    [Header("HP")]
    public float CurrentHp = 0f;
    public float MaxHp = 100f;
    public Image HpBar;
    public virtual void Start()
    {
        this.CurrentHp = this.MaxHp;
        if (this.HpBar != null) this.HpBar.fillAmount = this.CurrentHp / MaxHp;
    }
    public virtual void _Damage_Receiver(float Damage)
    {
        this.CurrentHp -= Damage;
        if (this.HpBar != null) this.HpBar.fillAmount = this.CurrentHp / MaxHp;
    }
}
