using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class SandboxManager : MonoBehaviour
{

  // Player Options
  public Toggle godModeToggle;
  public bool godModeEnabled = true;
  public TMP_Dropdown firePattern;
  public Slider fireRate;

  // Spawn input fields
  public TMP_InputField spawnPostionX;
  public TMP_InputField spawnPostionY;
  public TMP_InputField spawnRotation;
  public TMP_Dropdown spawnType;

  // Spawn Sequencer buttons and fields -- This could probably be more efficient
  public Button[] seqWaveOneStorage;
  public Button seqWaveOneLaunch;
  public InputField seqWaveOneDelay;
  public Button seqWaveOneClear;

  public Button[] seqWaveTwoStorage;
  public Button seqWaveTwoLaunch;
  public InputField seqWaveTwoDelay;
  public Button seqWaveTwoClear;

  public Button[] seqWaveThreeStorage;
  public Button seqWaveThreeLaunch;
  public InputField seqWaveThreeDelay;
  public Button seqWaveThreeClear;

  public Button[] seqWaveFourStorage;
  public Button seqWaveFourLaunch;
  public InputField seqWaveFourDelay;
  public Button seqWaveFourClear;

  public Button[] seqWaveFiveStorage;
  public Button seqWaveFiveLaunch;
  public InputField seqWaveFiveDelay;
  public Button seqWaveFiveClear;

  public Button[] seqWaveSixStorage;
  public Button seqWaveSixLaunch;
  public InputField seqWaveSixDelay;
  public Button seqWaveSixClear;

  // Bottom Buttons
  public Button testSpawnEnemy;
  public Button testSpawnSequence;
  public Button exitToMenu;

  // Componenets
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
