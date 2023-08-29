using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleAnyKeyInput : MonoBehaviour
{
    public delegate void AnyKeyDownHandler();

    public event AnyKeyDownHandler OnAnyKeyDown;

    public static TitleAnyKeyInput Instance { get { return instance; } }//private set; }

    private static TitleAnyKeyInput instance = null;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else
        {
            Destroy(gameObject);
            Debug.LogError("TitleAnyKeyInputのインスタンスが失敗しました。");
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Input.GetKey//检测键盘输入
        //Input.GetMouseButton//检测鼠标输入
        //Input.GetAxis//检测在Input Manager中定义的虚拟轴的值
        //Input.GetButton//检测在Input Manager中定义的虚拟按钮是否被按下

        if(Input.anyKeyDown || MouseAnyKeyDown())
        {
            OnAnyKeyDown?.Invoke();
        }

    }

    bool MouseAnyKeyDown()
    {
        if (Input.GetMouseButtonDown(0) ||
            Input.GetMouseButtonDown(1) ||
            Input.GetMouseButtonDown(2))
            return true;

        return false;
    }
}
