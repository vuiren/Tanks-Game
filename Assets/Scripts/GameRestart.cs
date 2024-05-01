using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRestart : MonoBehaviour
{
    [SerializeField] private PlayerReset player1, player2;
    [SerializeField] private Transform playersRespawns;

    GameState gameState;

    private void Start() {
        gameState = FindObjectOfType<GameState>();
    }

    public void Restart(){
        player1.ResetPlayer(playersRespawns.GetChild(0));
        player2.ResetPlayer(playersRespawns.GetChild(1));
        StartCoroutine(AssDelay());
       // gameState.isGameOver = false;
    }

    private IEnumerator AssDelay(){
        yield return new WaitForEndOfFrame();
        gameState.isGameOver = false;
    }
}
