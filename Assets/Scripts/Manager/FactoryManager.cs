using UnityEngine;

public class FactoryManager : MonoBehaviour
{
    private void Awake()
    {
        GameManager.Instance.factoryManager = this;
    }
    public BulletFactory bulletFactory;
    public EnemyFactory enemyFactory;
}