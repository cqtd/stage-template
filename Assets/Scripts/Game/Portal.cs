namespace Stage
{
	public class Portal : Pickable
	{
		/// <summary>
		/// Pickable 클래스에서 OnTriggerEnter을 호출합니다.
		/// Trigger 된 오브젝트가 PlayerController인 경우
		/// 그 OnTriggerEnter 메서드에서 이 TriggerEnter를 호출해줍니다.
		/// </summary>
		/// <param name="pc"></param>
		protected override void TriggerEnter(PlayerController pc)
		{
			base.TriggerEnter(pc);
			
			// 게임 플레이 매니저에게 포탈에 도착했다고 알립니다.
			GamePlayManager.Instance.OnTouchPortal(this);
			
			// 포탈을 파괴합니다.
			Destroy(this.gameObject);
		}
	}
}