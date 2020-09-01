using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TCloneCreator : MonoBehaviour
{

    public GameObject[] TClone;

    // Start is called before the first frame update
    void Start()
    {
        CreateClone();
    }


    public void CreateClone()
    {
        Instantiate(TClone[Random.Range(0, TClone.Length)], transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
