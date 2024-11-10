using System.Collections.Generic;
using EnumData;
using NUnit.Framework;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public SightColor sightColor = SightColor.Black;
    public DataManager dataManager;
    public GameObject Player
    {
        set
        {
            _player = value;
        }
        get
        {
            Assert.IsNotNull(_player);
            return _player;
        }
    }
    private GameObject _player;

    public FactoryManager factoryManager;
}