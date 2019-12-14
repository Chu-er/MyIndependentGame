using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    //Viriable
    
    public string KeyUp ="w";
    public string KeyDown = "s";
    public string KeyLeft = "a";
    public string KeyRight = "d";

    public float Dup;
    public float Dright;
    public float Dmag;
    public Vector3 Dvec;

    private float targetDup;
    private float targetDright;

    public float Time;
    public float VelocityDup;
    public float VelocityDright;


    public bool InputEnabled = true;
    void Awake()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
        targetDup = (Input.GetKey(KeyUp) ? 1 : 0) - (Input.GetKey(KeyDown) ? 1 : 0);
        targetDright = (Input.GetKey(KeyRight) ? 1 : 0) - (Input.GetKey(KeyLeft) ? 1 : 0);


#endif

#if UNITY_IPHONE

#endif

        if (!InputEnabled)
        {
            targetDup = 0;
            targetDright = 0;
        }
        Dup = Mathf.SmoothDamp(Dup, targetDup, ref VelocityDup, Time);
        Dright = Mathf.SmoothDamp(Dright, targetDright, ref VelocityDright, Time);
        Vector2 tempDaxis = squareToCircle(new Vector2( Dright,Dup));
        

        Dmag = Mathf.Sqrt(tempDaxis.x * tempDaxis.x + tempDaxis.y * tempDaxis.y);
        Dvec = Dright * transform.right + Dup * transform.forward;
    }
    Vector2 squareToCircle(Vector2 input)
    {
        Vector2 output;
        output.x = input.x * Mathf.Sqrt(1 - (input.y * input.y) / 2);
        output.y = input.y * Mathf.Sqrt(1 - (input.x * input.x) / 2);

        return output;

    }

}


