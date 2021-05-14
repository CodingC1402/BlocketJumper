using System.Collections;
using System.IO;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class UISetting
{
    [Range(0, 100)]
    public int size = 50;
    [Range(0, 100)]
    public int transparence = 100;
    public float currentPosX;
    public float currentPosY;
}