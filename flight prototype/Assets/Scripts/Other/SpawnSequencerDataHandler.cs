using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine;

public class SpawnSequencerDataHandler
{
  int SpawnPostitionX { get; set; }
  int SpawnPositionY { get; set; }
  int SpawnRotation { get; set; }
  int SpawnType { get; set; }

  public SpawnSequencerDataHandler(
    int spawnPostionX,
    int spawnPositionY,
    int spawnRotation,
    int spawnType)
  {
    SpawnPostitionX = spawnPostionX;
    SpawnPositionY = spawnPositionY;
    SpawnRotation = spawnRotation;
    SpawnType = spawnType;
  }

  List<SpawnSequencerDataHandler> waveOneData = new List<SpawnSequencerDataHandler>();
  List<SpawnSequencerDataHandler> waveTwoData = new List<SpawnSequencerDataHandler>();
  List<SpawnSequencerDataHandler> waveThreeData = new List<SpawnSequencerDataHandler>();
  List<SpawnSequencerDataHandler> waveFourData = new List<SpawnSequencerDataHandler>();
  List<SpawnSequencerDataHandler> waveFiveData = new List<SpawnSequencerDataHandler>();
  List<SpawnSequencerDataHandler> waveSixData = new List<SpawnSequencerDataHandler>();

  List<List<SpawnSequencerDataHandler>> fullSequenceData = new List<List<SpawnSequencerDataHandler>>();

  public void StoreSpawnData(int wave, int slot)
  {
    fullSequenceData[wave - 1][slot - 1] = this;
  }

  public SpawnSequencerDataHandler accessSpawnData(int wave, int slot)
  {
    if (fullSequenceData[wave - 1][slot - 1] != null)
      return fullSequenceData[wave][slot];
    else
    {
      Debug.Log("This is an empty slot");
      return null;
    }
  }

  public void InitializeDataStorage()
  {
    fullSequenceData.Add(waveOneData);
    fullSequenceData.Add(waveTwoData);
    fullSequenceData.Add(waveThreeData);
    fullSequenceData.Add(waveFourData);
    fullSequenceData.Add(waveFiveData);
    fullSequenceData.Add(waveSixData);
  }
}
