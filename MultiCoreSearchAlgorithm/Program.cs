using System;

namespace MultiCoreSearchAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            var trie = new SimplePrefixTrie(); // or new SimpleCompressedPrefixTrie();
            trie.AddWord("hello");
            trie.AddWord("iced");
            trie.AddWord("i");
            trie.AddWord("ice");
            trie.AddWord("icecone");
            trie.AddWord("dtgg");
            trie.AddWord("hicet");
            foreach (var w in trie.FindWordsMatchingPrefixesOf("icedtgg"))
                Console.WriteLine(w);
        }
    }
}
