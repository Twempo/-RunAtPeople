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

    private void Awake() {

    }

    static int numPlayers = 0;

    [ClientRpc]
    void RpcSetPlayerNo(int num) {
        numPlayers = num;
    }
}
