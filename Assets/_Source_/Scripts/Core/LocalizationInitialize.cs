using GamePush;
using Lean.Localization;
using UnityEngine;

namespace Core.Localization
{
    public class LocalizationInitialize : MonoBehaviour
    {
        private const string EnglishCode = "English";
        private const string RussinCode = "Russian";
        private const string TurkishCode = "Turkish";

        [SerializeField] private LeanLocalization _leanLocalization;

        private void Awake()
        {
            ChangeLenguage();
        }

        private void ChangeLenguage()
        {
            Language language = GP_Language.Current();

            switch (language)
            {
                case Language.English:
                    _leanLocalization.SetCurrentLanguage(EnglishCode);
                    break;
                case Language.Russian:
                    _leanLocalization.SetCurrentLanguage(RussinCode);
                    break;
                case Language.Turkish:
                    _leanLocalization.SetCurrentLanguage(TurkishCode);
                    break;
                default:
                    _leanLocalization.SetCurrentLanguage(EnglishCode);
                    break;
            }
        }
    }
}