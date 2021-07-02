using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

  public GameObject[] enemyPrefabs;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  public void SpawnEnemy(Vector3 spawnPosition, int rotationAngle, int enemyIndex)
  {
    // Spawn Position
    // Limit to 180 degrees north of playbable area for rnow
    // Spawn Rotation
    // Limit to 90 degrees for now

    GameObject enemy = enemyPrefabs[enemyIndex];
    Quaternion spawnAngle = enemy.transform.rotation * Quaternion.Euler(0, 0, rotationAngle + 180);

    Instantiate(enemy, spawnPosition, spawnAngle);
  }

}
