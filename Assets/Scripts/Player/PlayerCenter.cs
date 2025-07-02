using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCenter : MonoBehaviour
{
    [Header("Links")]
    public PlayerInformation playerInformation;
    public PlayerMovement playerMovement;
    public PlayerJump playerJump;
    public PlayerCamera playerCamera;
    public PlayerAttackCtrl playerAttackCtrl;

    [Header("Animation")]
    public bool NotMoveAnimation = false;

    [Header("UI Links")]
    public UiStatus uiStatus;
    public UiSetting uiSetting;

    [Header("Camera")]
    public GameObject Cam1;
    public GameObject Cam2;
    public GameObject Cam3;
    public GameObject Camera;

    private void Awake()
    {
        this.Cam1.transform.SetParent(null);

        this.playerMovement = GetComponent<PlayerMovement>();
        this.playerMovement.playerCenter = this;

        this.playerJump = GetComponent<PlayerJump>();
        this.playerJump.playerCenter = this;

        this.playerCamera = GetComponent<PlayerCamera>();
        this.playerCamera.playerCenter = this;

        this.playerAttackCtrl = GetComponent<PlayerAttackCtrl>();
        this.playerAttackCtrl.playerCenter = this;
    }
}
