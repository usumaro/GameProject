using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour
{
	[SerializeField]
	//　ポーズした時に表示するUIのプレハブ
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
		if (Input.GetKeyDown("q"))//qを押したらポーズ画面
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
