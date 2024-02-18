namespace AppControleFinanceiro.Utilities.FixBugs
{
    public class FixKeyboards
    {
        public static void HideKeyboard()
        {
#if ANDROID
              if (Platform.CurrentActivity.CurrentFocus != null)
              {
                  Platform.CurrentActivity.DismissKeyboardShortcutsHelper();
              }
#endif
        }
    }
}