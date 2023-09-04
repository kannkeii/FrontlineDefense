using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingWindowEvent : MonoBehaviour
{
    public SettingButton settingButton;
    public GameObject SettingWindow;
    public GameObject WindowBG;

    // Start is called before the first frame update
    void Start()
    {
        settingButton.OnSettingWindowActionCompleted += OnSettingWindowOpen;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnSettingWindowOpen()
    {
        WindowBG.SetActive(true);
        SettingWindow.SetActive(true);
    }
}
