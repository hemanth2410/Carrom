using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    bool cueLocked;
    public bool CueLocked { get { return cueLocked; } }
    public event Action<Vector3, float> ApplyForce;
    public event Action EnableCue;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindAnyObjectByType<GameManager>();
            }
            return instance;
        }
    }
    public void ToggleCueLockState()
    {
        cueLocked = !cueLocked;
    }
    public void InvokeForceApplied(Vector3 forceDirection, float force)
    {
        ApplyForce?.Invoke(forceDirection, force);
    }
    public void InvokeEnableCue()
    {
        EnableCue?.Invoke();
    }
}
