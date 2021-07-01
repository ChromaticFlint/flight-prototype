using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SandboxManager : MonoBehaviour
{

  public Toggle godModeToggle;
  public bool godModeEnabled = true;

  public Button testSpawnEnemy;

  private SpawnManager spawnManager;

  // Start is called before the first frame update
  void Start()
  {
    spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
  }

  // Update is called once per frame
  void Update()
  {

  }

  public void GodModeToggle()
  {
    if (godModeEnabled)
    {
      godModeEnabled = false;
    }
    else
    {
      godModeEnabled = true;
    }
  }

  public void SpawnEnemyActivate()
  {
    Vector3 spawnPos = new Vector3(0, 5, 0);
    int rotationAngle = 20;

    spawnManager.SpawnEnemy(spawnPos, rotationAngle, 0);
  }
}
