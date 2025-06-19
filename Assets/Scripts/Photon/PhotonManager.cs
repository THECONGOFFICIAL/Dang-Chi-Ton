using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PhotonManager : MonoBehaviourPunCallbacks
{
    private void Awake()
    {
        Debug.Log("Đang kết nối...");
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("Đã kết nối");
        PhotonNetwork.JoinLobby();
    }
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        Debug.Log("Vào Lobby");
        PhotonNetwork.JoinOrCreateRoom("Game", null, null);
    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("Vào game");
        GameObject player = PhotonNetwork.Instantiate("Player/Player Prefab", transform.position, Quaternion.identity);
        player.GetComponent<PlayerInformation>()._Setup();
    }
}