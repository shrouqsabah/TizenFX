namespace Tizen.NUI.BaseComponents.MutableMarkup
{
    public interface IMarkupTagBuilder<T> where T: IMarkupTag
    {
        T Create();
    }
}