using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class NetworkGameManager : NetworkBehaviour {
    public int LevelBuildIndex = 1;
    public float timeToReset = 0;

    int[] points;

    public Text[] pointsText;

    private void Awake() {
        //SceneManager.LoadSceneAsync(LevelBuildIndex, LoadSceneMode.Additive);
        points = new int[2];
    }

    public void ResetLevel() {
        if (timeToReset <= 0) {
            StartCoroutine(FollowThroughA(SceneManager.UnloadSceneAsync(LevelBuildIndex)));
            timeToReset = 1f;
        }
    }

    private void Update() {
        if (Input.GetAxis("Reset") > 0)
            ResetLevel();
        if (timeToReset > 0)
            timeToReset -= Time.deltaTime;
    }

    public void Win(int playerNo) {
        points[playerNo - 1]++;
        pointsText[playerNo - 1].text = points[playerNo - 1] + "";
        ResetLevel();
    }

    IEnumerator FollowThroughA(AsyncOperation op) {
        while (!op.isDone) {
            yield return new WaitForEndOfFrame();
        }
        SceneManager.LoadSceneAsync(LevelBuildIndex, LoadSceneMode.Additive);
    }
}
