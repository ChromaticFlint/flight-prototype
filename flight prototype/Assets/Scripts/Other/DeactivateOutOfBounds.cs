using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateOutOfBounds : MonoBehaviour
{
  private float topBound = 10;
  private float lowerBound = -6;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if (transform.position.y > topBound)
    {
      gameObject.SetActive(false);
    }

    if (transform.position.y < lowerBound)
    {
      gameObject.SetActive(false);
    }
  }
}
