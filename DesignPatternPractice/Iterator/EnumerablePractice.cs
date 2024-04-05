using MorganMWJ.DesignPatternPracitce.Prototype_Clone;
using System.Collections;

namespace DesignPatternPractice.Iterator
{
    // Collection of Car objects. This class
    // implements IEnumerable so that it can be used
    // with ForEach syntax.
    internal class Cars : IEnumerable
    {
        private Car[] _cars;

        public Cars(Car[] cars)
        {
            _cars = cars;
        }

        public CarEnumerator GetEnumerator()
        {
            return new CarEnumerator(_cars);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    internal class CarEnumerator : IEnumerator
    {
        // Enumerators are positioned before the first element
        // until the first MoveNext() call.
        int position = -1;

        private readonly Car[] _cars;

        public CarEnumerator(Car[] cars)
        {
            _cars = cars;
        }

        public object Current => _cars[position];

        public bool HasMore => position < _cars.Length;

        public bool MoveNext()
        {
            position++;
            return HasMore;
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
