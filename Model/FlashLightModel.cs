using System;
using UnityEngine;


namespace Geekbrains
{
    public sealed class FlashLightModel : BaseObjectScene
    {
        [SerializeField] private float _speed = 11.0f;
        [SerializeField] private float _batteryChargeMax;
        [SerializeField] private float _batteryEmptyingCoef = 1.0f;
        [SerializeField] private float _batteryChargingCoef = 1.0f; 
        private Light _light;
        private Transform _goFollow;
        private Vector3 _vecOffset;
        public float BatteryChargeCurrent { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            _light = GetComponent<Light>();
            _goFollow = Camera.main.transform;
            _vecOffset = Transform.position - _goFollow.position;
            BatteryChargeCurrent = _batteryChargeMax;
        }

        public void Switch(FlashLightActiveType value)
        {
            switch (value)
            {
                case FlashLightActiveType.On:
                    _light.enabled = true;
                    Transform.position = _goFollow.position + _vecOffset;
                    Transform.rotation = _goFollow.rotation;
                    break;
                case FlashLightActiveType.Off:
                    _light.enabled = false;

                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, null);
            }
        }

        public void Rotation()
        {
            Transform.position = _goFollow.position + _vecOffset;
            Transform.rotation = Quaternion.Lerp(Transform.rotation,
                _goFollow.rotation, _speed * Time.deltaTime);
        }

        public bool EditBatteryCharge()
        {
            if (BatteryChargeCurrent > 0)
            {
                BatteryChargeCurrent -= Time.deltaTime * _batteryEmptyingCoef;
                return true;
            }
            return false;
        }

        public void Recharge()
        {
            if (_batteryChargeMax > BatteryChargeCurrent)
                BatteryChargeCurrent += Time.deltaTime * _batteryChargingCoef;
            
        }
    }
}
