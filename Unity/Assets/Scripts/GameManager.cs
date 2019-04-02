using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public int LevelBuildIndex = 2;
    public float timeToReset = 0;
    public GameObject transition;

    int[] points;

    public Text[] pointsText;

    private void Awake() {
        SceneManager.LoadSceneAsync(LevelBuildIndex, LoadSceneMode.Additive);
        points = new int[2];
    }

    public void ResetLevel() {
        if (timeToReset <= 0) {
            transition.SetActive(true);
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
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(FollowThroughB(SceneManager.LoadSceneAsync(LevelBuildIndex, LoadSceneMode.Additive)));
    }

    IEnumerator FollowThroughB(AsyncOperation op) {
        while(!op.isDone) {
            yield return new WaitForEndOfFrame();
        }
        transition.SetActive(false);
        if (points[0] == 21 || points[1] == 21)
            SceneManager.LoadScene(0);
        else
            transition.SetActive(false);
        foreach (PlayerController player in FindObjectsOfType<PlayerController>()) {

        }
    }
}
