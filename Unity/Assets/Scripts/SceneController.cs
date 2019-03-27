using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void StartGame() {
        SceneManager.LoadSceneAsync(1);
        Debug.Log("LoadingScene");
        Destroy(this);
    }
}
