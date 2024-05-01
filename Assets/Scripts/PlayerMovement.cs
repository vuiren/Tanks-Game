using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private bool Player2 => playerState.player2;
    [SerializeField] private Transform head, body;
    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed = 12f;
    PlayerState playerState;
    GameState gameState;
    // Start is called before the first frame update
    void Start()
    {
        playerState = GetComponentInParent<PlayerState>();
        gameState = FindObjectOfType<GameState>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameState.isGameOver) return;
        var vertical = Player2 ? Input.GetAxis("VerticalP2") : Input.GetAxis("Vertical");
        var viewDirection = body.forward;
        var moveVector =speed * Time.deltaTime * vertical * viewDirection;
        controller.Move(moveVector);

        playerState.movingForward = vertical > 0;
        playerState.movingBackward = vertical < 0;
        playerState.isMoving = moveVector.magnitude > 0;
    }
}
