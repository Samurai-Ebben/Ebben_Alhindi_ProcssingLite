using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;


public class Curves : ProcessingLite.GP21
{
    private float x;
    private float y;
    private float spaceBetween;


    public Curves(float axis1, float axis2, float numberOfLines)
    {
        x = axis1;
        y = axis2;
        spaceBetween = numberOfLines;
        MakeCurves();
    }

    void MakeCurves()
    {
        for (int i = 0; i < Width / spaceBetween; i++)
        {
            //Increase y-cord each time loop run
            float spaceY = i * spaceBetween;

            if (spaceY % 3 == 0)
            {
                Stroke(255, 165, 0, 64);
            }
            else
            {
                Stroke(160, 32, 240, 64);
            }
            Line(spaceY, y, x, spaceY);
        }
    }
};

public class Assignment1 : ProcessingLite.GP21
{
    public float spaceBetweenLines = 0.2f;

    [Range(0,255)]public int redColor;
    [Range(0,255)]public int greenColor;
    [Range(0,255)]public int blueColor;

    public float eX;
    public float eY;

    public float aX;
    public float aY;

    Curves curve1;


    // Start is called before the first frame update
    void Start()
    {
        Background(redColor, greenColor, blueColor);

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Background(redColor, greenColor, blueColor);
        curve1 = new Curves(Width, 0, spaceBetweenLines);
        curve1 = new(0, Height, spaceBetweenLines);
        curve1 = new(Width, Height, spaceBetweenLines);

        Stroke(255,255,255);
        StrokeWeight(0.9f);

        LetterE(eX, eY);

        //A
        LetterA(aX, aY);

        //Prepare our stroke settings
        Stroke(160, 32, 240, 64);
        StrokeWeight(0.5f);

        for(int i = 0; i < Height/ spaceBetweenLines; i++)
        {
            float y = i * spaceBetweenLines;
            if(y % 2 ==0)
            {
                Stroke(164, 132, 140, 64);
            }
            Line(0, y, Width, y);
        }
       
    }

    void LetterE(float x, float y)
    {
        Line(1 + x, 1 + y, 1 + x, 4 + y);
        Line(1 + x, 4 + y, 2 + x, 4 + y);
        Line(1 + x, 1 + y, 2 + x, 1 + y);
        Line(1 + x, 2.5f + y, 2 + x, 2.5f + y);
    }

    void LetterA(float x, float y)
    {
        Line(4 + x, 7 + y, 6 + x, 3 + y);
        Line(3 + x, 3 + y, 4 + x, 7 + y);
        Line(3 + x, 5 + y, 5 + x, 5 + y);
    }
}
