using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    PlayerState playerState;
    [SerializeField] private GameObject tower, towerRb;
    [SerializeField] private float restartDelay = 1f;

    GameRestart gameRestart;
    GameScore gameScore;
    NextMapLoader nextMapLoader;
    public bool IsPlayer2 => playerState.player2;
    Coroutine delayRoutine;
    GameState gameState;

    private void Start()
    {
        playerState = GetComponentInParent<PlayerState>();
        gameRestart = FindObjectOfType<GameRestart>();
        gameState = FindObjectOfType<GameState>();
        nextMapLoader = FindObjectOfType<NextMapLoader>();
        gameScore = FindObjectOfType<GameScore>();
    }

    public void Explode()
    {
        tower.SetActive(false);
        towerRb.transform.rotation = Quaternion.Euler(towerRb.transform.eulerAngles.x, tower.transform.eulerAngles.y, towerRb.transform.eulerAngles.z);
        towerRb.SetActive(true);
        var rb = towerRb.GetComponent<Rigidbody>();
        rb.AddForce(Vector3.up * 50, ForceMode.Impulse);

        if (delayRoutine == null){
            gameState.isGameOver = true;
            gameScore.AddScore(1, !playerState.player2);
            delayRoutine = StartCoroutine(RestartDelay());
        }
    }

    private IEnumerator RestartDelay()
    {
        yield return new WaitForSeconds(restartDelay);
       // gameRestart.Restart();
       nextMapLoader.LoadNextMap();
        delayRoutine = null;
    }
}
