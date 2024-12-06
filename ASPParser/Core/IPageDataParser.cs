using Parser.Core.ss;

namespace ASPParser.Core
{
    public interface IPageDataParser<T>
    {
        Task<List<T>> Worker();
    }
}
