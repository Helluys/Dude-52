using UnityEngine;
using System.Collections.Generic;
using System.Xml;
using System;

public class Player : MonoBehaviour {

    enum Move { Left, Right, Up }

    static Move MoveFromString(string move) {
        switch (move) {
            case "Left":
                return Move.Left;
            case "Right":
                return Move.Right;
            case "Up":
                return Move.Up;
        }
        throw new NotImplementedException ();
    }

    static string MoveToString (Move move) {
        switch (move) {
            case Move.Left:
                return "Left";
            case Move.Right:
                return "Right";
            case Move.Up:
                return "Up";
        }
        throw new NotImplementedException ();
    }
    
    public string levelFile;
    List<Move> moveList = new List<Move> ();

    public float SatisfactionGauge { get; set; }

    Animator animator;

    void Start () {
        animator = GetComponent<Animator> ();

        XmlDocument doc = new XmlDocument ();
        doc.PreserveWhitespace = true;
        doc.Load (levelFile);
        XmlNodeList moveListNodes = doc.SelectNodes ("/Level/MoveList//Move");
        foreach (XmlNode moveNode in moveListNodes)
            moveList.Add (MoveFromString (moveNode.InnerText));
    }

    void Update () {
        float xAxis = Input.GetAxisRaw ("Horizontal");
        float yAxis = Input.GetAxisRaw ("Vertical");
        if (xAxis <= -0.9f)
            PerformMove (Move.Left);
        else if (xAxis >= 0.9f)
            PerformMove (Move.Right);
        else if (yAxis >= 0.9f)
            PerformMove (Move.Up);
    }

    private void PerformMove (Move move) {
        animator.SetTrigger ("Move" + MoveToString (move));
        if (CheckSpectators (move) && moveList[0] == move) {
            SatisfactionGauge += 5f;
        } else {
            SatisfactionGauge -= 5f;
        }
    }

    private bool CheckSpectators (Move move) {
        return true;
    }
}
