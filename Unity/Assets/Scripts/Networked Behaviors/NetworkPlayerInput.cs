using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

/**
 * @author Ethan
 * Handles Input from client and sends to server
 */
public class NetworkPlayerInput : NetworkBehaviour {
    public NetworkPlayerController controller;

    private void Update() {
        CmdSendInput(Input.GetAxis("P" + controller.playerControlSpot + ".Jump"));
    }

    /**
     * @param jump - Clients jump Input value from user's keyboard
     * Sends jump Input value to server's NetworkPlayerController linked to this NetworkPlayerInput
     */
    [Command]
    void CmdSendInput(float jump) {
        controller.jumpInput = jump;
    }
}
