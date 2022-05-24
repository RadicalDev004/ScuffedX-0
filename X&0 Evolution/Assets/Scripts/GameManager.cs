using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public GameObject Player1, Player2, _table;
    public int moves;

    public int SelectedCircle; // 1-6 for blue && 7-12 for red
    public int SelectedValue; // value of selected circle
    public bool Turn = true; // true for blue && false for red


    private void Awake()
    {
        StartCoroutine(WaitForEnd());
    }

    private void Update()
    {
        CheckForDraw();
    }
    public void Select(int i)
    {
        if (i < 7 && Turn == false)
            return;
        if (i > 6 && Turn == true)
            return;

        SelectedCircle = i;
        SelectedValue = SetSelectedValue(SelectedCircle);

        Debug.Log("Selected Circle " + i);
    }


    public void PressSquare(Square square)
    {
        if (SelectedValue <= square.Value) { Debug.LogWarning("Lower Value Than Square"); return; }
        if (SelectedCircle < 7 && square.type == Square.Type.blue) { Debug.LogWarning("Same Circle Type Blue"); return; }
        if (SelectedCircle > 7 && square.type == Square.Type.red) { Debug.LogWarning("Same Circle Type Red"); return; }

        Debug.Log("Move Circle");

        if (Turn)
        {
            StartCoroutine(MoveCircleToSquare(Player1, square, 0.5f));
            square.type = Square.Type.blue;
        }
        else
        {
            StartCoroutine(MoveCircleToSquare(Player2, square, 0.5f));
            square.type = Square.Type.red;
        }

        square.Value = SelectedValue;
        Turn = !Turn;

        SelectedCircle = 0;
        SelectedValue = 0;

        moves++;

    }

    internal void PressSquare(int key)
    {
        throw new NotImplementedException();
    }

    private int SetSelectedValue(int selectedCircle)
    {
        switch (selectedCircle)
        {
            case 1:
                return 2;
            case 2:
                return 2;
            case 3:
                return 4;
            case 4:
                return 4;
            case 5:
                return 6;
            case 6:
                return 6;

            case 7:
                return 2;
            case 8:
                return 2;
            case 9:
                return 4;
            case 10:
                return 4;
            case 11:
                return 6;
            case 12:
                return 6;

            default:
                break;
        }
        return 0;
    }

    IEnumerator MoveCircleToSquare(GameObject Player, Square square, float time)
    {
        GameObject circle = Player.transform.Find("SelectCircle" + SelectedCircle).gameObject;
        circle.transform.SetParent(square.gameObject.transform);
        LeanTween.move(circle.GetComponent<RectTransform>(), Vector3.zero, time).setIgnoreTimeScale(true);

        circle.GetComponent<Button>().enabled = false;
        circle.GetComponent<Image>().raycastTarget = false;
        yield return new WaitForSecondsRealtime(time);

        yield return null;
    }

    IEnumerator WaitForEnd()
    {
        yield return new WaitUntil(() => Table.winner != Table.Winner.none);
        Destroy(Player2.GetComponent<Bot>());
        Time.timeScale = 0;

        UI.EndGame(Table.winner);
    }

    private void CheckForDraw()
    {
        if (Table.winner != Table.Winner.none) return;

        if (moves == 12)
        {
            Table.winner = Table.Winner.draw;
            return;
        }

        for (int i = 0; i < 9; i++)
        {
            if (_table.transform.GetChild(i).GetComponent<Square>().type == Square.Type.none) return;

            for (int j = 0; j < Player1.transform.childCount; j++)
            {
                if (Player1.transform.GetChild(j).GetComponent<Circle>().Value > _table.transform.GetChild(i).GetComponent<Square>().Value && Player1.transform.GetChild(j).GetComponent<Circle>().type.ToString() != _table.transform.GetChild(i).GetComponent<Square>().type.ToString())
                {
                    return;
                }
            }
            for (int j = 0; j < Player2.transform.childCount; j++)
            {
                if (Player2.transform.GetChild(j).GetComponent<Circle>().Value > _table.transform.GetChild(i).GetComponent<Square>().Value && Player2.transform.GetChild(j).GetComponent<Circle>().type.ToString() != _table.transform.GetChild(i).GetComponent<Square>().type.ToString())
                {
                    return;
                }
            }
        }

        Table.winner = Table.Winner.draw;
    }
}
