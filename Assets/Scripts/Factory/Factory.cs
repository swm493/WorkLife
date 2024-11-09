using AYellowpaper.SerializedCollections;
using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Factory<T> : MonoBehaviour where T : Enum
{
    [SerializedDictionary("Type", "Prefabs")]
    public SerializedDictionary<T, GameObject> _prefabs = new();
    private Dictionary<T, Queue<GameObject>> _pooling = new();

    private void Awake()
    {
        foreach (T t in Enum.GetValues(typeof(T)))
        {
            _pooling[t] = new();
        }
    }

    protected virtual GameObject CreateObject(T t)
    {
        GameObject newObject = Instantiate(_prefabs[t]);

        newObject.gameObject.SetActive(false);
        newObject.transform.SetParent(transform);
        return newObject;
    }

    public virtual void DeleteObject(GameObject gameObject, T t)
    {
        _pooling[t].Enqueue(gameObject);
        gameObject.SetActive(false);
        gameObject.transform.SetParent(transform);
    }

    public virtual GameObject GetObject(T t)
    {
        GameObject gameObj = (_pooling[t].Count == 0) ? CreateObject(t) : _pooling[t].Dequeue();

        gameObj.transform.SetParent(null);

        return gameObj;
    }
}