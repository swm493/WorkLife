using System;
using EnumData;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public SightColor sightColor = SightColor.Black;
    public GameObject MainCharacter;
}