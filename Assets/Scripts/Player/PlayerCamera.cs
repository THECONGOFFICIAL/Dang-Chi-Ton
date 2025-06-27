using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public PlayerCenter playerCenter;
    [SerializeField] private PlayerTouchCamera playerTouchCamera;
    private Vector2 move;
    private Vector2 rotate;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        _Get_Move();
        _Move_Camera();
        _Camera_FL();
        if (Input.GetKeyDown(KeyCode.BackQuote))
        {
            if (Cursor.visible)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

            }
        }
    }
    private void _Camera_FL()
    {
        this.playerCenter.Cam1.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z);
    }
    private void _Get_Move()
    {
        this.move.x = Input.GetAxis("Mouse Y");
        this.move.y = Input.GetAxis("Mouse X");
    }
    private void _Move_Camera()
    {
        if (this.playerCenter.uiStatus.UI_Mobile.activeSelf)
        {
            this.rotate.x -= this.playerTouchCamera.TouchDist.y * this.playerCenter.uiSetting.SensitivityCamera_Slider.value * Time.deltaTime;
            this.rotate.y += this.playerTouchCamera.TouchDist.x * this.playerCenter.uiSetting.SensitivityCamera_Slider.value * Time.deltaTime;
        }
        else
        {
            this.rotate.x -= move.x * 20f * this.playerCenter.uiSetting.SensitivityCamera_Slider.value * Time.deltaTime;
            this.rotate.y += move.y * 20f * this.playerCenter.uiSetting.SensitivityCamera_Slider.value * Time.deltaTime;
        }
        this.playerCenter.Cam1.transform.localRotation = Quaternion.Euler(0, rotate.y, 0);
        this.playerCenter.Cam2.transform.localRotation = Quaternion.Euler(rotate.x, 0, 0);
    }
}
