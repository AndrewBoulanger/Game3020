using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnIndicatorEffects : MonoBehaviour
{
    [SerializeField]
    float riseSpeed = 8.0f;
    [SerializeField]
    float maxHeight = 2f;
    [SerializeField]
    float minHeight = 0.5f;
    bool stopRising = false;

    Vector3 UpdatingScale = new Vector3(1.3f,0,1.3f);

    private void OnEnable()
    {
        transform.localScale = new Vector3(1.3f,0.01f,1.3f);
        
    }
  
    // Start is called before the first frame update
    void Awake()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(stopRising == false)
            UpdatingScale.y += riseSpeed * Time.deltaTime;
        else
            UpdatingScale.y = Mathf.Lerp(UpdatingScale.y, minHeight, 0.1f);

        if(UpdatingScale.y > maxHeight)
            stopRising = true;
        if(UpdatingScale.y <=  minHeight + 0.015f)
            stopRising = false;

        transform.localScale = UpdatingScale;
    }
}
