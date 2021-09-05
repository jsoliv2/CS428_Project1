using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Magic8BallScript : MonoBehaviour
{
    public string[] phrases;
    public GameObject knickknack;
    public TMP_Text magic8Text;

    public float rotationTolerance = 30.0f;

    private bool isUpsideDown = false;
    private bool isUpsideDownPrev = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckUpsideDown();

        CheckTurnRightsideUp();

        isUpsideDownPrev = isUpsideDown;
    }

    void CheckUpsideDown()
    {
        float baseRotation = 180.0f;
        float currRotation = knickknack.transform.localEulerAngles.z;

        if ((currRotation >= (baseRotation - rotationTolerance) && (currRotation <= (baseRotation + rotationTolerance))))
        {
            isUpsideDown = true;
        }
        else
        {
            isUpsideDown = false;
        }
    }

    void CheckTurnRightsideUp()
    {
        if (!isUpsideDown && isUpsideDownPrev)
        {
            if (phrases.Length > 0)
            {
                magic8Text.text = phrases[Random.Range(0, phrases.Length)];
            }
        }
    }
}
