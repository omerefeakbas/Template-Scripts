using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour
{
    public static Transition Instance;

    private void Awake()
    {
        Instance = this;
    }
    
    [SerializeField] AnimationCurve curveDefault = new AnimationCurve();

    private void OnValidate()
    {
        if (curveDefault.length == 0)
        {
            curveDefault = AnimationCurve.EaseInOut(0, 0, 1, 1);
        }
    }
    
    //Function that lets you run IEnumarator funtion by refference from another scripts
    public void Move(Transform moveThis, Transform toThis, float delay, float time)
    {
        StartCoroutine(_Move(moveThis, toThis, delay, time));
    }
    
    
    //IEnumerator Function for moving from one transform to another one that you desire
    public IEnumerator _Move(Transform moveThis, Transform toThis, float delay, float time)
    {
        if (delay > 0)
            yield return new WaitForSeconds(delay);
        float passed = 0f;
        float rate = 0f;
        Vector3 initPos = moveThis.position;
        Quaternion initRot = moveThis.rotation;

        while (passed < time)
        {
            passed += Time.deltaTime;
            rate = curveDefault.Evaluate(passed / time);

            moveThis.position = Vector3.LerpUnclamped(initPos, toThis.position, rate);
            moveThis.rotation = Quaternion.LerpUnclamped(initRot, toThis.rotation, rate);
            yield return null;
        }
    }
    
    
    

}
