using Parser.Core.ss;

namespace ASPParser.Core
{
    public interface IParsing<T>
    {
        Task<T> Worker();
    }
}
