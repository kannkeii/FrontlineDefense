using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CloudEvent : MonoBehaviour
{
    public List<Cloud> cloudsList;
    private int OnCloudActionCompletedCnt = 0;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Cloud cloud in cloudsList)
        {
            cloud.OnCloudActionCompleted += LoadMainScene;
        }
    }

    void LoadMainScene()
    {
        OnCloudActionCompletedCnt++;
        if (OnCloudActionCompletedCnt == cloudsList.Count)
        {
            SceneManager.LoadScene("MainScene");//LoadSceneAsync
        }
    }
}
