using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ScorePage : MonoBehaviour
{
    public GoalManager gm;
    public GameObject ScoreButton;
    public GameObject NameText;
    public GameObject ScoreText;
    public GameObject DateText;
    public GameObject ScorePanel;
    string namedata;
    string timedata;
    string datedata;
    List<Score> timeScore = null;
    private bool OneTime = true;//��x�������s�p

    public void Update()
    {
        if (gm.isGoal == true)
        {
            StartCoroutine("Access");//DB�̃^�C�����擾
        }
    }

    public void Button_Push()
    {
       
        ScorePanel.SetActive(true);//�X�R�A�̕\��

        foreach (Score ts in timeScore)
        {
            // �ǂݍ��񂾃f�[�^�̊m�F
            Debug.Log($"id={ts.time_id} name={ts.name} time={ts.time} date={ts.time_date}");
            namedata = namedata + ts.name + "\n";
            timedata = timedata + ts.time + "\n";
            datedata = datedata + ts.time_date + "\n";
        }
       
        if (OneTime == true)//��x�����\��
        {
            NameText.GetComponent<Text>().text = "NAME\n" + namedata;
            ScoreText.GetComponent<Text>().text = "SCORE\n" + timedata;
            DateText.GetComponent<Text>().text = "DATE\n" + datedata;
            OneTime = false; 
        }
    }

    public class Score //�z��̃��X�g
    {
        public string time_id { get; set; }
        public string name { get; set; }
        public string time { get; set; }
        public string time_date { get; set; }
    }

    private IEnumerator Access()�@//�^�C���ꗗ�̌Ăяo��
    {
        Debug.Log("Access");
        StartCoroutine(Post("http://localhost/dbaccess/scorepage.php"));

        yield return 0;
    }

    private IEnumerator Post(string url)
    {
        Debug.Log("Post");
        WWWForm form = new WWWForm();

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

            if (www.error != null)
            {
                Debug.Log("HttpPost NG;" + www.error);
            }
            else if (www.isDone)�@//�G���[���Ȃ���΃��X�g�Ńf�[�^���擾
            {
                string data = www.downloadHandler.text;
                this.timeScore = JsonConvert.DeserializeObject<List<Score>>(data);
                Debug.Log(data);
            }
        }
    }
}
