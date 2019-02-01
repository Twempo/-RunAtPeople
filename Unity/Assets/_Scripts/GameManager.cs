using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public int LevelBuildIndex = 1;
    public float timeToReset = 0;

    private void Awake() {
        SceneManager.LoadSceneAsync(LevelBuildIndex, LoadSceneMode.Additive);
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


    IEnumerator FollowThroughA(AsyncOperation op) {
        while (!op.isDone) {
            yield return new WaitForEndOfFrame();
        }
        StartCoroutine(FollowThroughB(SceneManager.LoadSceneAsync(LevelBuildIndex, LoadSceneMode.Additive)));
    }

    IEnumerator FollowThroughB(AsyncOperation op) {
        while(!op.isDone) {
            yield return new WaitForEndOfFrame();
        }
        foreach (PlayerController player in FindObjectsOfType<PlayerController>()) {

        }
    }
}
