using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelecter : MonoBehaviour
{
    public Animator _anim;
    private int baseLayerIndex = 0;
    private int selectLayerIndex = 1;
    void Start()
    {

    }

    // Update is called once per frame
    public void ChangeAmim(bool ischange)
    {
        float baseLayer = _anim.GetLayerWeight(baseLayerIndex);
        float selectLayer = _anim.GetLayerWeight(selectLayerIndex);
        if (ischange)
        {
            _anim.SetLayerWeight(selectLayerIndex,selectLayer);
        }
    }
}
