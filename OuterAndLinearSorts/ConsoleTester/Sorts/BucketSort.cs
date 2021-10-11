using System.Collections.Generic;
using System.Linq;

namespace ConsoleTester.Sorts
{
    public class BucketSort
        : ISort
    {
        public ushort[] Sort(ushort[] input)
        {
            var max = FindMax(input);
            var buckets = FillBuckets(input, max);

            long curIndex = 0;
            foreach (var bucket in buckets)
            {
                foreach (var a in bucket)
                {
                    input[curIndex++] = a;
                }
            }

            return input;
        }

        private ushort FindMax(ushort[] input)
        {
            var max = input.First();
            foreach (var a in input)
            {
                if (a > max)
                    max = a;
            }

            return max;
        }

        private LinkedList<ushort>[] FillBuckets(ushort[] input, ushort max)
        {
            var length = input.Length;
            double maxPlusOne = max + 1;
            var buckets = new LinkedList<ushort>[length];
            for (int i = 0; i < buckets.Length; ++i)
                buckets[i] = new LinkedList<ushort>();
            
            foreach (var a in input)
            {
                long bucketNumber = (long)(length * (a / maxPlusOne));
                AddNumberToBucket(buckets[bucketNumber], a);
            }

            return buckets;
        }

        private void AddNumberToBucket(LinkedList<ushort> bucket, ushort current)
        {
            if (bucket.Last != null)
                for (LinkedListNode<ushort> node = bucket.First; node != bucket.Last.Next; node = node.Next)
                {
                    if (current < node.Value)
                    {
                        bucket.AddBefore(node, current);
                        return;
                    }
                }

            bucket.AddLast(current);
        }
    }
}