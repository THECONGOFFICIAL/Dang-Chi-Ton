using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackCtrl : MonoBehaviour
{
    public PlayerCenter playerCenter;
    private Sword sword;

    private void Start()
    {
        _Setup();
    }
    private void Update()
    {
        _Input();
    }
    public void _Input()
    {
        if (Input.GetMouseButtonDown(0)) _Attack_Button();
    }
    public void _Setup()
    {
        if (this.sword == null) foreach (Transform i in this.playerCenter.playerInformation.HandRight) if (i != null) this.sword = i.GetComponent<Sword>();
        if (this.sword != null) this.sword._Setup(this.playerCenter.playerInformation.myAnim, this.playerCenter);
    }
    public void _Attack_Button()
    {
        if (this.playerCenter.playerInformation.CheckGround == false) return;
        if (this.sword == null) _Setup();
        if (this.sword != null) if (this.sword.gameObject.activeSelf) this.sword._Attack();
    }
    public void _Skill1_Button()
    {

    }
}