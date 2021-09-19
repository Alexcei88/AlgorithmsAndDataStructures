using System;
using System.Collections.Generic;
using System.Diagnostics;
using ConsoleTester.Trees;

namespace ConsoleTester
{
    public class BSTWithRandomNumbersExperiment
    {
        private readonly int _n;
        private readonly Random _random = new();
        private readonly ITree _tree;
        private readonly List<int> _numbers;
        
        public BSTWithRandomNumbersExperiment(ITree tree, int n)
        {
            _n = n;
            _numbers = new List<int>(n);
            _tree = tree;
        }

        public void Insert()
        {
            var watcher = Stopwatch.StartNew();
            for (int i = 0; i < _n; ++i)
            {
                var number = _random.Next();
                _numbers.Add(number);
                _tree.Insert(number);
            }

            watcher.Stop();
            
            Console.WriteLine($"Experiment {this.GetType().Name}, Insert - {watcher.ElapsedMilliseconds} ms");
        }
        
        public void Search()
        {
            var watcher = Stopwatch.StartNew();
            for(int i = 0; i < _n / 10; ++i)
                _tree.Search(_numbers[_random.Next(0, _numbers.Count)]);
            
            watcher.Stop();
            
            Console.WriteLine($"Experiment {this.GetType().Name}, Search - {watcher.ElapsedMilliseconds} ms");
        }
        
        public void Remove()
        {
            var watcher = Stopwatch.StartNew();
            for(int i = 0; i < _n / 10; ++i)
                _tree.Remove(_numbers[_random.Next(0, _numbers.Count)]);
            
            watcher.Stop();
            
            Console.WriteLine($"Experiment {GetType().Name}, Remove - {watcher.ElapsedMilliseconds} ms");
        }
        
    }
}