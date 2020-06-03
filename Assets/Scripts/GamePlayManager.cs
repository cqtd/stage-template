using UnityEngine;

namespace Stage
{
	public class GamePlayManager : MonoSingleton<GamePlayManager>
	{
		// 이 스테이지에서 모아야 하는 키 개수를 정합니다.
		public int keyCount;
		
		// 포탈 오브젝트입니다
		public GameObject portal;
		
		// 다음 스테이지의 아이디 값을 정해둡니다.
		public int nextStageId;
		
		int collectedKey = 0;

		/// <summary>
		/// 싱글턴 오브젝트이지만 동적으로 생성되지 않기 때문에 Awake에서 instance 를 넣어줍니다.
		/// </summary>
		protected override void Awake()
		{
			base.Awake();

			instance = this;
		}

		/// <summary>
		/// 플레이어가 Key 를 먹을때 호출됩니다.
		/// </summary>
		/// <param name="key"></param>
		public void OnPickUpKey(Key key)
		{
			// 모은 키를 하나 추가합니다.
			collectedKey++;

			// 키를 다 모았으면
			if (IsClearStage())
			{
				// 포탈을 활성화합니다.
				ShowPortal();
			}
		}

		/// <summary>
		/// 플레이어가 포탈에 도착하면 호출됩니다.
		/// </summary>
		/// <param name="p"></param>
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