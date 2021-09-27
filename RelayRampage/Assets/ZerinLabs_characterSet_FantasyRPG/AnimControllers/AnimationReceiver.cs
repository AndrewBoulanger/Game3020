using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationReceiver : MonoBehaviour
{
    Animator anim;
    Animator[] clothesAnim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        clothesAnim = GetComponentsInChildren<Animator>();
    }

    public void SetFloat(string AnimId, float val)
    {
        anim.SetFloat(AnimId, val);
        foreach(Animator child in clothesAnim)
        {
            child.SetFloat(AnimId, val);
        }
    }

    public void SetBool(string AnimId, bool isTrue)
    {
        anim.SetBool(AnimId, isTrue);
        foreach (Animator child in clothesAnim)
        {
            child.SetBool(AnimId, isTrue);
        }
    }
    public void SetTrigger(string AnimId)
    {
        anim.SetTrigger(AnimId);
        foreach (Animator child in clothesAnim)
        {
            child.SetTrigger(AnimId);
        }
    }
}
