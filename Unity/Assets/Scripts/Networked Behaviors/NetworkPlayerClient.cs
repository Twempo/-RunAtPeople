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
        Boof.SetActive(true);
        Head.SetActive(true);
    }

    private void Update() {
        
    }

    static int numPlayers = 0;

    [Command]
    void CmdAddPlayer(NetworkPlayerClient client) {
        numPlayers++;
        RpcUpdateNumPlayers(numPlayers);
        RpcSetPlayerNum(numPlayers);
    }

    [ClientRpc]
    void RpcUpdateNumPlayers(int newNum) {
        numPlayers = newNum;
    }

    [ClientRpc]
    void RpcSetPlayerNum(int num) {
        playerController.playerNo = num;
    }
}
