using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private PlayerManager playerManager; //take the inputs from the player
    public WeaponData weaponData;

    public Camera cam;
    public Transform attackPoint;

    public bool allowInvoke = true;

    private void Start() {
        weaponData.bulletsLeft = weaponData.magazineSize;
        weaponData.readyToShoot = true;
        playerManager = GetComponentInParent<PlayerManager>();
    }

    private void Update() {
        shootInput();
    }

    private void shootInput(){
        if(weaponData.allowButtonHold) weaponData.shooting = playerManager.shoot.IsPressed();
        else weaponData.shooting = playerManager.shoot.WasPerformedThisFrame();

        if(playerManager.reload.IsPressed() && weaponData.bulletsLeft < weaponData.magazineSize && !weaponData.reloading) Reload();
        if(weaponData.readyToShoot && weaponData.bulletsLeft <= 0 && !weaponData.reloading) Reload();

        if(weaponData.readyToShoot && weaponData.shooting && !weaponData.reloading && weaponData.bulletsLeft > 0){
            weaponData.bulletShot = 0;
            Shoot();
        }
    }

    private void Shoot(){
        weaponData.readyToShoot = false;

        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        Vector3 targetPoint;
        if(Physics.Raycast(ray, out hit)){
            targetPoint = hit.point;
        }else {
            targetPoint = ray.GetPoint(75);
        }

        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        float x = Random.Range(-weaponData.spread, weaponData.spread);
        float y = Random.Range(-weaponData.spread, weaponData.spread);

        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x,y,0);

        GameObject currentBullet = Instantiate(weaponData.bullet, attackPoint.position, Quaternion.identity);
        currentBullet.transform.forward = directionWithSpread.normalized;

        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * weaponData.shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(cam.transform.up * weaponData.upwardForce, ForceMode.Impulse);

        weaponData.bulletsLeft--;
        weaponData.bulletShot++;

        if(allowInvoke){
            Invoke("ResetShoot", weaponData.timeBetweenShooting);
            allowInvoke = false;
        }
    }

    private void ResetShoot(){
        weaponData.readyToShoot = true;
        allowInvoke = true;
    }

    private void Reload()
    {
        weaponData.reloading = true;
        Invoke("ReloadFinished", weaponData.reloadTime); 
    }
    private void ReloadFinished()
    {
        weaponData.bulletsLeft = weaponData.magazineSize;
        weaponData.reloading = false;
    }
}
