using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine;

public class SpawnSequencerDataType
{
  // Move the weak validation from SandboxManager to here later
  int SpawnPositionX { get; set; }
  int SpawnPositionY { get; set; }
  int SpawnRotation { get; set; }
  int SpawnType { get; set; }

  public SpawnSequencerDataType(
    int spawnPostionX,
    int spawnPositionY,
    int spawnRotation,
    int spawnType)
  {
    SpawnPositionX = spawnPostionX;
    SpawnPositionY = spawnPositionY;
    SpawnRotation = spawnRotation;
    SpawnType = spawnType;
  }

  public SpawnSequencerDataType LogData()
  {
    Debug.Log(SpawnPositionX);
    Debug.Log(SpawnPositionY);
    Debug.Log(SpawnRotation);
    Debug.Log(SpawnType);

    return null;
  }

  public int GetX()
  {
    return SpawnPositionX;
  }

  public int GetY()
  {
    return SpawnPositionY;
  }

  public int GetRot()
  {
    return SpawnRotation;
  }

  public int GetType()
  {
    return SpawnType;
  }
}
