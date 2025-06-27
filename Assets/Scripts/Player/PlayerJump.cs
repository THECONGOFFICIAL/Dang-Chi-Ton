using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public PlayerCenter playerCenter;
    private PlayerInformation playerInformation;
    private bool jump = false;
    private float timerDelayJump = 0f;
    private int JumpRightOrLeft = 0;
    private bool ReJump = false;
    private float DelayChangeAnimtion;

    private void Awake()
    {
        if (this.playerInformation == null) this.playerInformation = this.playerCenter.playerInformation;
    }
    private void Update()
    {
        if (this.DelayChangeAnimtion > 0) this.DelayChangeAnimtion -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space)) this.jump = true;
        _Jump_Activate();
        if (this.timerDelayJump >= 0f) this.timerDelayJump -= Time.deltaTime;
        if (this.playerInformation.CheckGround && !this.ReJump && this.DelayChangeAnimtion <= 0f)
        {
            this.playerInformation.myAnim.SetBool("Jump Left", false);
            this.playerInformation.myAnim.SetBool("Jump Right", false);
            this.ReJump = true;
        }
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
            this.timerDelayJump = 0.3f;
        }
    }
    private void _Jump()
    {
        this.ReJump = false;
        this.jump = false;
        if (this.playerInformation.CheckGround)
        {
            this.playerInformation.NumberOfJumps = 2;
            this.JumpRightOrLeft = 0;
        }
        this.playerInformation.NumberOfJumps -= 1;
        if (this.playerInformation.NumberOfJumps < 0) return;
        this.playerInformation.myBody.AddForce(new Vector3(0, this.playerInformation.JumpForce, 0), ForceMode.Impulse);
        _Jump_Animation();
    }
    private void _Jump_Animation()
    {
        this.DelayChangeAnimtion = 0.25f;
        if (this.JumpRightOrLeft == 0)
        {
            this.playerInformation.myAnim.SetBool("Jump Right", true);
            StartCoroutine(_False_Anim(false));
            this.JumpRightOrLeft = 1;
        }
        else
        {
            this.playerInformation.myAnim.SetBool("Jump Left", true);
            StartCoroutine(_False_Anim(true));
            this.JumpRightOrLeft = 0;
        }
    }
    private IEnumerator _False_Anim(bool i)
    {
        yield return new WaitForSeconds(0.1f);
        if (i) this.playerInformation.myAnim.SetBool("Jump Right", false);
        else this.playerInformation.myAnim.SetBool("Jump Left", false);
    }
}
