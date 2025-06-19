using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInformation : InformationVir
{
    [Header("Link")]
    public PlayerCenter playerCenter;

    [Header("Check")]
    public bool CheckGround = false;

    [Header("Movement")]
    public float CurrentSpeed = 0f;
    public float WalkingSpeed = 7f;
    public float MaxSpeed = 14f;

    public void _Setup()
    {
        this.playerCenter.gameObject.SetActive(true);
    }
}
