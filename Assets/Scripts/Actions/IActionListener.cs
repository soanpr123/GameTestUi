namespace Assets.Scripts.Actions
{
    public interface IActionListener
    {
        void perform(int idAction, object p);
    }
}