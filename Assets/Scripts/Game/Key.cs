namespace Stage
{
	public class Key : Pickable
	{
		protected override void TriggerEnter(PlayerController pc)
		{
			base.TriggerEnter(pc);
			
			GamePlayManager.Instance.OnPickUpKey(this);
			Destroy(this.gameObject);
		}
	}
}