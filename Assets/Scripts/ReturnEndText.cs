using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnEndText : MonoBehaviour
{
    public TextMesh endText;

    public TextMesh getEndText()
    {
        endText = GetComponent<TextMesh>();
        return endText;
    }

    
}
