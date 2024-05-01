using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankFloorSticker : MonoBehaviour
{
    [SerializeField] private Transform tankModel;
    [SerializeField] private Transform groundSearch;
    [SerializeField] private LayerMask groundLayer;

    PlayerState playerState;

    private void Start() {
        playerState = GetComponentInParent<PlayerState>();
    }

    private void Update() {
        if(Physics.Raycast(groundSearch.position, Vector3.down, out var hit, 100f, groundLayer)){
            //tankModel.position = new Vector3(tankModel.position.x, hit.point.y, tankModel.position.z);
                        // Get the surface normal
           // Vector3 surfaceNormal = hit.normal;

            // Create a rotation matrix that aligns the GameObject's x-axis with the surface normal
          //  Quaternion rotationMatrix = Quaternion.FromToRotation(transform.forward, surfaceNormal);
           // var finalRotation = rotationMatrix * tankModel.rotation;
           // var oldYRotation = playerState.BodyRotation.y;
           // tankModel.up = hit.normal;
          //  playerState.BodyRotation = finalRotation.eulerAngles;
           // playerState.BodyRotation.y = oldYRotation;
        }
    }

    private void OnDrawGizmosSelected() {
        if(groundSearch == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawRay(groundSearch.position, Vector3.down * 100f);
    }
}
