using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DamageDisplay : MonoBehaviour
{
   
    TextMeshProUGUI text;
    const float fadeTime = 1.5f;
    float timer;
    Color textColor;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        textColor.r = 1;
    }
    private void Update()
    {
        if(timer >= 0 )
            timer -= Time.deltaTime;
        else
        {
            gameObject.SetActive(false);
        }
        textColor.a = timer/fadeTime;
        text.color = textColor;
    }

    public void SetDamage(int damage)
    {
        text.enabled = true;
        text.SetText(damage.ToString());
        timer = fadeTime;
    }
}
