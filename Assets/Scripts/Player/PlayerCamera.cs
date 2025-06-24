using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public PlayerCenter playerCenter;
    [SerializeField] private PlayerTouchCamera playerTouchCamera;
    private Vector2 move;
    private Vector2 rotate;
    private void Update()
    {
        _Get_Move();
        _Move_Camera();
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
        this.playerCenter.Cam1.transform.localRotation = Quaternion.Euler(rotate.x, rotate.y, 0);
    }
}
