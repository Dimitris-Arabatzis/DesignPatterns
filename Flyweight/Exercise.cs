using System;

namespace Coding.Exercise
{
    public class Sentence
    {
        private string[] words;
        public Dictionary<int,WordToken> tokens = new Dictionary<int, WordToken>();

        public Sentence(string plainText)
        {
            words = plainText.Split(' ');
        }

        public WordToken this[int index]
        {
            get
            {
                var token = new WordToken();
                tokens.Add(index, token);
                return token;
            }
        }

        public override string ToString()
        {
            List<string> sentence = new List<string>();
            for (int i = 0; i < words.Length; i++)
            {
                var word = words[i];

                if(tokens.ContainsKey(i) && tokens[i].Capitalize)
                    word = word.ToUpperInvariant();

                sentence.Add(word);
            }
            return string.Join(" ",sentence);
        }

        public class WordToken
        {
            public bool Capitalize;
        }
    }

    class Execute
    {
        static void Main(string[] args)
        {
            var sentence = new Sentence("hello world");
            sentence[1].Capitalize = true;
            Console.WriteLine(sentence); //writes hello WORLD
        }
    }
    
}
