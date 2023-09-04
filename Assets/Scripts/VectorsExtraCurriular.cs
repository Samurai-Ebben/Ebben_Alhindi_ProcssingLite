using UnityEngine;
using TMPro;

public class VectorsExtraCurriular : ProcessingLite.GP21
{

    /*Create a new program that gives you a random vector.
     * For example (6, 10) and the goal of the game(?)
     * is to draw a vector on the screen with the mouse
     * and get as close as possible to a vector of that size.
     * Calculate the score and give the player feedback on his result.*/

    Vector2 randVect;
    public Vector2 startPos;
    public Vector2 endPos;
    public TextMeshProUGUI txt;
    // Start is called before the first frame update
    void Start()
    {
        Background(180);

        startPos = new Vector2(Width/2, Height/2);
        int randNum1 = Random.Range(0, (int)Width);
        int randNum2 = Random.Range(0, (int)Height);
        randVect = new Vector2(randNum1, randNum2);
    }

    // Update is called once per frame
    void Update()
    {
        float guessLineLen = Magnitude(randVect);
        float lineLen = GetLineLength();

        float result;

        if(Input.GetMouseButtonUp(0))
        {
            if (lineLen > guessLineLen)
            {
                result = lineLen - guessLineLen;
                txt.text = "Your line is larger than the vector by: " + result.ToString();
            }
            if (lineLen < guessLineLen)
            {
                result = guessLineLen - lineLen;
                txt.text = "Your line is smaller than the vector by: " + result.ToString();
            }
            if (lineLen == guessLineLen)
            {
                txt.text= "Great!!";
            }
            Background(180);
        }
    }

    public Vector2 CalculateVectors(Vector2 start, Vector2 end)
    {
        float x = end.x - start.x;
        float y = end.y - start.y;
        return new Vector2(x, y);
    }
     
    public int Magnitude(Vector2 vector)
    {
        float sqrtLen = (vector.x * vector.x) + (vector.y * vector.y);
        int len = (int)Mathf.Sqrt(sqrtLen);
        return len;
    }

    int GetLineLength()
    {
        Background(180);

        if (Input.GetMouseButtonDown(0)) // press the button
        {
            startPos.x = MouseX;
            startPos.y = MouseY;
        }

        if (Input.GetMouseButton(0)) //Hold the button
        {
            endPos.x = MouseX;
            endPos.y = MouseY;
        }
        Line(startPos.x, startPos.y, endPos.x, endPos.y);
        Debug.Log("Start: " +startPos);
        Debug.Log("End: " + endPos);
        Vector2 line = endPos - startPos;
        float lineLength = Magnitude(line);
        Debug.Log("Length: " + lineLength);

        return (int)lineLength;
    }


}
