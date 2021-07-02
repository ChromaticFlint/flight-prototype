using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class SandboxManager : MonoBehaviour
{

  public Toggle godModeToggle;
  public bool godModeEnabled = true;

  public TMP_InputField spawnPostionX;
  public TMP_InputField spawnPostionY;
  public TMP_InputField spawnRotation;
  public TMP_Dropdown spawnType;

  public Button testSpawnEnemy;

  private SpawnManager spawnManager;

  // Start is called before the first frame update
  void Start()
  {
    spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    PopulateEnemyTypeDropDown();

    spawnPostionX.text = "0";
    spawnPostionY.text = "5";
    spawnRotation.text = "0";
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
    // TODO add validation for text
    int posX = Int32.Parse(spawnPostionX.text);
    int posY = Int32.Parse(spawnPostionY.text);
    int angle = Int32.Parse(spawnRotation.text);

    if (Math.Abs(posX) > 8)
    {
      posX = 0;
      spawnPostionX.text = posX.ToString();
    }

    if (posY <= 0 || posY >= 5)
    {
      posY = 5;
      spawnPostionY.text = posY.ToString();
    }

    if (angle < -90 || angle > 90)
    {
      angle = 0;
      spawnRotation.text = angle.ToString();
    }

    Vector3 spawnPos = new Vector3(posX, posY, 0);
    int rotationAngle = angle;

    spawnManager.SpawnEnemy(spawnPos, rotationAngle, getDropDownEnemyIndex());
  }


  void PopulateEnemyTypeDropDown()
  {
    List<string> enemyTypes = new List<string>();

    foreach (var item in spawnManager.enemyPrefabs)
    {
      enemyTypes.Add(item.name);
    }

    spawnType.ClearOptions();
    spawnType.AddOptions(enemyTypes);
  }

  private int getDropDownEnemyIndex()
  {
    string enemyName = spawnType.options[spawnType.value].text;
    return spawnType.options.FindIndex((i) => { return i.text.Equals($"{enemyName}"); });
  }
}
