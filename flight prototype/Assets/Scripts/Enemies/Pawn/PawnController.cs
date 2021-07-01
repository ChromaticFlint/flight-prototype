using UnityEngine;

public class PawnController : BaseEnemyController, iPathable
{

  private PawnWeaponController pawnWeapon;

  new void Awake()
  {
    // Sets health to current health
    base.Awake();
    pawnWeapon = GameObject.Find("PawnWeapon").GetComponent<PawnWeaponController>();
  }

  new void LateUpdate()
  {
    // Death Trigger and Movement Style
    base.LateUpdate();
    pawnWeapon.FireProjectiles(fireRate);
  }

  protected override void OnCollisionEnter2D(Collision2D collision)
  {

    if (collision.gameObject.CompareTag("Player Bullet"))
    {
      collision.gameObject.SetActive(false);
      TakeDamage(1);
    }
  }

  void MovementStyle()
  {
    transform.Translate(Vector3.up * Time.deltaTime * movementSpeed);
  }

  public void FlightPattern()
  {
    throw new System.NotImplementedException();
  }
}
