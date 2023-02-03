using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class GhostButton : MonoBehaviour
{
   private GameObject Ghost ;
   List<Position> positionData = null;

    float px;
    float pz;

    public void Start()
    {
        Ghost = GameObject.Find("Ghost");
    }

    public void Button_Push()
    {
        Debug.Log("ŠJŽn");
        StartCoroutine("Access");

        Transform myTransform = Ghost.transform;

        Vector3 pos = myTransform.position;

        pos.x = px;
        pos.z = pz;

        myTransform.position = pos;
    }

    public class Position
    { 
        public string id { get; set; }
        public string x { get; set; }
        public string y { get; set; }
        public string z { get; set; }
    }

    private IEnumerator Access()
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
            else if (www.isDone)
            {
                string data = www.downloadHandler.text;
                this.positionData = JsonConvert.DeserializeObject<List<Position>>(data);

                foreach (Position position in positionData)
                {
                    Debug.Log($" id={position.id} x={position.x} y={position.y} z={position.z} ");
                }
            }
        }
        
    }
}
