using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReset : MonoBehaviour
{
    [SerializeField] private GameObject tower, towerRb;
    
    [SerializeField] private PlayerState playerState;
    [SerializeField] private CharacterController controller;
    [SerializeField] private Transform towerRbSpawn;

    public void ResetPlayer(Transform spawnPoint){
        tower.SetActive(true);
        towerRb.transform.position = towerRbSpawn.position;
        var rb= towerRb.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        controller.enabled = false;
        controller.transform.position = spawnPoint.position;
        controller.transform.rotation = spawnPoint.rotation;
        tower.transform.localRotation = Quaternion.Euler(-90, 0,0);
        playerState.isMoving = false;
        playerState.BodyRotation = spawnPoint.eulerAngles;
        playerState.HeadRotation = tower.transform.rotation.eulerAngles;
        //Debug.Break();
        towerRb.SetActive(false);
        controller.enabled = true;
    }
}
