using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


/*Assignments
DoneX
- Do the extra curicular
*/

public class VectorsAssignment : ProcessingLite.GP21
{
    [SerializeField] Vector2 circelPos;
    public float dia = 1;

    Vector2 vectPos;
    float speed = 2f;

    public Vector2 dist;
    public float bounceRate = 250;


    // Start is called before the first frame update
    void Start()
    {
        Circle(circelPos.x, circelPos.y, dia);
    }

    // Update is called once per frame
    void Update()
    {
        Background(49, 77, 121);

        if(Input.GetMouseButtonDown(0))
        {
            circelPos.x = MouseX;
            circelPos.y = MouseY;
            dist = Vector2.zero;
            Circle(circelPos.x,circelPos.y, dia);
        }

        if(Input.GetMouseButton(0)) { 
            vectPos.x = MouseX;
            vectPos.y = MouseY;
            Line(circelPos.x, circelPos.y, vectPos.x, vectPos.y);
        }

        if (Input.GetMouseButtonUp(0))
        {
            dist = vectPos - circelPos;
            if (dist.sqrMagnitude > 5*5)
            {
                dist.Normalize();
                dist *= 5;
            }
        }

        circelPos += dist * Time.deltaTime * speed;

        Circle(circelPos.x, circelPos.y, dia);
        float rad = dia / 2;

        //edges check
        if (circelPos.x + rad >= Width || circelPos.x - rad <= 0)
            dist.x *= -1;
        if (circelPos.y + rad >= Height || circelPos.y - rad <= 0)
            dist.y *= -1;
        else
            speed *= 1;
    }

    //This function calculates the length of a given vector. 
    public float Magnitude(Vector2 vector)
    {
        float sqrtLen = (vector.x * vector.x) + (vector.y * vector.y);
        float len = Mathf.Sqrt(sqrtLen);
        return len;
    }

    public Vector2 CalculateVectors(Vector2 start, Vector2 end)
    {
        float x = end.x - start.x;
        float y = end.y - start.y;
        return new Vector2(x, y);
    }
}
