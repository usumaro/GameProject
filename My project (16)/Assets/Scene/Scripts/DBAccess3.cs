using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class DBAccess3 : MonoBehaviour
{
   
    public GameObject Player;
    public GoalManager goal;

    float xp;
    float yp;
    float zp;

    private float timeleft;



    public void Start()
    {

        Player = GameObject.Find("Player");
        
        
      

        

        
      
    }

    public void Update()
    {

        timeleft -= Time.deltaTime;

        //ÅZïbÇ≤Ç∆Ç…ç¿ïWÇãLò^
        if (timeleft <= 0.0 && goal.isGoal == false)
        {
            timeleft = 0.5f;

            Vector3 posi = transform.position;
            xp = posi.x;
            yp = posi.y;
            zp = posi.z;

            StartCoroutine("Access");

        }
    
    
    }

    private IEnumerator Access()
    {
        Dictionary<string, float> dic = new Dictionary<string, float>();
        dic.Add("posx", xp);
        dic.Add("posy", yp);
        dic.Add("posz", zp);

        StartCoroutine(Post("http://localhost/dbaccess/selecttest3.php", dic));
      

        yield return 0;
    }

    private IEnumerator Post(string url, Dictionary<string, float> post)
    {
        WWWForm form = new WWWForm();
        foreach (KeyValuePair<string, float> post_arg in post)
        {
            form.AddField(post_arg.Key, post_arg.Value);
        }

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

        }


    }



}



    

