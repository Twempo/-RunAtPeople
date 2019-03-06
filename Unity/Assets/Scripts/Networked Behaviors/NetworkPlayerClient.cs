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

    }

    private void Update() {
        
    }

    static int numPlayers = 0;

    [ClientRpc]
    void RpcSetPlayerNumAndSpot(int num, int spot) {
        numPlayers = num;
        playerController.playerNo = num;
        playerController.playerControlSpot = spot;
    }
}
