using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankShooting : MonoBehaviour
{
    [SerializeField] private PlayerState playerState;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float delay = 0.5f;

    public int maxProjectilesCount = 1;

    private List<GameObject> bullets = new List<GameObject>();

    private float timeBeforeNextShot;
    // Start is called before the first frame update
    void Start()
    {
        playerState = GetComponentInParent<PlayerState>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw(playerState.player2 ? "FireP2" : "FireP1") > 0.1){
            if( timeBeforeNextShot > 0) return;
            if(bullets.Count >= maxProjectilesCount) return;
            var bullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
            bullet.GetComponentInChildren<Rigidbody>().AddForce(spawnPoint.forward * 50, ForceMode.Impulse);
            //bullet.GetComponentInChildren<Rigidbody>().AddRelativeTorque(spawnPoint.up * 25, ForceMode.Impulse);
            var projectile = bullet.GetComponent<Projectile>();
            projectile.shotByPlayer2 = playerState.player2;
            projectile.SubToOnDestroy(()=>{
                bullets.Remove(bullet);
            });
            timeBeforeNextShot= delay;
            bullets.Add(bullet);
        }

        if(timeBeforeNextShot > 0) timeBeforeNextShot -= Time.deltaTime;
    }
}
