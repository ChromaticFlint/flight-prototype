using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnProjectileController : MonoBehaviour
{
  [SerializeField]
  private float speed = 1.0f;


  // Start is called before the first frame update
  void Awake()
  {
  }

  // Update is called once per frame
  void Update()
  {
    ProjectilePattern();
  }

  void ProjectilePattern()
  {
    transform.Translate(Vector3.down * Time.deltaTime * speed);
  }
}
