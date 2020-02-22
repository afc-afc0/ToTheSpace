using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BasicTurret : TurretBase
{
    void Start()
    {
        startHealth = health;
    }
}