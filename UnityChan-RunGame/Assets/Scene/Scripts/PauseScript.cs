using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour
{
	[SerializeField]
	//�@�|�[�Y�������ɕ\������UI�̃v���n�u
	private GameObject pauseUIPrefab;
	private GameObject pauseUIInstance;

	[SerializeField]

	private GameObject canvas;

	void Start()
	{
		Time.timeScale = 1f;
	}
	void Update()
	{
		if (Input.GetKeyDown("q"))//q����������|�[�Y���
		{
			if (pauseUIInstance == null )
			{
				pauseUIInstance = (GameObject) Instantiate (pauseUIPrefab) ;
				pauseUIInstance.transform.SetParent(canvas.transform,false);

				Time.timeScale = 0f;
			}
			else
			{
				Destroy(pauseUIInstance);
				Time.timeScale = 1f;
			}
		}
	}
}
