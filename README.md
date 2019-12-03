# MultiCoreSearchAlgorithm
The full benchmark code can be found in this gist. The results of running it with dictionaries of 10,000, 100,000, and 1,000,000 (randomly generated character sequence) words and searching for all prefix matches of 5,000 terms are:

Matching 5000 words to dictionary of 10000 terms of max length 25

        Method              Memory (MB)         Build Time (s)         Lookup Time (s)
        ---------------------------------------------------------------------------------
        Naive               0.64-0.64, 0.64     0.001-0.002, 0.001     6.136-6.312, 6.210
        JimMischel          0.84-0.84, 0.84     0.013-0.018, 0.016     0.083-0.113, 0.102
        JimMattyDSL         0.80-0.81, 0.80     0.013-0.018, 0.016     0.008-0.011, 0.010
        SimpleTrie          24.55-24.56, 24.56  0.042-0.056, 0.051     0.002-0.002, 0.002
        CompessedTrie       1.84-1.84, 1.84     0.003-0.003, 0.003     0.002-0.002, 0.002
        MattyMerrix         0.83-0.83, 0.83     0.017-0.017, 0.017     0.034-0.034, 0.034
  
Matching 5000 words to dictionary of 100000 terms of max length 25

       Method              Memory (MB)            Build Time (s)         Lookup Time (s)
       ---------------------------------------------------------------------------------------
       Naive               6.01-6.01, 6.01        0.024-0.026, 0.025     65.651-65.758, 65.715
       JimMischel          6.32-6.32, 6.32        0.232-0.236, 0.233     1.208-1.254, 1.235
       JimMattyDSL         5.95-5.96, 5.96        0.264-0.269, 0.266     0.050-0.052, 0.051
       SimpleTrie          226.49-226.49, 226.49  0.932-0.962, 0.951     0.004-0.004, 0.004
       CompessedTrie       16.10-16.10, 16.10     0.101-0.126, 0.111     0.003-0.003, 0.003
       MattyMerrix         6.15-6.15, 6.15        0.254-0.269, 0.259     0.414-0.418, 0.416
  
Matching 5000 words to dictionary of 1000000 terms of max length 25

       Method              Memory (MB)                Build Time (s)          Lookup Time (s)
       --------------------------------------------------------------------------------------------
       JimMischel          57.69-57.69, 57.69         3.027-3.086, 3.052      16.341-16.415, 16.373
       JimMattyDSL         60.88-60.88, 60.88         3.396-3.484, 3.453      0.399-0.400, 0.399
       SimpleTrie          2124.57-2124.57, 2124.57   11.622-11.989, 11.860   0.006-0.006, 0.006
       CompessedTrie       166.59-166.59, 166.59      2.813-2.832, 2.823      0.005-0.005, 0.005
       MattyMerrix         62.71-62.73, 62.72         3.230-3.270, 3.251      6.996-7.015, 7.008
       
As you can see, memory required for the (non-space optimized) tries is substantially higher. It increases by the size of the dictionary, O(N) for all of the tested implementations.

As expected, lookup time for the tries is more or less constant: O(k), dependent on the length of the search terms only. For the other implementations, time will increase based on the size of the dictionary to be searched.

Note that far more optimal implementations for this problem can be constructed, that will be close to O(k) for search time and allow a more compact storage and reduced memory footprint. If you map to a reduced alphabet (e.g. 'A'-'Z' only), this is also something that can be taken advantage of.
