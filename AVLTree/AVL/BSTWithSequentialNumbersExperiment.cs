using System;
using System.Collections.Generic;
using System.Diagnostics;
using ConsoleTester.Trees;

namespace ConsoleTester
{
    public class BSTWithSequentialNumbersExperiment
    {
        private readonly int _n;
        private readonly Random _random = new();
        private readonly ITree _tree;
        
        public BSTWithSequentialNumbersExperiment(ITree tree, int n)
        {
            _n = n;
            _tree = tree;
        }

        public void Insert()
        {
            var watcher = Stopwatch.StartNew();
            for (int i = 0; i < _n; ++i)
                _tree.Insert(i);

            watcher.Stop();
            
            Console.WriteLine($"Experiment {this.GetType().Name}, Insert - {watcher.ElapsedMilliseconds} ms");
        }
        
        public void Search()
        {
            var watcher = Stopwatch.StartNew();
            for(int i = 0; i < _n / 10; ++i)
                _tree.Search(_random.Next(0, _n));
            
            watcher.Stop();
            
            Console.WriteLine($"Experiment {this.GetType().Name}, Search - {watcher.ElapsedMilliseconds} ms");
        }
        
        public void Remove()
        {
            var watcher = Stopwatch.StartNew();
            for(int i = 0; i < _n / 10; ++i)
                _tree.Remove(_random.Next(0, _n));
            
            watcher.Stop();
            
            Console.WriteLine($"Experiment {this.GetType().Name}, Remove - {watcher.ElapsedMilliseconds} ms");
        }
        
    }
}