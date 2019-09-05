using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(EdgeCollider2D))]
public class TailScript : MonoBehaviour
{
    //zmienne

        // przerwa pomiędzy punktami
    public float pointSpacing = .1f;
    public Transform snake;
    public Color color = Color.red;
    //lista punktów na którym jest budowanya linia
    List<Vector2> points;

    LineRenderer line;
    EdgeCollider2D col;

    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        col = GetComponent<EdgeCollider2D>();

        line.material.color = color;
        //wyresetuj na początek
        points = new List<Vector2>();
        SetPoint();
    }

    // Update is called once per frame
    void Update()
    {
        //dodaj punkt kiedy oddalisz się od ostatniego o pointSpacing
        if (Vector3.Distance(points.Last(), snake.position) > pointSpacing)
        {
            SetPoint();
        }
    }

    void SetPoint()
    {
        if (points.Count > 1)
        {
            col.points = points.ToArray<Vector2>();
            Debug.Log("Original point:" + points[points.Count - 1]);
            Debug.Log("Converted point:" + col.points[col.points.Count<Vector2>() - 1]);
        }

        //dodawaj punkty do listy
        points.Add(snake.position);

        //ustaw pierwszy punkt
        line.positionCount = points.Count;
        line.SetPosition(points.Count - 1, snake.position);


    }
}
