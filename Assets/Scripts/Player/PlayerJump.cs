using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public PlayerCenter playerCenter;
    private PlayerInformation playerInformation;
    private bool jump = false;
    private float timerDelayJump = 0f;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) this.jump = true;
        _Jump_Activate();
        if (this.timerDelayJump >= 0f) this.timerDelayJump -= Time.deltaTime;
    }
    public void _Jump_Button()
    {
        this.jump = true;
    }
    private void _Jump_Activate()
    {
        if (this.jump && this.timerDelayJump <= 0f)
        {
            _Jump();
            this.timerDelayJump = 0.4f;
        }
    }
    private void _Jump()
    {
        this.jump = false;
        if (this.playerInformation == null) this.playerInformation = this.playerCenter.playerInformation;
        if (this.playerInformation.CheckGround) this.playerInformation.NumberOfJumps = 2;
        this.playerInformation.NumberOfJumps -= 1;
        if (this.playerInformation.NumberOfJumps < 0) return;
        this.playerInformation.myBody.AddForce(new Vector3(0, this.playerInformation.JumpForce, 0), ForceMode.Impulse);
    }
}
