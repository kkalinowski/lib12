using System;
using lib12.Extensions;

namespace lib12.Misc
{
    public enum LocationInRange
    {
        LessThanStart,
        OnStart,
        InRange,
        OnEnd,
        GreaterThanEnd
    }

    public struct Range<T> where T : IComparable
    {
        public T Start;
        public T End;

        public Range(T a, T b)
        {
            if (a.CompareTo(b) < 0)
            {
                Start = a;
                End = b;
            }
            else
            {
                Start = b;
                End = a;
            }
        }

        public LocationInRange LocateInRange(T item)
        {
            if (item.CompareTo(Start) < 0)
                return LocationInRange.LessThanStart;
            else if (item.CompareTo(Start) == 0)
                return LocationInRange.OnStart;
            else if (item.CompareTo(End) < 0)
                return LocationInRange.InRange;
            else if (item.CompareTo(End) == 0)
                return LocationInRange.OnEnd;
            else
                return LocationInRange.GreaterThanEnd;
        }

        public bool InRange(T item, bool inclusiveStartAndEnd = true)
        {
            if (inclusiveStartAndEnd)
                return LocateInRange(item).Is(LocationInRange.OnStart, LocationInRange.InRange, LocationInRange.OnEnd);
            else
                return LocateInRange(item).Is(LocationInRange.InRange);
        }

        public bool OutsideOfRange(T item, bool inclusiveStartAndEnd = true)
        {
            return !InRange(item, inclusiveStartAndEnd);
        }

        public bool LessThanStart(T item)
        {
            return LocateInRange(item).Is(LocationInRange.LessThanStart);
        }

        public bool GreaterThanEnd(T item)
        {
            return LocateInRange(item).Is(LocationInRange.GreaterThanEnd);
        }
    }
}