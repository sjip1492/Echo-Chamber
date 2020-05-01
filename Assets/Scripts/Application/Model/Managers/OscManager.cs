using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscManager : PECModel
{
    public OSC osc;

    private void Awake()
    {
        base.Awake();
        osc = FindObjectOfType<OSC>();
    }
}
