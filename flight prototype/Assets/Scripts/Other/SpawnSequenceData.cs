using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSequenceData
{
  List<SpawnSequencerDataType> WaveOneData;
  List<SpawnSequencerDataType> WaveTwoData;
  List<SpawnSequencerDataType> WaveThreeData;
  List<SpawnSequencerDataType> WaveFourData;
  List<SpawnSequencerDataType> WaveFiveData;
  List<SpawnSequencerDataType> WaveSixData;

  List<List<SpawnSequencerDataType>> FullSequenceData;

  public SpawnSequenceData()
  {
    List<SpawnSequencerDataType> waveOneData = new List<SpawnSequencerDataType>();
    List<SpawnSequencerDataType> waveTwoData = new List<SpawnSequencerDataType>();
    List<SpawnSequencerDataType> waveThreeData = new List<SpawnSequencerDataType>();
    List<SpawnSequencerDataType> waveFourData = new List<SpawnSequencerDataType>();
    List<SpawnSequencerDataType> waveFiveData = new List<SpawnSequencerDataType>();
    List<SpawnSequencerDataType> waveSixData = new List<SpawnSequencerDataType>();

    List<List<SpawnSequencerDataType>> fullSequenceData = new List<List<SpawnSequencerDataType>>();

    WaveOneData = waveOneData;
    WaveTwoData = waveTwoData;
    WaveThreeData = waveThreeData;
    WaveFourData = waveFourData;
    WaveFiveData = waveFiveData;
    WaveSixData = waveSixData;

    FullSequenceData = fullSequenceData;
  }

  public void InitializeDataStorage()
  {
    FullSequenceData.Add(WaveOneData);
    FullSequenceData.Add(WaveTwoData);
    FullSequenceData.Add(WaveThreeData);
    FullSequenceData.Add(WaveFourData);
    FullSequenceData.Add(WaveFiveData);
    FullSequenceData.Add(WaveSixData);

    foreach (var item in FullSequenceData)
    {
      item.Add(null);
      item.Add(null);
      item.Add(null);
      item.Add(null);
      item.Add(null);
      item.Add(null);
    }
  }

  public void StoreSpawnData(SpawnSequencerDataType data, int wave, int slot)
  {
    FullSequenceData[wave - 1][slot - 1] = data;
    Debug.Log($"This{data}: should have been stored in {FullSequenceData[wave - 1][slot - 1]}");
  }

  public SpawnSequencerDataType AccessSpawnData(int wave, int slot)
  {
    int Wave = wave - 1;
    int Slot = slot - 1;

    if (FullSequenceData[Wave][Slot] != null)
    {
      return FullSequenceData[Wave][Slot];
    }
    else
    {
      Debug.Log("This is an empty slot");
      return null;
    }
  }

  public void LogStorageData(int wave, int slot)
  {
    int Wave = wave - 1;
    int Slot = slot - 1;

    Debug.Log(FullSequenceData.Count);
    Debug.Log(FullSequenceData[Wave]);
    Debug.Log(FullSequenceData[Wave][Slot]);
    Debug.Log(FullSequenceData[Wave][Slot].LogData());
  }

  public List<SpawnSequencerDataType> AccessWaveData(int wave)
  {
    int Wave = wave - 1;

    return FullSequenceData[Wave];
  }

  public IList AccessSequenceData()
  {
    return FullSequenceData;
  }

  public void ResetWaveData(int wave)
  {
    for (int i = 0; i < FullSequenceData[wave - 1].Count; i++)
    {
      FullSequenceData[wave - 1][i] = null;
    }
  }
}
