using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkPlayerInput : NetworkBehaviour {
    public NetworkPlayerController controller;

    private void Update() {
        CmdSendInput(Input.GetAxis("P" + controller.playerNo + ".Jump"));
    }

    [Command]
    void CmdSendInput(float jump) {
        controller.jumpInput = jump;
    }
}
