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
    Vector3 Pos;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        textColor.r = 1;
        Pos = transform.localPosition;
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
        transform.localPosition = new Vector3(Pos.x + Random.Range(0f,1.1f), Pos.y + Random.Range(0f,1.1f));
        text.enabled = true;
        text.SetText(damage.ToString());
        timer = fadeTime;
    }
}
