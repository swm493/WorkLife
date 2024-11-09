using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance = null;

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = Instantiate(Resources.Load<T>("@" + typeof(T).Name));
                DontDestroyOnLoad(instance.gameObject);
            }
            return instance;
        }
    }

    private void OnDisable()
    {
        instance = null;
    }
}