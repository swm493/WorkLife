using System.Collections.Generic;
using EnumData;

public class GameManager : MonoSingleton<GameManager>
{
    public SightColor sightColor = SightColor.Black;
    public DataManager dataManager;
}