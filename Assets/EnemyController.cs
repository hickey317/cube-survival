using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform targetTansform;
    public float lerpSpeed = 0.2f;
    public float stoppingDistance = 0.2f;

    private bool isonce = true;

    public RectTransform hpUI;

    public float HP = 5;

    public UIController controller;
    
    private void Start()
    {
        controller = GameObject.Find("Canvas").transform.GetComponent<UIController>();
    }
    private void Update()
    {
        if (controller.isStart == true)
        {
            if (GameObject.Find("Player").transform != null && isonce == true)
            {
                targetTansform = GameObject.Find("Player").transform;
                isonce = false;
            }
            if (targetTansform != null)
            {
                // 让敌人向玩家移动
                this.transform.position = Vector3.Lerp(this.transform.position, targetTansform.position, lerpSpeed * Time.deltaTime);

                // 如果敌人与玩家接触，停止移动
                if (Vector3.Distance(transform.position, targetTansform.position) < stoppingDistance)
                {
                    lerpSpeed = 0;
                }
                if (Vector3.Distance(transform.position, targetTansform.position) > stoppingDistance)
                {
                    lerpSpeed = 0.2f;
                }
            }
        }
    }
    float a=0;
    public void reduceHP()
    {
        HP--;
        a += 0.16f;
        hpUI.anchoredPosition = new Vector2(a, 0f);
        if(HP<=0)
        {
            Destroy(gameObject);
        }
    }
}
