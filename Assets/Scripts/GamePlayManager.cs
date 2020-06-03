using UnityEngine;

namespace Stage
{
	public class GamePlayManager : MonoSingleton<GamePlayManager>
	{
		public int keyCount;
		int collectedKey = 0;

		public GameObject portal;
		public int nextStageId;
		
		protected override void Awake()
		{
			base.Awake();

			instance = this;
		}

		public void OnPickUpKey(Key key)
		{
			collectedKey++;

			if (IsClearStage())
			{
				ShowPortal();
			}
		}

		public void OnTouchPortal(Portal p)
		{
			StageManager.Instance.LoadStage(nextStageId);
		}

		bool IsClearStage()
		{
			return collectedKey >= keyCount;
		}

		void ShowPortal()
		{
			portal.SetActive(true);
		}
	}
}