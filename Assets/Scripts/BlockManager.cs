using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BlockManager : MonoBehaviour
{

    float prevtime;
    public float fallDowntime;  
    public static int width = 10;
    public static int hight = 20;
    public Vector3 t_Rotationpoint;
    private static Transform[,] t_Grid = new Transform[width, hight];


   



    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(prevtime);
    }

    bool CheckAboveGrid(Transform transform )
    {
        for (int i = 0; i < width; ++i)
        {
            foreach (Transform obj in transform)
            {
                Vector3 pos = obj.position;
                if (pos.y > hight - 3)
                {
                    return true;
                }
            }
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);
            if (!Isvalidmove())
                transform.position -= new Vector3(-1, 0, 0);
        }

        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);
            if (!Isvalidmove())
                transform.position -= new Vector3(1, 0, 0);
        }

        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.RotateAround(transform.TransformPoint(t_Rotationpoint), new Vector3(0, 0, 1), 90);
            if (!Isvalidmove())
                transform.RotateAround(transform.TransformPoint(t_Rotationpoint), new Vector3(0, 0, 1), -90);

        }


        //Debug.Log(Time.time + "time");
        if (Time.time - prevtime > (Input.GetKey(KeyCode.DownArrow)?fallDowntime/ 10 : fallDowntime))
        {
            transform.position += new Vector3(0, -1, 0);
            if (!Isvalidmove())
            {
                transform.position -= new Vector3(0, -1, 0);
                GridUpdate();
                CheckLines();

                if (CheckAboveGrid(transform))
                {
                    Gameover();
                }
                this.enabled = false;
                FindObjectOfType<TCloneCreator>().CreateClone();

            }

                prevtime = Time.time;
        }

        //GameManager.UpdateScore();
       // scorePlanel.text = curruntScore.ToString();
    }


    void CheckLines()
    {
        for (int i = hight - 1; i >= 0; i--)
        {
            if (HasLine(i))
            {
                RemoveLine(i);
                RowDown(i);
            }
        }
    }

    bool HasLine(int i)
    {
        for (int j = 0; j < width; j++)
        {
            if (t_Grid[j, i] == null)
                return false;
        }
        GameManagerScript.noOfRowsTurn++;
        return true;
    }

    void RemoveLine(int i)
    {
        for (int j = 0; j < width; j++)
        {
            Destroy(t_Grid[j, i].gameObject);
            t_Grid[j, i] = null;
        }

    }

    void RowDown(int i)
    {
        for (int k = i; k < hight; k++)
        {
            for (int l = 0; l < width; l++)
            {
                if (t_Grid[l, k] != null)
                {
                    t_Grid[l, k - 1] = t_Grid[l, k];
                    t_Grid[l, k] = null;
                    t_Grid[l, k - 1].transform.position -= new Vector3(0, 1, 0);
                }

            }
        }

    }



    void GridUpdate()
    {
        foreach (Transform childobj in transform)
        {
            int objX = Mathf.RoundToInt(childobj.transform.position.x);
            int objY = Mathf.RoundToInt(childobj.transform.position.y);

            t_Grid[objX, objY] = childobj; 
        }
    }



    bool Isvalidmove()
    {
        foreach (Transform childobj in transform)
        {
            int roundedX = Mathf.RoundToInt(childobj.transform.position.x);
            int roundedY = Mathf.RoundToInt(childobj.transform.position.y);

            Debug.Log("roundedX: " + roundedX + " roundedY: " + roundedY);

            if (roundedX < 0 || roundedX >= width || roundedY < 0 || roundedY >= hight)
            {
                Debug.Log("return false");
                return false;

            }

            if (t_Grid[roundedX, roundedY] != null)
                return false;

        }

        return true;


    }

    




    void Gameover()
    {      
      SceneManager.LoadScene("Game over");
    }

}
