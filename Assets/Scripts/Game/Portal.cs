namespace Stage
{
	public class Portal : Pickable
	{
		protected override void TriggerEnter(PlayerController pc)
		{
			base.TriggerEnter(pc);
			
			GamePlayManager.Instance.OnTouchPortal(this);
			Destroy(this.gameObject);
		}
	}
}