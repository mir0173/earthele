using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movecamera : MonoBehaviour
{
    public Camera camera;  
    private float size = 1000f;            
    private float theta = 180f;

    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            theta += 1f;
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            theta -= 1f;
        }
        if(Input.GetKey(KeyCode.DownArrow) && size <= 1980)
        {
            size += 20f;
        }
        if(Input.GetKey(KeyCode.UpArrow) && size >= 120)
        {
            size -= 20f;
        }
        camera.transform.position = new Vector3(size * Mathf.Sin(theta * Mathf.Deg2Rad), 0f, size * Mathf.Cos(theta * Mathf.Deg2Rad));
        camera.transform.rotation = Quaternion.Euler(0f, theta + 180f, 0f);
    }
}
