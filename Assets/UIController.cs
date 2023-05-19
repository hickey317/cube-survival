using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public bool isStart = false;

    public GameObject failPanel;
    public GameObject winPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void startGame()
    {
        isStart = true;
    }
    public void restartGame()
    {
        SceneManager.LoadScene("TutorialScene");
    }

    public void OnExitGame()//����һ���˳���Ϸ�ķ���
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//�������unity��������
#else
        Application.Quit();//�����ڴ���ļ���
#endif
    }
}
