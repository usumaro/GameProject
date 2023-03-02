using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class SaveTime : MonoBehaviour
{
    public InputField inputField;
    public GameObject PlaceHolder;
    public GameObject Time;
    public BestTime bt;
   
    public void Button_Push() //���O����͂ƃ^�C�����L�^
    {
        PlaceHolder = GameObject.Find("Placeholder");
        Time = GameObject.Find("Time");
        inputField = GameObject.Find("InputName").GetComponent<InputField>();
        string input = inputField.text;

        if (input == "")//�󗓂���Ȃ���Ζ��O�ƃ^�C����DB�ɋL�^
        {
            PlaceHolder.GetComponent<Text>().text = "<color=red>���O����͂��Ă�������</color>";
        }
        else
        { StartCoroutine("Access"); }     
    }

    private IEnumerator Access()//���O�ƃ^�C����DB �ɑ��M
    {
        Dictionary<string, string> dic = new Dictionary<string, string>();
        dic.Add("time1", Time.GetComponent<Text>().text);
        dic.Add("name1", inputField.GetComponentInChildren<InputField>().text);

        StartCoroutine(Post("http://localhost/dbaccess/savetime.php", dic));

        string runtime = Time.GetComponent<Text>().text.Replace("�b", "");
        Debug.Log(runtime);
        Debug.Log(bt.btt);
        if (float.Parse(runtime) > bt.btt )//�x�X�g�^�C���X�V���Ă�����S�[�X�g���X�V
        {
            StartCoroutine(Post("http://localhost/dbaccess/bestpositioncopy.php", dic));
            Debug.Log("�S�[�X�g�ۑ����܂���");
        }
        yield return 0;
    }

    private IEnumerator Post(string url, Dictionary<string, string> post)
    {
        WWWForm form = new WWWForm();
        foreach (KeyValuePair<string, string> post_arg in post)
        {
            form.AddField(post_arg.Key, post_arg.Value);
        }

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();
        }
    }
}



    

