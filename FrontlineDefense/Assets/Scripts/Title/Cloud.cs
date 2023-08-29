using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cloud : MonoBehaviour
{
    public enum CLOUD_TYPE
    {
        CLOUD_TYPE_LEFT = -1,
        CLOUD_TYPE_RIGHT = 1
    }

    
    public float cloudSpeed = 0;
    public CLOUD_TYPE type = CLOUD_TYPE.CLOUD_TYPE_LEFT;

    private float speed = 0;

    // Start is called before the first frame update
    void Start()
    {
        TitleAnyKeyInput.Instance.OnAnyKeyDown += ()=> { if(speed != cloudSpeed) speed = cloudSpeed; };
    }

    // Update is called once per frame
    void Update()
    {
        MoveToOutsideScreen();
    }

    public void MoveToOutsideScreen()
    {
        transform.position += (int)type * new Vector3(speed * Time.deltaTime, 0, 0);

        Vector3 viewPos = Camera.main.WorldToScreenPoint(transform.position);
        if (viewPos.x < 0 || viewPos.x > Camera.main.pixelWidth || viewPos.y < 0 || viewPos.y > Camera.main.pixelHeight)
        {
            Debug.Log(gameObject.name + "=>OutSide");
            speed = 0;
            gameObject.SetActive(false);
            SceneManager.LoadScene("MainScene");//LoadSceneAsync
        }
    }
}
