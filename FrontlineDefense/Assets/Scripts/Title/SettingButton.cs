using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingButton : MonoBehaviour
{
    public delegate void SettingWindowActionHandler();
    public event SettingWindowActionHandler OnSettingWindowActionCompleted;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnClick()
    {
        if(OnSettingWindowActionCompleted != null)
        {
            OnSettingWindowActionCompleted();
        }
    }
}
