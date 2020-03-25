using UnityEngine;

namespace Geekbrains
{

    public sealed class HighlightController : BaseController, IInitialization, IExecute
    {
        private HighlightUI _highlightUI;
        private Transform _transform;
        private IHighlitable _infoCastCollider;

        public void Initialization()
        {
            _highlightUI = Object.FindObjectOfType<HighlightUI>();
            _transform = ServiceLocator.Resolve<PlayerController>().PlayerModel.Transform;

        }

        public override void On()
        {
            if (IsActive) return;
            base.On();
            _highlightUI.SetActive(true);
            if (!InfoCast()) Off();
        }

        public override void Off()
        {
            if (!IsActive) return;
            base.Off();
            _infoCastCollider = null;
            _highlightUI.SetActive(false);

        }
        public bool InfoCast()
        {
            RaycastHit rayCastHit;
            Physics.Raycast(_transform.position, _transform.forward, out rayCastHit);
            if (rayCastHit.collider != null)
            {
                if (rayCastHit.collider.gameObject.TryGetComponent<IHighlitable>(out _infoCastCollider))
                    return true;
            }
            _infoCastCollider = null;
            return false;
        }

        public void Execute()
        {
            if (!IsActive) return;
            if(_infoCastCollider != null)
            {
                _highlightUI.Text = _infoCastCollider.Highlight();
            }
            else
            {
                _highlightUI.Text = "";
            }
        }

    }

}