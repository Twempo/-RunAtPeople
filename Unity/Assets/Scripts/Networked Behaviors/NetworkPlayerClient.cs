using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkPlayerClient : NetworkBehaviour {
    public GameObject Boof;
    public GameObject Goon;
    public GameObject Head;

    public PlayerController playerController;

    private void Awake() {
        
    }
}
