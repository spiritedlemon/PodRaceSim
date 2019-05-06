using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camActivate : MonoBehaviour
{
    public GameObject cam;
    public bool first;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(first) //only first pod each lap - var reset elsewhere (event manager)
        {
            StartCoroutine(Activate());
            first = false;
        }
            
    }

    IEnumerator Activate()
    {
        cam.GetComponent<Camera>().enabled = true;
        yield return new WaitForSeconds(3.0f);
        cam.GetComponent<Camera>().enabled = false;

    }
}
