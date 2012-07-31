﻿namespace ServiceBook.Registrations.Algorithms.Implementations
{
    public class Node<T>
    {
        public readonly T Value;
        readonly int _index;

        public Node(int index, T value)
        {
            _index = index;
            Value = value;
        }

        public int CompareTo(DependencyGraphNode<T> other)
        {
            return !Equals(other)
                       ? 0
                       : -1;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;

            return false;
        }

        public override int GetHashCode()
        {
            return _index;
        }
    }
}