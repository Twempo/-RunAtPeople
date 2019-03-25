using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleInator : MonoBehaviour
{
    public float flipSpeed;

    float timeToFlip = 0;

    Vector3 A = new Vector3(0, 0, 45);
    Vector3 B = new Vector3(0, 0, -45);
    
    void Update()
    {
        timeToFlip -= Time.deltaTime;
        if(timeToFlip<=0) {
            timeToFlip = 1 / flipSpeed;
            transform.rotation = Quaternion.Euler((transform.rotation.eulerAngles == A) ?  B : A);
        }
    }
}
