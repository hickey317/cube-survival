using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ztime : MonoBehaviour
{
    public Text hour; //时针
    public Text minute; //分钟
    private int minuteNum1 = 0;
    private int hourNum1 = 5;
    private float minuteNum = 60;

    public GameObject[] Object;
    public GameObject Enemy;

    private bool isonce = true;

    public UIController controller;  //胜利面板

    // Start is called before the first frame update
    void Start()
    {
        if (minuteNum1 == 0)
        {
            hourNum1--;
            minuteNum1 = 60;
            hour.text = hourNum1.ToString();
            minute.text = minuteNum1.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.isStart==true)
        {
            minuteNum -= Time.deltaTime;
            minuteNum1 = (int)minuteNum % 60; //小数转整数
            if (minuteNum1 < 10)
            {
                minute.text = "0" + minuteNum1.ToString();
            }
            else
            {
                minute.text = minuteNum1.ToString();
            }
            if(minuteNum <= 30&& isonce==true)
            {
                isonce = false;
                int count = Object.Length;
                for (int i = 0; i < 5; i++)
                {
   
                    int c = Random.Range(0, count);
                    Instantiate(Enemy, Object[c].transform.position, Object[c].transform.rotation);
                  
                }
            }
            if (minuteNum1 <= 0 && hourNum1 > 0)
            {
                minuteNum = 60;
                hourNum1--;
                hour.text = hourNum1.ToString();
                isonce = true;
                if (hourNum1 == 3)
                {
                    int count = Object.Length;
                    for(int i=0;i<5;i++)
                    {
                        int c = Random.Range(0, count);
                        Instantiate(Enemy, Object[c].transform.position, Object[c].transform.rotation);
                    }
     
                }
                if (hourNum1 == 2)
                {
                    int count = Object.Length;
                    for (int i = 0; i < 5; i++)
                    {
                        int c = Random.Range(0, count);
                        Instantiate(Enemy, Object[c].transform.position, Object[c].transform.rotation);
                    }
                }
                if (hourNum1 == 1)
                {
                    int count = Object.Length;
                    for (int i = 0; i < 5; i++)
                    {
                        int c = Random.Range(0, count);
                        Instantiate(Enemy, Object[c].transform.position, Object[c].transform.rotation);
                    }
                }
                if (hourNum1 == 0)
                {
                    int count = Object.Length;
                    for (int i = 0; i < 5; i++)
                    {
                        int c = Random.Range(0, count);
                        Instantiate(Enemy, Object[c].transform.position, Object[c].transform.rotation);
                    }
                }
            }
            if (minuteNum <= 0 && hourNum1 == 0)
            {
                Debug.Log("时间到了");
                controller.isStart = false;
                controller.winPanel.SetActive(true);
            }

        }
    }
    
}