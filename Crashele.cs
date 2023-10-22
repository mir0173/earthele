using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crashele : MonoBehaviour
{
    private float myscale;
    private float scale;
    private int a, b, c;
    public GameObject gameObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        myscale = gameObject.transform.localScale.x;
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject collidedObject = collision.gameObject;

        if (collidedObject.CompareTag("Sun"))
        {
            scale = Mathf.Pow(Mathf.Pow(collidedObject.transform.localScale.x, 3f) + Mathf.Pow(myscale, 3f), 0.33333f);
            collidedObject.transform.localScale = new Vector3(scale, scale, scale);
            collidedObject.GetComponent<Rigidbody>().mass = Mathf.Pow(scale, 2.5f);
        }

        if (collidedObject.CompareTag("orb"))
        {
            if(collidedObject.transform.localScale.x > myscale)
            {
                ContactPoint contact = collision.contacts[0];
                Vector3 pos = contact.point;
                scale = Mathf.Pow(Mathf.Pow(collidedObject.transform.localScale.x, 3) + Mathf.Pow(myscale, 3), 0.33333f);
                collidedObject.transform.localScale = new Vector3(scale, scale, scale);
                collidedObject.GetComponent<Rigidbody>().mass = Mathf.Pow(scale, 2.5f);
                collidedObject.GetComponent<Rigidbody>().AddForce((pos * collidedObject.GetComponent<Rigidbody>().mass / (collidedObject.GetComponent<Rigidbody>().mass + gameObject.GetComponent<Rigidbody>().mass)), ForceMode.Force);
                Destroy(gameObject);
            }
        } 
    }
}

