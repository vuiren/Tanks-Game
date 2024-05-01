using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameScore : MonoBehaviour
{
    public int player1Score, player2Score = 0;
    [SerializeField] private TextMeshProUGUI player1ScoreText, player2ScoreText;
    // Start is cal led before the first frame update
    void Start()
    {
        if(FindObjectsOfType<GameScore>().Length > 1){
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Update() {
        player1ScoreText.text = player1Score.ToString();
        player2ScoreText.text = player2Score.ToString();
    }

    public void AddScore(int amount, bool toPlayer2){
        if(toPlayer2){
            player2Score += amount;
        }else{
            player1Score += amount;
        }
    }
}
