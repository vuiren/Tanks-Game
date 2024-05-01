using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GusRotator : MonoBehaviour
{
    [SerializeField] private Renderer[] renderers;
    [SerializeField] private float rotSpeed;
    PlayerState playerState;
    
    // Start is called before the first frame update
    void Start()
    {
        playerState = GetComponentInParent<PlayerState>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerState.isMoving){
            foreach(var renderer in renderers){
                renderer.materials[0].SetTextureOffset("_BaseMap", new Vector2(0, playerState.movingForward? Time.time * rotSpeed: Time.time * -rotSpeed));
            }
        }
    }
}
