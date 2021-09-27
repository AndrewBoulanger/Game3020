using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationReceiver : MonoBehaviour
{
    Animator anim;
    Animator[] clothesAnim;
    private void Awake()
    {
        clothesAnim = GetComponentsInChildren<Animator>();
    }

    public void SetFloat(string AnimId, float val)
    {
        foreach(Animator child in clothesAnim)
        {
            child.SetFloat(AnimId, val);
        }
    }

    public void SetBool(string AnimId, bool isTrue)
    {
        foreach (Animator child in clothesAnim)
        {
            child.SetBool(AnimId, isTrue);
        }
    }
    public void SetTrigger(string AnimId)
    {
        foreach (Animator child in clothesAnim)
        {
            child.SetTrigger(AnimId);
        }
    }
}
