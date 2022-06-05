using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootController : MonoBehaviour
{

    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private float bulletSpeed = 100f;
    private PlayerInputActions playerShootControls;

    // Start is called before the first frame update
    void Awake()
    {

        playerShootControls = new PlayerInputActions();
        playerShootControls.Player.Fire.performed += shootContext => ShootPerformed();

    }

    private void OnEnable()
    {

        playerShootControls.Player.Fire.Enable();

    }

    private void OnDisable()
    {

        playerShootControls.Player.Fire.Disable();

    }

    private void ShootPerformed()
    {
        GameObject newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation) as GameObject;
        Rigidbody bulletRb = newBullet.GetComponent<Rigidbody>();
        bulletRb.velocity = firePoint.forward * bulletSpeed;

    }
}
