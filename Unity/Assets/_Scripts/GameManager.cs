using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public Scene Level;

    private void Awake() {
        SceneManager.LoadScene(Level.buildIndex);
    }

    public void ResetLevel() {
         SceneManager.UnloadSceneAsync(Level.buildIndex);
    }

    IEnumerator FollowThroughA(AsyncOperation op) {
        while (!op.isDone) {
            yield return new WaitForEndOfFrame();
        }
        StartCoroutine(FollowThroughB(SceneManager.LoadSceneAsync(Level.buildIndex)));
    }

    IEnumerator FollowThroughB(AsyncOperation op) {
        while(!op.isDone) {
            yield return new WaitForEndOfFrame();
        }
        foreach (PlayerController player in FindObjectsOfType<PlayerController>()) {

        }
    }
}
