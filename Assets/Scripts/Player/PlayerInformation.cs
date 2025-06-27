using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInformation : InformationVir
{
    [Header("Link")]
    public PlayerCenter playerCenter;

    [Header("Body")]
    public Transform HandRight;

    [Header("Check")]
    public bool CheckGround = false;

    [Header("Movement")]
    public float CurrentSpeed = 7f;
    public float WalkingSpeed = 7f;
    public float MaxSpeed = 14f;

    [Header("Jump")]
    public float JumpForce = 7f;
    public int NumberOfJumps = 2;

    public override void Start()
    {
        base.Start();
        this.CurrentSpeed = this.WalkingSpeed;
    }

    public void _Setup()
    {
        this.playerCenter.gameObject.SetActive(true);
    }
}
