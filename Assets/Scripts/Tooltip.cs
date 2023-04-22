using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
    public Camera sceneCamera;

    private bool active = false;

    private Vector2 mousePosition;
    private Vector2 offset = new Vector2(-1, 0);

    private RectTransform rt;

    private void Awake()
    {
        rt = GetComponent<RectTransform>();
    }

    void Update()
    {
        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);
        Follow();
        if (Input.GetButtonDown("Fire1"))
        {
            Show();
        }
    }

    void CheckHover()
    {
        
    }

    void Show()
    {
        active = !active;
        if (active)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    void Follow()
    {
        //offset = new Vector2(-rt.sizeDelta.x * rt.localScale.x / 2, rt.sizeDelta.y * rt.localScale.y / 2);
        rt.position = mousePosition + offset;
    }
}

