namespace ServiceBook
{
    using Factories;
    using Registrations;

    public static class PartialFactoryExtensions
    {
        public static Factory<T> ApplyPartial<T,T1>(this Factory<T,T1> source, Registration registration)
        {
            var partial = new PartialFactory<T,T1>(source, registration.GetFactory<T1>());

            return partial;
        }

        public static Factory<T,T1> ApplyPartial<T,T1,T2>(this Factory<T,T1,T2> source, Registration registration)
        {
            var partial = new PartialFactory<T,T1,T2>(source, registration.GetFactory<T2>());

            return partial;
        }

        public static Factory<T,T1,T2> ApplyPartial<T,T1,T2,T3>(this Factory<T,T1,T2,T3> source, Registration registration)
        {
            var partial = new PartialFactory<T,T1,T2,T3>(source, registration.GetFactory<T3>());

            return partial;
        }

        public static Factory<T,T1,T2,T3> ApplyPartial<T,T1,T2,T3,T4>(this Factory<T,T1,T2,T3,T4> source, Registration registration)
        {
            var partial = new PartialFactory<T,T1,T2,T3,T4>(source, registration.GetFactory<T4>());

            return partial;
        }

        public static Factory<T,T1,T2,T3,T4> ApplyPartial<T,T1,T2,T3,T4,T5>(this Factory<T,T1,T2,T3,T4,T5> source, Registration registration)
        {
            var partial = new PartialFactory<T,T1,T2,T3,T4,T5>(source, registration.GetFactory<T5>());

            return partial;
        }

        public static Factory<T,T1,T2,T3,T4,T5> ApplyPartial<T,T1,T2,T3,T4,T5,T6>(this Factory<T,T1,T2,T3,T4,T5,T6> source, Registration registration)
        {
            var partial = new PartialFactory<T,T1,T2,T3,T4,T5,T6>(source, registration.GetFactory<T6>());

            return partial;
        }

        public static Factory<T,T1,T2,T3,T4,T5,T6> ApplyPartial<T,T1,T2,T3,T4,T5,T6,T7>(this Factory<T,T1,T2,T3,T4,T5,T6,T7> source, Registration registration)
        {
            var partial = new PartialFactory<T,T1,T2,T3,T4,T5,T6,T7>(source, registration.GetFactory<T7>());

            return partial;
        }

        public static Factory<T,T1,T2,T3,T4,T5,T6,T7> ApplyPartial<T,T1,T2,T3,T4,T5,T6,T7,T8>(this Factory<T,T1,T2,T3,T4,T5,T6,T7,T8> source, Registration registration)
        {
            var partial = new PartialFactory<T,T1,T2,T3,T4,T5,T6,T7,T8>(source, registration.GetFactory<T8>());

            return partial;
        }

        public static Factory<T,T1,T2,T3,T4,T5,T6,T7,T8> ApplyPartial<T,T1,T2,T3,T4,T5,T6,T7,T8,T9>(this Factory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9> source, Registration registration)
        {
            var partial = new PartialFactory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9>(source, registration.GetFactory<T9>());

            return partial;
        }

        public static Factory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9> ApplyPartial<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10>(this Factory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10> source, Registration registration)
        {
            var partial = new PartialFactory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10>(source, registration.GetFactory<T10>());

            return partial;
        }

        public static Factory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10> ApplyPartial<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11>(this Factory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11> source, Registration registration)
        {
            var partial = new PartialFactory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11>(source, registration.GetFactory<T11>());

            return partial;
        }

        public static Factory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11> ApplyPartial<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12>(this Factory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12> source, Registration registration)
        {
            var partial = new PartialFactory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12>(source, registration.GetFactory<T12>());

            return partial;
        }

        public static Factory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12> ApplyPartial<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13>(this Factory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13> source, Registration registration)
        {
            var partial = new PartialFactory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13>(source, registration.GetFactory<T13>());

            return partial;
        }

        public static Factory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13> ApplyPartial<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14>(this Factory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14> source, Registration registration)
        {
            var partial = new PartialFactory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14>(source, registration.GetFactory<T14>());

            return partial;
        }

        public static Factory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14> ApplyPartial<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,T15>(this Factory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,T15> source, Registration registration)
        {
            var partial = new PartialFactory<T,T1,T2,T3,T4,T5,T6,T7,T8,T9,T10,T11,T12,T13,T14,T15>(source, registration.GetFactory<T15>());

            return partial;
        }

    }
}