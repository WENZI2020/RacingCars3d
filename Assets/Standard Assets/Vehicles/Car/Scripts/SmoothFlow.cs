using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFlow : MonoBehaviour
{
    private Transform target;
    private float height = 3;
    private float distance = -6;
    private float smoothSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Car").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 meForward = this.transform.forward;
        Vector3 targetTranForward = target.forward;
        meForward.y = 0;
        targetTranForward.y = 0;
        Vector3 forward = Vector3.Lerp(meForward.normalized, targetTranForward.normalized, smoothSpeed * Time.deltaTime);
        this.transform.position = forward * distance + Vector3.up * height + target.position;
        this.transform.LookAt(target);
    }
}
