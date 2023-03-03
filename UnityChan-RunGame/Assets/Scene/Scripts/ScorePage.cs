using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ScorePage : MonoBehaviour
{
    public GameObject ScoreButton;
    public GameObject ScoreText;
    string timedata;
    List<Score> timeScore;

    public void Button_Push()
    {
        StartCoroutine("Access");//DBのタイムを取得

        foreach (Score ts in timeScore)
        {
            // 読み込んだデータの確認
            Debug.Log($"id={ts.time_id} name={ts.name} time={ts.time} date={ts.time_date}");
           timedata = timedata + ts.name + ts.time + ts.time_date +"\n";

        }
         ScoreText.GetComponent<Text>().text = timedata;
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
