using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Makeele : MonoBehaviour
{
    [SerializeField]
    private float scale;
    private int full = 200;
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
            scale = (int)Mathf.Pow(Random.Range(1f, 1.7f), 4);
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


    void Update()
    {
       for (int i = 0; i <= full; i++)
        {
            for (int j = 0; j <= full; j++)
            {
                if(rigidbodies[i] != null && rigidbodies[j] != null)
                {
                    Vector3 direction = rigidbodies[i].transform.position - rigidbodies[j].transform.position;
                    distanceSquared = direction.sqrMagnitude;
                    if ( distanceSquared != 0)
                    {
                        forceMagnitude = ( grav * rigidbodies[i].mass * rigidbodies[j].mass) / distanceSquared;
                        Vector3 gravityForce = direction * forceMagnitude; 
                        rigidbodies[j].AddForce(gravityForce / 2 * Time.deltaTime, ForceMode.Force);
                    }
                }
            }
        }
    }
}
