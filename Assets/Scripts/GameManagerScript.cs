using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManagerScript : MonoBehaviour
{

    public static int noOfRowsTurn = 0;
    static int curruntScore = 0;
    public  int oneline = 50;
    public  int twoline = 100;
    public  int threeline = 300;
    public  int fourline = 1000;

    public Text scorePlanel;
    // Start is called before the first frame update
    void Start()
    {
         GameManagerScript gameManager = this;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();        
        scorePlanel.text = curruntScore.ToString();

    }
    public  void UpdateScore()
    {
        if (noOfRowsTurn > 0)
        {
            if (noOfRowsTurn == 1)
            {
                ClearOneLine();
            }

            else if (noOfRowsTurn == 2)
            {
                ClearTwoLine();
            }

            else if (noOfRowsTurn == 3)
            {
                ClearThreeLine();
            }
            else if (noOfRowsTurn == 4)
            {
                ClearFourLine();
            }
            noOfRowsTurn = 0;
        }

    }

    public  void ClearOneLine()
    {
        curruntScore += oneline;
    }

    public  void ClearTwoLine()
    {
        curruntScore += twoline;
    }

    public  void ClearThreeLine()
    {
        curruntScore += threeline;
    }

    public  void ClearFourLine()
    {
        curruntScore += fourline;
    }
}
