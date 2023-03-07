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
    private bool OneTime = true;//一度だけ実行用

    public void Update()
    {
        if (gm.isGoal == true)
        {
            StartCoroutine("Access");//DBのタイムを取得
        }
    }

    public void Button_Push()
    {
       
        ScorePanel.SetActive(true);//スコアの表示

        foreach (Score ts in timeScore)
        {
            // 読み込んだデータの確認
            Debug.Log($"id={ts.time_id} name={ts.name} time={ts.time} date={ts.time_date}");
            namedata = namedata + ts.name + "\n";
            timedata = timedata + ts.time + "\n";
            datedata = datedata + ts.time_date + "\n";
        }
       
        if (OneTime == true)//一度だけ表示
        {
            NameText.GetComponent<Text>().text = "NAME\n" + namedata;
            ScoreText.GetComponent<Text>().text = "SCORE\n" + timedata;
            DateText.GetComponent<Text>().text = "DATE\n" + datedata;
            OneTime = false; 
        }
    }

    public class Score //配列のリスト
    {
        public string time_id { get; set; }
        public string name { get; set; }
        public string time { get; set; }
        public string time_date { get; set; }
    }

    private IEnumerator Access()　//タイム一覧の呼び出し
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
            else if (www.isDone)　//エラーがなければリストでデータを取得
            {
                string data = www.downloadHandler.text;
                this.timeScore = JsonConvert.DeserializeObject<List<Score>>(data);
                Debug.Log(data);
            }
        }
    }
}
