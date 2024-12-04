using Sound;
using UnityEngine;

namespace UI.Game.Buttons
{
    public class VolumeSoundButton : ButtonView
    {
        [SerializeField] private GameObject _on;
        [SerializeField] private GameObject _off;

        protected override void OnEnable()
        {
            base.OnEnable();

            _off.SetActive(!BackgroundSound.Instance.IsPlaying);
            _on.SetActive(BackgroundSound.Instance.IsPlaying);
        }

        protected override void OnClick()
        {
            if (BackgroundSound.Instance.IsPlaying)
                BackgroundSound.Instance.OffVolume();
            else
                BackgroundSound.Instance.OnVolume();

            _off.SetActive(!BackgroundSound.Instance.IsPlaying);
            _on.SetActive(BackgroundSound.Instance.IsPlaying);
        }
    }
}
