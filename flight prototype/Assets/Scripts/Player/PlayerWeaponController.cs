using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponController : MonoBehaviour
{

  public GameObject projectilePrefab;
  private float timer;

  public void FireProjectiles(float fireRate)
  {
    timer += Time.deltaTime;

    if (timer > fireRate)
    {
      GameObject pooledProjectile = PlayerObjectPooler.SharedInstance.GetPooledObject();
      if (pooledProjectile != null)
      {
        pooledProjectile.SetActive(true); // activate it
        pooledProjectile.transform.position = transform.position; // position it at player
      }
      timer = 0;
    }
  }
}
