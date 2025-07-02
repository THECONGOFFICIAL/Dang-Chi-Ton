using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [Header("Link")]
    public PlayerCenter playerCenter;

    [SerializeField] private LayerMask GroundMask;
    [SerializeField] FloatingJoystick floatingJoystick;
    private float ver, hor;
    private void Update()
    {
        _Check_Ground();
        _Input();
        LimitSpeedPlayer();
    }
    private void FixedUpdate()
    {
        _Movement();
    }
    private void _Check_Ground()
    {
        this.playerCenter.playerInformation.CheckGround = Physics.Raycast(transform.position, Vector3.down, 1.25f, GroundMask);
    }
    private void _Input()
    {
        if (this.playerCenter.uiStatus.UI_Mobile.activeSelf)
        {
            this.ver = this.floatingJoystick.Vertical;
            this.hor = this.floatingJoystick.Horizontal;
        }
        else
        {
            this.ver = Input.GetAxisRaw("Vertical");
            this.hor = Input.GetAxisRaw("Horizontal");
        }
    }
    private void _Movement()
    {
        Vector3 move = this.playerCenter.Cam1.transform.forward * ver + this.playerCenter.Cam1.transform.transform.right * hor;
        this.playerCenter.playerInformation.myAnim.SetFloat("Speed", this.playerCenter.playerInformation.myBody.velocity.magnitude);
        _Rotatation(move);
        if (this.playerCenter.playerInformation.CheckGround)
        {
            this.playerCenter.playerInformation.myBody.drag = 7f;
            this.playerCenter.playerInformation.myBody.AddForce(move.normalized * Time.deltaTime * 2000f * this.playerCenter.playerInformation.CurrentSpeed, ForceMode.Force);
        }
        else
        {
            this.playerCenter.playerInformation.myBody.drag = 1f;
            this.playerCenter.playerInformation.myBody.AddForce(move.normalized * Time.deltaTime * 2000f * 0.25f * this.playerCenter.playerInformation.CurrentSpeed, ForceMode.Force);
        }
    }
    private void LimitSpeedPlayer()
    {
        Vector3 checkVelocity = new Vector3(this.playerCenter.playerInformation.myBody.velocity.x, 0, this.playerCenter.playerInformation.myBody.velocity.z);
        if (checkVelocity.magnitude > this.playerCenter.playerInformation.CurrentSpeed)
        {
            Vector3 limitSpeed = checkVelocity.normalized * this.playerCenter.playerInformation.CurrentSpeed;
            this.playerCenter.playerInformation.myBody.velocity = new Vector3(limitSpeed.x, this.playerCenter.playerInformation.myBody.velocity.y, limitSpeed.z);
        }
    }
    private void _Rotatation(Vector3 rotate)
    {
        if(this.ver != 0 || this.hor != 0)
        {
            if (this.playerCenter.playerInformation.CheckGround)
            {
                if(this.playerCenter.NotMoveAnimation) {
                    this.playerCenter.playerInformation.myAnim.SetTrigger("Return Move");
                    this.playerCenter.NotMoveAnimation = false;
                }
                Quaternion toRotation = Quaternion.LookRotation(rotate, Vector3.up);
                this.playerCenter.playerInformation.transform.rotation = Quaternion.Slerp(this.playerCenter.playerInformation.transform.rotation, toRotation, 10f * Time.deltaTime);
            }
        }
    }
}
