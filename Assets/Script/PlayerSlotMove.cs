using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlotMove : MonoBehaviour
{
    public GameObject SlotLine;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SlotLine.transform.localPosition = new Vector2(-305f, -448f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {   
            SlotLine.transform.localPosition = new Vector2(-153f, -448f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SlotLine.transform.localPosition = new Vector2(-1f, -448f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SlotLine.transform.localPosition = new Vector2(151f, -448f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SlotLine.transform.localPosition = new Vector2(303f, -448f);
        }
    }
}
