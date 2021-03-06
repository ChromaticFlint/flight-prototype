using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.EventSystems;

public class SandboxManager : MonoBehaviour
{
  // Player Options
  public Toggle godModeToggle;
  public bool godModeEnabled = true;
  public TMP_Dropdown firePattern;
  public Slider fireRate;

  // Spawn sliders
  public Slider sliderPositionX;
  public Slider sliderPositionY;
  public Slider sliderRotation;
  public Image dialIndicatior;

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
  private SpawnSequenceData spawnSequenceData = new SpawnSequenceData();
  private PlayerController player;

  // Start is called before the first frame update
  void Start()
  {
    spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    player = GameObject.Find("Player").GetComponent<PlayerController>();

    PopulateEnemyTypeDropDown();

    spawnPostionX.text = "0";
    spawnPostionY.text = "5";
    spawnRotation.text = "0";

    seqWaveOneDelay.text = "0";
    seqWaveTwoDelay.text = "0";
    seqWaveThreeDelay.text = "0";
    seqWaveFourDelay.text = "0";
    seqWaveFiveDelay.text = "0";
    seqWaveSixDelay.text = "0";

    spawnSequenceData.InitializeDataStorage();
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

  public void UpdatePlayerFireRate()
  {
    if (player.fireRate != fireRate.value)
    {
      player.fireRate = fireRate.value;
    }
  }

  public void UpdateXField()
  {
    if (int.Parse(spawnPostionX.text) != sliderPositionX.value)
    {
      spawnPostionX.text = sliderPositionX.value.ToString();
    }
  }

  public void UpdateYField()
  {
    if (int.Parse(spawnPostionY.text) != sliderPositionY.value)
    {
      spawnPostionY.text = sliderPositionY.value.ToString();
    }
  }

  public void UpdateRotationField()
  {
    if (int.Parse(spawnRotation.text) != sliderRotation.value)
    {
      spawnRotation.text = sliderRotation.value.ToString();
    }

    Vector3 temp = transform.rotation.eulerAngles;
    temp.z = sliderRotation.value;

    // Update the dial
    dialIndicatior.transform.rotation = Quaternion.Euler(temp);
  }

  public void UpdateXSlider()
  {
    if (sliderPositionX.value != int.Parse(spawnPostionX.text))
    {
      sliderPositionX.value = int.Parse(spawnPostionX.text);
    }
  }

  public void UpdateYSlider()
  {
    if (sliderPositionY.value != int.Parse(spawnPostionY.text))
    {
      sliderPositionY.value = int.Parse(spawnPostionY.text);
    };
  }


  public void UpdateRotationSlider()
  {
    if (sliderRotation.value != int.Parse(spawnRotation.text))
    {
      sliderRotation.value = int.Parse(spawnRotation.text);
    };
  }

  public void SpawnEnemyActivate()
  {
    int posX = ValidateXPosition(spawnPostionX.text);
    int posY = ValidateYPosition(spawnPostionY.text);
    int angle = ValidateRotation(spawnRotation.text);

    Vector3 spawnPos = new Vector3(posX, posY, 0);
    int rotationAngle = angle;

    spawnManager.SpawnEnemy(spawnPos, rotationAngle, getDropDownEnemyIndex());

    SendFieldDataToStorage(1, 1);

    SpawnSequencerDataType test = spawnSequenceData.AccessSpawnData(1, 1);
  }

  // QoL make the button change color when an item is stored. Clear when null
  public void SetFieldsToButton()
  {
    // Button names in "waveX.slotY" e.g. "1.1" format
    string[] splitString = splitButtonName(GetButtonName());

    int wave = Int32.Parse(splitString[0]);
    int slot = Int32.Parse(splitString[1]);

    Debug.Log($"Button - Wave: {wave}, Slot: {slot} was selected");

    SendFieldDataToStorage(wave, slot);

    setButtonActive(GetButtonName());
  }

  public void InvertData()
  {
    Debug.Log("The data inversion button was selected");
    spawnPostionX.text = InvertString(spawnPostionX.text);
    spawnRotation.text = InvertString(spawnRotation.text);
  }

  private string InvertString(string original)
  {
    int placeholder = int.Parse(original);
    placeholder = placeholder * -1;
    string result = placeholder.ToString();

    return result;
  }

  public void SpawnWave()
  {
    // Button names in "SpawnWave.waveNumber" e.g. "SpawnWave.1" format
    string[] splitString = splitButtonName(GetButtonName());

    int wave = Int32.Parse(splitString[1]);

    Debug.Log($"Wave {wave} was spawned");

    foreach (SpawnSequencerDataType item in spawnSequenceData.AccessWaveData(wave))
    {
      if (item != null)
      {
        Vector3 spawnPos = new Vector3(item.GetX(), item.GetY(), 0);

        spawnManager.SpawnEnemy(spawnPos, item.GetRot(), item.GetType());
      }
    }
  }

  public void SpawnWave(int waveNumber)
  {
    int wave = waveNumber;

    Debug.Log($"Wave {wave} was spawned");

    foreach (SpawnSequencerDataType item in spawnSequenceData.AccessWaveData(wave))
    {
      if (item != null)
      {
        Vector3 spawnPos = new Vector3(item.GetX(), item.GetY(), 0);

        spawnManager.SpawnEnemy(spawnPos, item.GetRot(), item.GetType());
      }
    }
  }

  public void SpawnSequence()
  {
    List<int> delays = delayList();
    int wave = 1;

    foreach (IList item in spawnSequenceData.AccessSequenceData())
    {
      StartCoroutine(SpawnWaveWithDelay(delays[wave - 1], wave));
      wave++;
    }
  }

  IEnumerator SpawnWaveWithDelay(int timer, int wave)
  {
    yield return new WaitForSeconds(timer);
    SpawnWave(wave);
  }

  // This currently doesn't reset the wave delays. There may need to be some
  // Re-architecture to make that possible in a clean way.
  public void ResetWave()
  {
    string[] name = splitButtonName(GetButtonName());
    int wave = int.Parse(name[1]);

    Debug.Log($"The following wave was reset: {wave}");

    spawnSequenceData.ResetWaveData(wave);

    for (int i = 1; i < 7; i++) {
      string ButtonName = $"{wave.ToString()}.{i.ToString()}";
      setButtonInactive(ButtonName);
    }
  }

  private void setButtonActive(string buttonName) {
    GameObject.Find(buttonName).GetComponent<Image>().color = Color.green;
  }

  private void setButtonInactive(string buttonName) {
    GameObject.Find(buttonName).GetComponent<Image>().color = Color.white;
  }

  private string GetButtonName()
  {
    return EventSystem.current.currentSelectedGameObject.name;
  }

  private string[] splitButtonName(string buttonName)
  {
    return buttonName.Split('.');
  }

  private SpawnSequencerDataType CreateSpawnDataFromFields()
  {
    SpawnSequencerDataType data = new SpawnSequencerDataType(
      ValidateXPosition(spawnPostionX.text),
      ValidateYPosition(spawnPostionY.text),
      ValidateRotation(spawnRotation.text),
      getDropDownEnemyIndex()
    );

    return data;
  }

  private void SendFieldDataToStorage(int wave, int slot)
  {
    SpawnSequencerDataType data = CreateSpawnDataFromFields();
    spawnSequenceData.StoreSpawnData(data, wave, slot);
  }

  public SpawnSequencerDataType getFieldDataFromStorage(int wave, int slot)
  {
    return spawnSequenceData.AccessSpawnData(wave, slot);
  }

  private int ValidateXPosition(string text)
  {
    int posX = Int32.Parse(text);

    if (Math.Abs(posX) > 8)
    {
      posX = 0;
      spawnPostionX.text = posX.ToString();
    }

    return posX;
  }

  private int ValidateYPosition(string text)
  {
    int posY = Int32.Parse(spawnPostionY.text);

    if (posY <= 0 || posY >= 5)
    {
      posY = 5;
      spawnPostionY.text = posY.ToString();
    }

    return posY;
  }

  private int ValidateRotation(string text)
  {
    int angle = Int32.Parse(spawnRotation.text);

    if (angle < -90 || angle > 90)
    {
      angle = 0;
      spawnRotation.text = angle.ToString();
    }

    return angle;
  }

  private void PopulateEnemyTypeDropDown()
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

  private List<int> delayList()
  {
    List<int> delays = new List<int>();

    delays.Add(int.Parse(seqWaveOneDelay.text));
    delays.Add(int.Parse(seqWaveTwoDelay.text));
    delays.Add(int.Parse(seqWaveThreeDelay.text));
    delays.Add(int.Parse(seqWaveFourDelay.text));
    delays.Add(int.Parse(seqWaveFiveDelay.text));
    delays.Add(int.Parse(seqWaveSixDelay.text));

    return delays;
  }
}
