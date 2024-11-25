using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AngleSharp.Html.Parser;
using ASPParser.Core;
using Parser.Core.ss;


namespace Parser.Core
{
    public class Parsing<T> : IParsing<T> where T : class
    {
        private readonly IParser<T> _parser; // Сделаем поле приватным и readonly

        #region Properties

        // Сделаем свойство только для чтения, если установка не требуется
        public IParser<T> Parser => _parser;

        #endregion

        // Конструктор
        public Parsing(IParser<T> parser)
        {
            _parser = parser ?? throw new ArgumentNullException(nameof(parser)); // Проверка на null
        }

        // Асинхронный метод для парсинга
        public async Task<List<T>> Worker()
        {
            var lines = new List<T>();
            for (int i = 1; i <= 5; i++)
            {
                var source = await HtmlLoader.GetSourceByPageId(i);
                var domParser = new HtmlParser();
                var document = await domParser.ParseDocumentAsync(source);
                var result = _parser.Parse(document);

                if (result != null) // Проверка на null
                {
                    lines.Add(result);
                }
            }
            return lines;
        }
    }
}