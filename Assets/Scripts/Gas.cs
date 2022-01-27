//////////////////////////////
//// Name: Andrew Dahlman-Oeth
//// Date: 1/19/22
//// Desc: Decreases amount of gas as time passes
//////////////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Gas : MonoBehaviour
{
    public string PlayScene;
    public float max;
    public float min;
    public float current;
    public Image mask;
    void Start()
    {
        StartCoroutine(DecreaseGas(0.1f));
    }

    void FixedUpdate()
    {
        GetFill();

    }

    public void AddGas(float amount)
    {
        if(amount + current > max)
        {
            current = max;
        }
        else
        {
            current += amount;
        }

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
        if(current < 0)
        {
            SceneManager.LoadScene(PlayScene);
        }
        current -= 0.1f;
        yield return new WaitForSecondsRealtime(wait);
        StartCoroutine(DecreaseGas(wait));
    }
}
