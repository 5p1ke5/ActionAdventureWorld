using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Globals
{
    #region player variables

    public static Vector3 spawnPos = new Vector3(0, 0, 0);
    public static int playerMaxHP = 3;
    public static int playerHP = playerMaxHP;
    public static Boolean[] crystalsCollected = { false, false, false, false };
    #endregion

    #region story flags
    public static Boolean metTheMayor = false;
    #endregion
}