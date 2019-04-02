using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Colorer : MonoBehaviour {
    public Image p1;
    public Image p2;

    void Start()
    {
        p1.color = new Color(PlayerPrefs.GetFloat("P1.R"), PlayerPrefs.GetFloat("P1.G"), PlayerPrefs.GetFloat("P1.B"));
        p2.color = new Color(PlayerPrefs.GetFloat("P2.R"), PlayerPrefs.GetFloat("P2.G"), PlayerPrefs.GetFloat("P2.B"));
    }
}
