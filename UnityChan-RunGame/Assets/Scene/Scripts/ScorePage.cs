using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ScorePage : MonoBehaviour
{
  
    List<Position> positionData = null;

    public void Start()
    {
        StartCoroutine("Access");//DB�̍��W���擾
    }

    public class Position //�z��̃��X�g
    {
        public string id { get; set; }
        public string name { get; set; }
        public string time { get; set; }
        public string time_date { get; set; }
    }

    private IEnumerator Access()�@//�S�[�X�g���W�̌Ăяo��
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
                this.positionData = JsonConvert.DeserializeObject<List<Position>>(data);
            }
        }
    }
}
