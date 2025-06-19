using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCenter : MonoBehaviour
{
    [Header("Links")]
    public PlayerInformation playerInformation;
    public PlayerMovement playerMovement;
    private void Awake()
    {
        this.playerMovement = GetComponent<PlayerMovement>();
        this.playerMovement.playerCenter = this;
    }
}
