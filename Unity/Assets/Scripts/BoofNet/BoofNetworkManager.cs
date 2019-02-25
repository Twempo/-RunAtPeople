using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace BoofNet {
    [AddComponentMenu("BoofNet/BoofNetworkManager")]
    public class BoofNetworkManager : MonoBehaviour {
        private static INetworkTransport s_ActiveTransport = (INetworkTransport)new DefaultNetworkTransport();

    }
}