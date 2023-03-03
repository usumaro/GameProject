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
    private bool on_off_button_bool;//�S�[�X�g�I���I�t
    int count = 0;//�J�E���^�[
    int stop = 1;//deltatime�X�g�b�v�p

    public void Start()
    {
        Ghost = GameObject.Find("Ghost");
        GhostButtonText = GameObject.Find("GhostButtonText");
        on_off_button_bool = true;//�S�[�X�g�I���I�t
        GhostButtonText.GetComponent<Text>().text = "�S�[�X�g���I�t";//�S�[�X�g�I���I�t�f�t�H���g
        StartCoroutine("Access");//DB�̍��W���擾
    }

    public void Update()
    {
        dt += Time.deltaTime * stop;
        if (dt > 0.5) //0.5�b���Ƃɍ��W�ɔ��f
        {
                var posi = positionData[count];

                Transform myTransform = Ghost.transform;
                Vector3 pos = myTransform.position;

                pos.x = float.Parse(posi.x);
                pos.z = float.Parse(posi.z);
                myTransform.position = pos;

                dt = 0.0f;
                count++;

            if (count == positionData.Count -1)//���W��ǂݏI�������ǂݍ��݂��~�߂�
            {
                stop = 0;
                Debug.Log("�S�[�X�g���S�[�����܂���");
            }
        }
    }

    public void Push_Button_Change()//�S�[�X�g�I���I�t�{�^��
    {
        on_off_button_bool = !on_off_button_bool;

        if (on_off_button_bool == true)
        {
            Ghost.SetActive(true);
            GhostButtonText.GetComponent<Text>().text = "�S�[�X�g���I�t";
        }
        else
        {
            Ghost.SetActive(false);
            GhostButtonText.GetComponent<Text>().text = "�S�[�X�g���I��";     
        }
    }

    public class Position //�z��̃��X�g
    { 
        public string id { get; set; }
        public string x { get; set; }
        public string y { get; set; }
        public string z { get; set; }
    }

    private IEnumerator Access()�@//�S�[�X�g���W�̌Ăяo��
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
            else if (www.isDone)�@//�G���[���Ȃ���΃��X�g�Ńf�[�^���擾
            {
                string data = www.downloadHandler.text;
                this.positionData = JsonConvert.DeserializeObject<List<Position>>(data);
            }
        }       
    }
}
