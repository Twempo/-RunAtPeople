using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void StartGame() {
        SceneManager.LoadSceneAsync(3);
        Debug.Log("LoadingScene");
        Destroy(this);
    }

    public void EndCharSelect(Color p1, Color p2, PlayerController.Character char1, PlayerController.Character char2) {
        PlayerPrefs.SetFloat("P1.R", p1.r);
        PlayerPrefs.SetFloat("P1.G", p1.g);
        PlayerPrefs.SetFloat("P1.B", p1.b);
        PlayerPrefs.SetFloat("P2.R", p2.r);
        PlayerPrefs.SetFloat("P2.G", p2.g);
        PlayerPrefs.SetFloat("P2.B", p2.b);

        string char1Name, char2Name;
        switch(char1) {
            case PlayerController.Character.Boof:
                char1Name = "Boof";
                break;
            case PlayerController.Character.Goon:
                char1Name = "Goon";
                break;
            case PlayerController.Character.Kirk:
                char1Name = "Kirk";
                break;
            default:
                char1Name = "";
                break;
        }
        switch (char2) {
            case PlayerController.Character.Boof:
                char2Name = "Boof";
                break;
            case PlayerController.Character.Goon:
                char2Name = "Goon";
                break;
            case PlayerController.Character.Kirk:
                char2Name = "Kirk";
                break;
            default:
                char2Name = "";
                break;
        }

        PlayerPrefs.SetString("P1.Name", char1Name);
        PlayerPrefs.SetString("P2.Name", char2Name);

        SceneManager.LoadSceneAsync(1);
        Debug.Log("LoadingScene");
        Destroy(this);
    }
}
