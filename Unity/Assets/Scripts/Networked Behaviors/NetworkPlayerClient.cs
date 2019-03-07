using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkPlayerClient : NetworkBehaviour {
    public GameObject Boof;
    public GameObject Goon;
    public GameObject Head;

    public NetworkPlayerController playerController;
    public NetworkPlayerInput playerInput;

    public bool spotChosen = false;
    public bool lookingForSpot = true;

    private void Awake() {
        CmdAddPlayer(this);
        playerInput.controller = playerController;
    }

    private void Update() {
        
    }

    static int numPlayers = 0;

    [Command]
    void CmdAddPlayer(NetworkPlayerClient client) {
        numPlayers++;
        RpcUpdateNumPlayers(numPlayers);
        RpcSetPlayerNumAndSpot(numPlayers);
    }

    [ClientRpc]
    void RpcUpdateNumPlayers(int newNum) {
        numPlayers = newNum;
    }

    [ClientRpc]
    void RpcSetPlayerNumAndSpot(int num, int spot) {
        playerController.playerNo = num;
        playerController.playerControlSpot = spot;
    }

    [ClientRpc]
    void RpcSetPlayerNumAndSpot(int num) {
        playerController.playerNo = num;
        playerController.playerControlSpot = num;
    }
}
