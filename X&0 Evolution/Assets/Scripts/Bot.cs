using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{
    private readonly Dictionary<string, int> allWinable = new Dictionary<string, int>();
    public bool hasFinishedTurn;

    public GameManager GM;
    public Table table;

    private void Awake()
    {
   

        AddAllWinnables();
        StartCoroutine(WaitForTurn());
    }

    IEnumerator WaitForTurn()
    {
        yield return new WaitUntil(() => GM.Turn == false);
        if (transform.childCount == 0) yield break;
        yield return new WaitForSecondsRealtime(1);
        hasFinishedTurn = false;
        Debug.LogError("See if is about to win");
        IsAboutToWin();

        if (!hasFinishedTurn)
        {
            Debug.LogError("See if is about to lose");
            IsAboutToLose();
        }
        if (!hasFinishedTurn)
        {
            Debug.LogError("Try capture");
            WantsToCapture();
        }
        if (!hasFinishedTurn)
        {
            Debug.LogError("Chaotic");
            PlaysChaoticRandom();
        }






        Debug.Log("My time to not be here");
        StartCoroutine(WaitForTurn());
    }

    void IsAboutToWin()
    {
        for (int i = 0; i < Table.squares.Length; i++)
        {
            if (Table.squares[i].type == Square.Type.red)
            {
                for (int j = 0; j < Table.squares.Length; j++)
                {
                    if (j != i && Table.squares[j].type == Square.Type.red)
                    {
                        string foundPos = i.ToString() + j.ToString();
                        Debug.LogWarning(i + " " + j);
                        if (allWinable.ContainsKey(foundPos))
                        {
                            GM.Select(int.Parse(transform.GetChild(Random.Range(0, transform.childCount)).name.Replace("SelectCircle", "")));
                            GM.PressSquare(Table.squares[allWinable[foundPos]]);
                            hasFinishedTurn = true;
                            Debug.LogError("hehe i won");
                            return;
                        }
                    }
                }
            }
        }
    }
    void IsAboutToLose()
    {
        for (int i = 0; i < Table.squares.Length; i++)
        {
            if (Table.squares[i].type == Square.Type.blue)
            {
                for (int j = 0; j < Table.squares.Length; j++)
                {
                    if (j != i && Table.squares[j].type == Square.Type.blue)
                    {
                        string foundPos = i.ToString() + j.ToString();
                        Debug.LogWarning(i + " " + j);
                        if (allWinable.ContainsKey(foundPos) && Table.squares[allWinable[foundPos]].type == Square.Type.none)
                        {
                            GM.Select(int.Parse(transform.GetChild(transform.childCount-1).name.Replace("SelectCircle", "")));
                            GM.PressSquare(Table.squares[allWinable[foundPos]]);
                            hasFinishedTurn = true;
                            Debug.LogError("hehe i blocked u");
                            return;
                        }
                    }
                }
            }
        }
    }
    void WantsToCapture()
    {
        for (int i = 0; i < Table.squares.Length; i++)
        {
            if (Table.squares[i].type == Square.Type.blue)
            {
                for (int j = 0; j < transform.childCount; j++)
                {
                    if (transform.GetChild(j).GetComponent<Circle>().Value > Table.squares[i].Value)
                    {
                        GM.Select(int.Parse(transform.GetChild(j).name.Replace("SelectCircle", "")));
                        GM.PressSquare(Table.squares[i]);
                        hasFinishedTurn = true;
                        return;
                    }

                }
            }
        }
    }
    void PlaysChaoticRandom()
    {
        int sq = Random.Range(0, Table.squares.Length);
        int cr = Random.Range(0, transform.childCount);

        while (!(Table.squares[sq].type != Square.Type.red && Table.squares[sq].Value < transform.GetChild(cr).GetComponent<Circle>().Value))
        {
            sq = Random.Range(0, Table.squares.Length);
        }
        GM.Select(int.Parse(transform.GetChild(cr).name.Replace("SelectCircle", "")));
        GM.PressSquare(Table.squares[sq]);
        hasFinishedTurn = true;
        //Debug.LogWarning(int.Parse(transform.GetChild(cr).name.Replace("SelectCircle", "")) + " " + sq + " Random");
    }
    void PlaysBiggestRandom()
    {
        int sq = Random.Range(0, Table.squares.Length);
        int cr = transform.childCount;

        while (Table.squares[sq].type != Square.Type.red && Table.squares[sq].Value < transform.GetChild(cr).GetComponent<Circle>().Value)
        {
            sq = Random.Range(0, Table.squares.Length);
        }
        hasFinishedTurn = true;
    }
    void PlaysSmallestRandom()
    {
        int sq = Random.Range(0, Table.squares.Length);
        int cr = 0;

        while (Table.squares[sq].type != Square.Type.red && Table.squares[sq].Value < transform.GetChild(cr).GetComponent<Circle>().Value)
        {
            sq = Random.Range(0, Table.squares.Length);
        }
        hasFinishedTurn = true;
    }

    void AddWinnable(int placeToWin, string otherToWin)
    {

        allWinable.Add(otherToWin, placeToWin);
    }

    void AddAllWinnables()
    {
        //for 0
        AddWinnable(1, "20");
        AddWinnable(2, "10");

        AddWinnable(6, "30");
        AddWinnable(3, "60");

        AddWinnable(8, "40");
        AddWinnable(4, "80");


        //for 1
        AddWinnable(0, "21");
        AddWinnable(2, "01");

        AddWinnable(7, "41");
        AddWinnable(4, "71");


        //for 2
        AddWinnable(0, "12");
        AddWinnable(1, "02");

        AddWinnable(6, "42");
        AddWinnable(4, "62");

        AddWinnable(8, "52");
        AddWinnable(5, "82");


        //for 3
        AddWinnable(0, "63");
        AddWinnable(6, "03");

        AddWinnable(5, "43");
        AddWinnable(4, "53");


        //for 4
        AddWinnable(7, "14");
        AddWinnable(1, "74");

        AddWinnable(6, "24");
        AddWinnable(2, "64");

        AddWinnable(3, "54");
        AddWinnable(5, "34");

        AddWinnable(8, "04");
        AddWinnable(0, "84");


        //for 5
        AddWinnable(4, "35");
        AddWinnable(3, "45");

        AddWinnable(2, "85");
        AddWinnable(8, "25");


        //for 6
        AddWinnable(4, "26");
        AddWinnable(2, "46");

        AddWinnable(0, "36");
        AddWinnable(3, "06");

        AddWinnable(8, "76");
        AddWinnable(7, "86");


        //for 7
        AddWinnable(4, "17");
        AddWinnable(1, "47");

        AddWinnable(6, "87");
        AddWinnable(8, "67");


        //for 8
        AddWinnable(4, "08");
        AddWinnable(0, "48");

        AddWinnable(2,"58");
        AddWinnable(5, "28");

        AddWinnable(6, "78");
        AddWinnable(7, "68");
    }

    int RandomAdvancetPercent(params int[] percents)
    {
        int res = Random.Range(0, 101);

        if (res < percents[0])
            return 0;

        for (int i = 1; i < percents.Length; i++)
        {
            if (res >= percents[i - 1] && res < percents[i])
                return i;
        }

        return 0;
    }
}
