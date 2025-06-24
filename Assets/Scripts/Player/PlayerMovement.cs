using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (this.playerCenter.playerInformation.CheckGround)
        {
            this.playerCenter.playerInformation.myBody.drag = 7f;
            Vector3 move = transform.forward * ver + transform.right * hor;
            this.playerCenter.playerInformation.myBody.AddForce(move * Time.deltaTime * 2000f * this.playerCenter.playerInformation.CurrentSpeed, ForceMode.Force);
            this.playerCenter.playerInformation.myAnim.SetFloat("Speed", this.playerCenter.playerInformation.myBody.velocity.magnitude);
        }
        else
        {
            this.playerCenter.playerInformation.myBody.drag = 1f;
            Vector3 move = transform.forward * ver + transform.right * hor;
            this.playerCenter.playerInformation.myBody.AddForce(move * Time.deltaTime * 2000f * 0.25f * this.playerCenter.playerInformation.CurrentSpeed, ForceMode.Force);
        }
    }
}
