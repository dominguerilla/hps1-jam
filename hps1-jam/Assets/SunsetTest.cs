using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SunsetTest : MonoBehaviour
{
    public float scrollRate = 1f;
    public float setRate = -1f;
    public bool autoMode = false;

    [SerializeField]
    Text modeText;

    Quaternion originalRotation;
    // Start is called before the first frame update
    void Start()
    {
        originalRotation = this.transform.rotation;
        SetModeText();
    }

    // Update is called once per frame
    void Update()
    {
        if (!autoMode)
        {
            SetManually();
        }
        else
        {
            SetAutomatically();
        }

        if (Input.GetMouseButtonDown(1))
        {
            ResetSun();
            autoMode = !autoMode;
            SetModeText();
        }
    }

    void SetManually()
    {
        float scrollDelta = Input.mouseScrollDelta.y;
        this.transform.Rotate(scrollDelta * scrollRate, 0, 0);
    }

    void SetAutomatically()
    {
        this.transform.Rotate(setRate * Time.deltaTime, 0, 0);
    }

    void ResetSun()
    {
        this.transform.rotation = originalRotation;
    }

    void SetModeText()
    {
        modeText.text = autoMode ? "AUTO MODE" : "MANUAL MODE";
    }
}
