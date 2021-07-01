using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SandboxManager : MonoBehaviour
{

  public Toggle godModeToggle;
  public bool godModeEnabled = true;

  // Start is called before the first frame update
  void Start()
  {

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
}
