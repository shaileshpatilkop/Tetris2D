using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{

    float prevtime;
    public float fallDowntime;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(prevtime);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);
        }



        Debug.Log(Time.time + "time");
        if (Time.time - prevtime > fallDowntime)
        {
            transform.position += new Vector3(0, -1, 0);
            prevtime = Time.time;
        }
    }
}
