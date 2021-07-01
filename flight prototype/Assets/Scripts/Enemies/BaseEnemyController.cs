using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemyController : MonoBehaviour, IDamagable, IKillable
{

  // public variables
  public GameObject enemyWeapon;

  [SerializeField]
  private int health;

  [SerializeField]
  protected float movementSpeed;

  [SerializeField]
  protected int currentHealth;

  [SerializeField]
  protected float fireRate;

  protected void Awake()
  {
    currentHealth = health;
  }

  protected void LateUpdate()
  {
    Killed();
  }

  public void Killed()
  {
    if (currentHealth <= 0)
    {
      Destroy(gameObject);
    }
  }

  public void TakeDamage(int damage)
  {
    currentHealth -= damage;
  }

  // Require Collision Detection
  protected abstract void OnCollisionEnter2D(Collision2D collision);

}
