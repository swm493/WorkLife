using EnumData;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private void Awake()
    {
        GameManager.Instance.dataManager = this;
    }
    public Dictionary<SightColor, int> ExpValue = new();
}
