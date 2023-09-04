using UnityEngine;

public class VectorsExtraCurriular : ProcessingLite.GP21
{
    Vector2 randVect;

    Vector2 startPos;
    Vector2 endPos;

    // Start is called before the first frame update
    void Start()
    {
        int randNum1 = Random.Range(0, (int)Width);
        int randNum2 = Random.Range(0, (int)Height);
        randVect = new Vector2(randNum1, randNum2);
    }

    // Update is called once per frame
    void Update()
    {
        GameLoop();
    }

    public Vector2 CalculateVectors(Vector2 start, Vector2 end)
    {
        float x = end.x - start.x;
        float y = end.y - start.y;
        return new Vector2(x, y);
    }

    public float Magnitude(Vector2 vector)
    {
        float sqrtLen = (vector.x * vector.x) + (vector.y * vector.y);
        float len = Mathf.Sqrt(sqrtLen);
        return len;
    }

    float GetLineLength()
    {
        if (Input.GetMouseButtonDown(0)) // press the button
        {
            Background(49, 77, 121);
            startPos.x = MouseX;
            startPos.y = MouseY;
        }
        if (Input.GetMouseButton(0)) //Hold the button
        {
            Background(49, 77, 121);

            endPos.x = MouseX;
            endPos.y = MouseY;
            Line(startPos.x, startPos.y, endPos.x, endPos.y);
        }

        Vector2 line = CalculateVectors(startPos, endPos);
        float lineLength = Magnitude(line);
        return lineLength;
    }

    void GameLoop()
    {
        float lineLen = GetLineLength();
        float guessLineLen = Magnitude(randVect);

        float result;

        if (Input.GetMouseButtonDown(0))
        {
            if (lineLen > guessLineLen)
            {
                result = lineLen - guessLineLen;
                Debug.Log("Your line is larger than the vector by: " + result);
            }
            else if (lineLen < guessLineLen)
            {
                result = guessLineLen - lineLen;
                Debug.Log("Your line is smaller than the vector by: " + result);
            }
            else
            {
                Debug.Log("Great!!");
            }
        }
    }

}
