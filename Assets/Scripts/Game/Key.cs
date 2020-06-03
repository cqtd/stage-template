namespace Stage
{
	public class Key : Pickable
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
			
			// 게임 플레이 매니저에게 이 오브젝트가 PickUp 되었다고 알립니다.
			GamePlayManager.Instance.OnPickUpKey(this);
			
			// 이 오브젝트를 삭제합니다.
			Destroy(this.gameObject);
		}
	}
}