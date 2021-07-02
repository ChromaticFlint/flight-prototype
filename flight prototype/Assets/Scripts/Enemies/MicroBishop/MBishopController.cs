using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MBishopController : BaseEnemyController
{
  new void Awake()
  {
    // Sets health to current health
    base.Awake();
  }

  new void LateUpdate()
  {
    // Death Trigger and Movement Style
    base.LateUpdate();
    MovementStyle();
  }

  protected override void OnCollisionEnter2D(Collision2D collision)
  {

    if (collision.gameObject.CompareTag("Player Bullet"))
    {
      collision.gameObject.SetActive(false);
      currentHealth -= 1;
    }
  }

  void MovementStyle()
  {
    transform.Translate(Vector3.up * Time.deltaTime * movementSpeed);
  }
}
