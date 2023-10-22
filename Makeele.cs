using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Makeele : MonoBehaviour
{
    [SerializeField]
    private float scale;
    private int full = 25;
    private float grav = 6.67430f;
    float forceMagnitude;
    float distanceSquared;
    public GameObject sun;
    public GameObject element;
    public List<GameObject> Elementlist = new List<GameObject>();
    public List<Rigidbody> rigidbodies = new List<Rigidbody>();

    void Awake()
    {
        for(int i = 0; i < full; i++)
        {
            GameObject elementPref = Instantiate(element) as GameObject;
            elementPref.transform.position = Random.insideUnitSphere * 400f;
            scale = Mathf.Pow(Random.Range(0.8f, 1.1f), 4);
            elementPref.transform.localScale = new Vector3(scale, scale, scale);
            elementPref.GetComponent<Rigidbody>().mass = Mathf.Pow(scale, 2.7f);

            Elementlist.Add(elementPref);
            rigidbodies.Add(elementPref.GetComponent<Rigidbody>());
        }
        Elementlist.Add(sun);
        rigidbodies.Add(sun.GetComponent<Rigidbody>());
    }


    void Start()
    {
        
    }


    void FixedUpdate()
    {
        sun.transform.Rotate(new Vector3(0, 1, 0), 2.4f * Time.deltaTime);
       for (int i = 0; i <= full; i++)
        {
            for (int j = 0; j <= full; j++)
            {
                if(rigidbodies[i] != null && rigidbodies[j] != null)
                {
                    rigidbodies[i].transform.Rotate(new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)), 0.1f * Time.deltaTime);
                    Vector3 direction = rigidbodies[i].transform.position - rigidbodies[j].transform.position;
                    distanceSquared = direction.sqrMagnitude;
                    if ( distanceSquared != 0)
                    {
                        forceMagnitude = ( grav * rigidbodies[i].mass * rigidbodies[j].mass) / distanceSquared;
                        Vector3 Force = direction * forceMagnitude;
                        Vector3 gravityForce = new Vector3(Force.x * 1, Force.y * Mathf.Pow(Mathf.Abs(rigidbodies[j].transform.position.y), 0.2f), Force.z * 1);
                        rigidbodies[j].AddForce(gravityForce / 2 * Time.deltaTime, ForceMode.Force);
                    }
                }
            }
        }
    }
}

