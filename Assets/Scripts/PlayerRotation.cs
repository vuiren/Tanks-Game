using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    private bool Player2 => playerState.player2;
    [SerializeField] private Transform head, body;
    [SerializeField] private float rotationSpeed = 12f, headRotationSpeed = 20f;
    PlayerState playerState;
    GameState gameState;


    
    // Start is called before the first frame update
    void Start()
    {
        playerState = GetComponentInParent<PlayerState>();
        playerState.HeadRotation = head.rotation.eulerAngles;
        playerState.BodyRotation = body.rotation.eulerAngles;

        gameState = FindObjectOfType<GameState>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameState.isGameOver) return;
        var horizontal = Input.GetAxis(playerState.player2 ? "TankBodyRotationPlayer2": "TankBodyRotationPlayer1");
        var vertical = Input.GetAxisRaw(Player2? "VerticalP2" : "Vertical");

        //if(vertical > 0 || vertical < 0){
            {
            var bodyRot = Player2 ? Input.GetAxisRaw("HorizontalP2") : Input.GetAxisRaw("Horizontal");
            if(bodyRot > 0 || bodyRot < 0){
                playerState.HeadRotation.y += bodyRot * headRotationSpeed * Time.deltaTime;
            }
            playerState.BodyRotation.y += bodyRot * rotationSpeed * Time.deltaTime;
            body.rotation = Quaternion.Euler(playerState.BodyRotation);   
        }


        playerState.HeadRotation.y += horizontal * headRotationSpeed * Time.deltaTime;
        head.rotation = Quaternion.Euler(playerState.HeadRotation);
    }
}
