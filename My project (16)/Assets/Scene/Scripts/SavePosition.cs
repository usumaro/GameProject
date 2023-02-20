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

    private float timeleft = 0;
   
    public void Start()
    {
        StartCoroutine("Reset");
        Debug.Log("���W���Z�b�g");
    }

    public void Update()
    { 
        timeleft += Time.deltaTime;
        if (Goal.isGoal == false && col.isGameOver == false)
        { //�S�[��&GameOver���ĂȂ��Ƃ������L�^

            if (timeleft >= 0.5)
            {
                timeleft = 0f;
                //�Z�b���Ƃɍ��W���L�^
                Vector3 posi = Player.transform.position;
                xp = posi.x.ToString();
                yp = posi.y.ToString();
                zp = posi.z.ToString();
                Debug.Log(xp);
                Debug.Log(zp);
                StartCoroutine("Access");
            }
        }
    }

    private IEnumerator Access()
    {�@�@//���W���������c�a�ɑ��M
        Dictionary<string, string> dic = new Dictionary<string, string>();
        dic.Add("posx", xp);
        dic.Add("posy", yp);
        dic.Add("posz", zp);

        StartCoroutine(Post("http://localhost/dbaccess/positioninput.php", dic));

        yield return 0;
    }

    private IEnumerator Reset()
    {   //�J�n���ɍ��W�f�[�^��������
        StartCoroutine(Post2("http://localhost/dbaccess/resetpositiontable.php"));

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

    private IEnumerator Post2(string url)
    {
        yield return 0;
    }
}