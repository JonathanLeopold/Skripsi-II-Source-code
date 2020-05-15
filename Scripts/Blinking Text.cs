using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingText : MonoBehaviour
{
    public Text text;
    void Start()
    {
        text = GetComponent<Text>();
        StartBlinking();
    }

    IEnumerator Blink(){
        while (true)
        {
            text.text = "420fps";
            yield return new WaitForSeconds(1f);
            text.text = "42069fps";
            yield return new WaitForSeconds(1f);
        }
    }
    void StartBlinking(){

        StartCoroutine("Blink");
    }
    void StopBlinking()
    {
        StopCoroutine("Blink");
    }
    void Update()
    {

    }

}
