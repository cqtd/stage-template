using UnityEngine;
using UnityEngine.SceneManagement;

namespace Stage
{
	public class StageManager : MonoSingleton<StageManager>
	{
		
		/// <summary>
		///  씬을 로딩합니다.
		/// 스테이지 아이디가 1보다 작으면 로비를 로딩합니다.
		/// </summary>
		/// <param name="stageID"></param>
		public void LoadStage(int stageID)
		{
			if (stageID < 1)
			{
				SceneManager.LoadScene($"Lobby");
			}
			else
			{
				SceneManager.LoadScene($"Stage_{stageID}");
			}
		}
	}
}