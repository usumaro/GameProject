using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class GhostButton : MonoBehaviour
{
    private GameObject Ghost ;
    private GameObject GhostButtonText;
    List<Position> positionData = null;

    float dt = 0;
    private bool on_off_button_bool;//ゴーストオンオフ
    int count = 0;//カウンター
    int stop = 1;//deltatimeストップ用

    public void Start()
    {
        Ghost = GameObject.Find("Ghost");
        GhostButtonText = GameObject.Find("GhostButtonText");
        on_off_button_bool = true;//ゴーストオンオフ
        GhostButtonText.GetComponent<Text>().text = "ゴーストをオフ";//ゴーストオンオフデフォルト
        StartCoroutine("Access");//DBの座標を取得
    }

    public void Update()
    {
        dt += Time.deltaTime * stop;
        if (dt > 0.5) //0.5秒ごとに座標に反映
        {
                var posi = positionData[count];

                Transform myTransform = Ghost.transform;
                Vector3 pos = myTransform.position;

                pos.x = float.Parse(posi.x);
                pos.z = float.Parse(posi.z);
                myTransform.position = pos;

                dt = 0.0f;
                count++;

            if (count == positionData.Count -1)//座標を読み終わったら読み込みを止める
            {
                stop = 0;
                Debug.Log("ゴーストがゴールしました");
            }
        }
    }

    public void Push_Button_Change()//ゴーストオンオフボタン
    {
        on_off_button_bool = !on_off_button_bool;

        if (on_off_button_bool == true)
        {
            Ghost.SetActive(true);
            GhostButtonText.GetComponent<Text>().text = "ゴーストをオフ";
        }
        else
        {
            Ghost.SetActive(false);
            GhostButtonText.GetComponent<Text>().text = "ゴーストをオン";     
        }
    }

    public class Position //配列のリスト
    { 
        public string id { get; set; }
        public string x { get; set; }
        public string y { get; set; }
        public string z { get; set; }
    }

    private IEnumerator Access()　//ゴースト座標の呼び出し
    {
        Debug.Log("Access");
        StartCoroutine(Post("http://localhost/dbaccess/loadghost.php"));

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
                Debug.Log("HttpPost NG;"+ www.error);
            }
            else if (www.isDone)　//エラーがなければリストでデータを取得
            {
                string data = www.downloadHandler.text;
                this.positionData = JsonConvert.DeserializeObject<List<Position>>(data);
            }
        }       
    }
}
