using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gas : MonoBehaviour
{
    public float max;
    public float min;
    public float current;
    public Image mask;

    void Start()
    {
        StartCoroutine(DecreaseGas(0.01f));
    }

    void Update()
    {
        GetFill();

    }

    void GetFill()
    {
        float currOffset = current - min;
        float maxOffset = max - min;
        float fill = currOffset / maxOffset;
        mask.fillAmount = fill;
    }

    IEnumerator DecreaseGas(float wait)
    {
        current -= 0.01f;
        yield return new WaitForSecondsRealtime(wait);
        StartCoroutine(DecreaseGas(wait));
    }
}
