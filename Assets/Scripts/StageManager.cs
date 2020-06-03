using UnityEngine;
using UnityEngine.SceneManagement;

namespace Stage
{
	public class StageManager : MonoSingleton<StageManager>
	{
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