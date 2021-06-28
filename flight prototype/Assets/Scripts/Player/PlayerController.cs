using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

  // Gameplay Variables
  public float speed = 5.0f;
  // public float powerupDuration = 5.0f;

  // State Managers

  // Map Boundaries
  private float maxHeight = 3.5f;
  private float maxWidth = 6.5f;

  // Movement Variables
  private float VerticalInput;
  private float HorizontalInput;
  private Vector3 lastMoveDirection;

  // Components and GameObjects
  private Rigidbody playerRb;
  public GameObject projectilePrefab;

  // Start is called before the first frame update
  void Start()
  {
    playerRb = GetComponent<Rigidbody>();
  }

  // Update is called once per frame
  void Update()
  {
    HandleMovement();
  }

  void HandleMovement()
  {
    // Player Input and movement
    HorizontalInput = Input.GetAxis("Horizontal");
    VerticalInput = Input.GetAxis("Vertical");
    transform.Translate(Vector3.right * HorizontalInput * Time.deltaTime * speed);
    transform.Translate(Vector3.up * VerticalInput * Time.deltaTime * speed);

    // Move direction
    lastMoveDirection = new Vector3(HorizontalInput, 0, VerticalInput).normalized;

    // Keep player in bounds on the X axis
    if (transform.position.x < (-maxWidth))
    {
      transform.position = new Vector3((-maxWidth), transform.position.y, transform.position.z);
    }

    if (transform.position.x > maxWidth)
    {
      transform.position = new Vector3(maxWidth, transform.position.y, transform.position.z);
    }

    // Keep player in bounds in the Y axis
    if (transform.position.y < (-maxHeight))
    {
      transform.position = new Vector3(transform.position.x, -maxHeight, transform.position.z);
    }

    if (transform.position.y > maxHeight)
    {
      transform.position = new Vector3(transform.position.x, maxHeight, transform.position.z);
    }
  }

  // void OnTriggerEnter(Collider other)
  // {
  //   if (other.CompareTag("Powerup"))
  //   {
  //     hasPowerup = true;
  //     Destroy(other.gameObject);
  //     StartCoroutine(PowerupCooldownRoutine());
  //   }
  // }
}
