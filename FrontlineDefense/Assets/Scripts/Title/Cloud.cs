using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public enum CLOUD_TYPE
    {
        CLOUD_TYPE_LEFT = -1,
        CLOUD_TYPE_RIGHT = 1
    }

    public delegate void CloudActionHandler();
    public event CloudActionHandler OnCloudActionCompleted;

    public float cloudSpeed = 0;
    public CLOUD_TYPE type = CLOUD_TYPE.CLOUD_TYPE_LEFT;

    Renderer renderer = default;

    private float speed = 0;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        TitleAnyKeyInput.Instance.OnAnyKeyDownHandler += ()=> { if(speed != cloudSpeed) speed = cloudSpeed; };
    }

    // Update is called once per frame
    void Update()
    {
        if (renderer == default) return; 

        MoveToOutsideScreen();
    }

    public void MoveToOutsideScreen()
    {
        transform.position += Convert.ToInt32(type) * new Vector3(speed * Time.deltaTime, 0, 0);

        
        Vector3 minScreenPoint = Camera.main.WorldToScreenPoint(renderer.bounds.min);
        Vector3 maxScreenPoint = Camera.main.WorldToScreenPoint(renderer.bounds.max);

        //Camera.main.pixelWidth
        //Camera.main.pixelHeight
        if (minScreenPoint.x > Screen.width || maxScreenPoint.x < 0 || minScreenPoint.y > Screen.height || maxScreenPoint.y < 0)
        {
            speed = 0;

            gameObject.SetActive(false);

            if (OnCloudActionCompleted != null)
            {
                OnCloudActionCompleted();
            }
        }
    }
}
