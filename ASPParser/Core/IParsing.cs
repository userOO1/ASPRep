using Parser.Core.ss;

namespace ASPParser.Core
{
    public interface IParsing<T>
    {
        Task<List<T>> Worker();
    }
}
