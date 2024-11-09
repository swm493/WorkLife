using EnumData;
using UnityEngine;

public class ColorSystem : MonoBehaviour
{
    public GameObject[] ColorSights;

    private void OnPrevious()
    {
        int idx = (int)GameManager.Instance.sightColor;
        ColorSights[idx].SetActive(false);

        if (idx == 0) idx = ColorSights.Length - 1;
        else idx--;
        ColorSights[idx].SetActive(true);

        GameManager.Instance.sightColor = (SightColor)idx;
    }

    private void OnNext()
    {
        int idx = (int)GameManager.Instance.sightColor;
        ColorSights[idx].SetActive(false);

        if (idx == ColorSights.Length - 1) idx = 0;
        else idx++;
        ColorSights[idx].SetActive(true);

        GameManager.Instance.sightColor = (SightColor)idx;
    }
}