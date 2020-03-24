using System;
using System.Collections.Generic;
using UnityEngine;

namespace Geekbrains
{

    public sealed class PlayerModel : BaseObjectScene
    {
        private IMotor _motor = null;


        public IMotor Motor
        {
            get => _motor;
            set
            {
                if (_motor != null) return;
                _motor = value;
            }
        }

    }

}