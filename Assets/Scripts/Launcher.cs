using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class Launcher : MonoBehaviourPunCallbacks
{
    public PhotonView playerPrefab;
    public Transform spawnPoint;

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Conexión exitosa al servidor maestro");
        PhotonNetwork.JoinRandomOrCreateRoom();
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Instanciando jugador en la sala: " + PhotonNetwork.CurrentRoom.Name);
        PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint.position, spawnPoint.rotation);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("Jugador " + newPlayer.NickName + " ha entrado a la sala");
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log("Jugador " + otherPlayer.NickName + " ha salido de la sala");
    }
}
