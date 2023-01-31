using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class SavePosition : MonoBehaviour
{
    public GameObject Player;
    public GoalManager Goal;
    public Coll col;

    string xp;
    string yp;
    string zp;

    private float timeleft;

    public void Start()
    {
      Player = GameObject.Find("player");
    }

    public void Update()
    {

        timeleft -= Time.deltaTime;
        if (Goal.isGoal == false && col.Go == false)
        { //�S�[��&GameOver���ĂȂ��Ƃ������L�^

            if (timeleft <= 0.0)
            {
                timeleft = 0.5f;
                //�Z�b���Ƃɍ��W���L�^
                Vector3 posi = Player.transform.position;
                xp = posi.x.ToString();
                yp = posi.y.ToString();
                zp = posi.z.ToString();

                StartCoroutine("Access");

                Debug.Log(xp);
                Debug.Log(yp);
                Debug.Log(zp);
            }
        }
    }

    private IEnumerator Access()
    {
        Dictionary<string, string> dic = new Dictionary<string, string>();
        dic.Add("posx", xp);
        dic.Add("posy", yp);
        dic.Add("posz", zp);

        StartCoroutine(Post("http://localhost/dbaccess/positioninput.php", dic));

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



    

 