using UnityEngine;

public class Table : MonoBehaviour
{
    public static Square[] squares;
    public static Winner winner;

    public enum Winner
    {
        none,
        blue,
        red,
        draw
    }

    private void Awake()
    {
        squares = new Square[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            squares[i] = transform.GetChild(i).GetComponent<Square>();
        }
    }

    private void Update()
    {
        CheckForWin(Winner.blue, Square.Type.blue);
        CheckForWin(Winner.red, Square.Type.red);
    }

    private void CheckForWin(Winner winner, Square.Type type)
    {
        if (squares[0].type == type && squares[1].type == type && squares[2].type == type) Table.winner = winner;
        if (squares[3].type == type && squares[4].type == type && squares[5].type == type) Table.winner = winner;
        if (squares[6].type == type && squares[7].type == type && squares[8].type == type) Table.winner = winner;

        if (squares[0].type == type && squares[3].type == type && squares[6].type == type) Table.winner = winner;
        if (squares[1].type == type && squares[4].type == type && squares[7].type == type) Table.winner = winner;
        if (squares[2].type == type && squares[5].type == type && squares[8].type == type) Table.winner = winner;

        if (squares[0].type == type && squares[4].type ==type && squares[8].type == type) Table.winner = winner;
        if (squares[2].type == type && squares[4].type == type && squares[6].type == type) Table.winner = winner;
    }
}
