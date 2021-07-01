using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnWeaponController : BaseEnemyWeaponController
{
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  public void FireProjectiles(float fireRate)
  {
    timer += Time.deltaTime;

    if (timer > fireRate)
    {
      GameObject pooledProjectile = EnemyObjectPooler.SharedInstance.GetPooledObject();
      if (pooledProjectile != null)
      {
        pooledProjectile.SetActive(true); // activate it
        pooledProjectile.transform.position = transform.position; // position it at enemy weapon
        pooledProjectile.transform.rotation = transform.rotation; // rotate it based on enemy weapon
      }
      timer = 0;
    }
  }
}
