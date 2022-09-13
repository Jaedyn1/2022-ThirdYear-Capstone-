using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSystem : MonoBehaviour
{
    public int dammage;
    public float timebetweenShooting, Spread, range, relodeTime, timebetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonhold;
    int bulletsLeft, bulletsshot;

    //bools
    bool shooting, readyToShoot, reloading;

    //references
    public Camera fpsCam;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;
    private void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }
    private void Update()
    {
        Myinput();
    }
    private void Myinput() 
    {
        if (allowButtonhold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) reload();

        //shoot
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0) 
        {
            bulletsshot = bulletsPerTap;
            Shoot();
        }
    }
    private void Shoot() 
    {
        readyToShoot = false;

        //Spread
        float x = Random.Range(-Spread, Spread);
        float y = Random.Range(-Spread, Spread);

        //Calculate Direction with spread
        Vector3 direction = fpsCam.transform.forward + new Vector3(x, y, 0);

        
        //Raycast
        if(Physics.Raycast(fpsCam.transform.position,direction,out rayHit, range,whatIsEnemy))
        {

            Debug.Log(rayHit.collider.name);

            if (rayHit.collider.CompareTag("Enemy")) //enemy must have the tag
            { 
            // rayHit.collider.GetComponent
            }
        }
        bulletsLeft--;
        bulletsshot--;

        Invoke("ResetShot", timebetweenShooting);
        if (bulletsLeft > 0 && bulletsLeft > 0) ;
        Invoke("Shoot", timebetweenShots);
    }
    private void ResetShot() 
    {
        readyToShoot = true;
    }

    private void reload() 
    {
        reloading = true;
        Invoke("ReloadFinished", relodeTime);
    }
    private void Reloadfinished() 
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }
}
