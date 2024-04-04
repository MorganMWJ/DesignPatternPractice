namespace DesignPatternPractice
{
    internal static class Methods
    {
        /// <summary>
        /// Use of __makeref to create reference to object
        /// then returns a pointer holding the obejct's memory address
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static IntPtr GetMemoryAddress(object o)
        {
            TypedReference tr = __makeref(o);

            unsafe
            {
                IntPtr ptr = **(IntPtr**)(&tr);
                return ptr;
            }
        }

        /// <summary>
        /// use of __arglist without params keyword.
        /// </summary>
        /// <param name="__arglist"></param>
        public static void PrintArgument(__arglist)
        {
            var args = new ArgIterator(__arglist);
            while (args.GetRemainingCount() > 0)
            {
                Console.WriteLine(__refvalue(args.GetNextArg(), int));
            }
        }
    }
}
