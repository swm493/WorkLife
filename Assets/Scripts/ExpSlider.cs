using System.Collections;
using EnumData;
using UnityEngine;

public class ExpSlider : MonoBehaviour
{
    public SightColor sightColor;
    public int MaxValue = 10;
    public int MinValue = 0;
    public float Value
    {
        set
        {
            _value = value;
            float scale = _value / MaxValue;
            transform.localScale = new(scale, scale, scale);
        }
        get { return _value; }
    }
    private float _value = 0;

    Coroutine _coroutine = null;

    public void ApplyExpImage()
    {
        _coroutine ??= StartCoroutine(ExpAnimation());
    }

    IEnumerator ExpAnimation()
    {
        while ((Value - GameManager.Instance.dataManager.ExpValue[sightColor]) > 0.01f)
        {
            Value = Mathf.Lerp(_value, GameManager.Instance.dataManager.ExpValue[sightColor], 0.01f);
            yield return null;
        }
        Value = GameManager.Instance.dataManager.ExpValue[sightColor];

        _coroutine = null;
    }
}
