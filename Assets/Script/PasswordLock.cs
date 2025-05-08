using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;
using Object = System.Object;

public class PasswordLock : MonoBehaviour
{
    public string[] password = new string[4];
    public string[] password2 = new string[4];
    public int a = 0;
    public GameObject doorScene;
    public GameObject Clearui;
    public GameObject[] bull;

    public void Update()
    {
        
    }

    public void ClickBtn()
    {
        
        GameObject CBtn = EventSystem.current.currentSelectedGameObject;
        password2[a] = CBtn.GetComponent<Buttonn>().PasswodNumber;
        if (password2[a] != null)
        {
            bull[a].SetActive(true);
        }
        a += 1;
    }

    public void ClickBtn2()
    {
        if (password.SequenceEqual(password2))
        {
            Clearui.SetActive(true);
            Invoke("end", 2);
            Invoke("doorScene1", 3);
        }
        else
        {
            a = 0;
            bull[0].SetActive(false);
            bull[1].SetActive(false);
            bull[2].SetActive(false);
            bull[3].SetActive(false);
        }
    }

    public void end()
    {
        Clearui.SetActive(false);
    }

    private void doorScene1()
    {
        doorScene.SetActive(true);
    }
}
