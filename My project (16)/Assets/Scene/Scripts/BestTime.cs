using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class BestTime : MonoBehaviour
{
    public GameObject BestTimeText;
    public float btt;
   
   void Start()
    {
        BestTimeText = GameObject.Find("BestTimeText");
        StartCoroutine("Access");
    }

    private IEnumerator Access()//�x�X�g�^�C�����Ăяo��
    {
        StartCoroutine(Post("http://localhost/dbaccess/loadbesttime.php"));    
        yield return 0;
    }

    private IEnumerator Post(string url)
    {
        WWWForm form = new WWWForm();

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();
            btt = float.Parse(www.downloadHandler.text);//�x�X�g�^�C���Q�Ɨp
            BestTimeText.GetComponent<Text>().text ="BestTime :"+ www.downloadHandler.text + "�b";//�x�X�g�^�C�����e�L�X�g�ɕ\��
        }    
    }
}



    

