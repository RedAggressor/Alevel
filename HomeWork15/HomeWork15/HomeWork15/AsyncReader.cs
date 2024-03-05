namespace HomeWork15
{
    internal class AsyncReader
    {
        private async static Task<string> ReadHelloAsync()
        {
            string text;

            using (var readHello = new StreamReader("Hello.txt"))
            {
                text = await readHello.ReadToEndAsync();
            }

            return text;
        }

        private async static Task<string> ReadWordAsync()
        {
            string text;

            using (var readHello = new StreamReader("Word.txt"))
            {
                text = await readHello.ReadToEndAsync();
            }

            return text;
        }

        public async static Task<string> ConcatinationHelloWordAsync()
        {
            var textHello = await ReadHelloAsync();

            var textWord = await ReadWordAsync();

            return string.Join(' ', textHello, textWord);
        }
    }
}
