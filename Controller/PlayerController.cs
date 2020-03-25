using UnityEngine;

namespace Geekbrains
{
	public class PlayerController : BaseController, IExecute, IInitialization
	{
		private IMotor _motor;
		public PlayerModel PlayerModel { get; private set; }

		public PlayerController(){}
		
		public PlayerController(IMotor motor)
		{
			_motor = motor;
		}

		public void Execute()
		{
			if(!IsActive) {return;}
			PlayerModel.Motor.Move();
		}
		public void Initialization()
		{
			PlayerModel = Object.FindObjectOfType<PlayerModel>();
			PlayerModel.Motor = _motor;
		}
	}
}