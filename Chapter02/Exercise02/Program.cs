using static System.Console;

WriteLine(String.Format("{0,-10}{1,15}{2,18}{3,30}", "Type", "Byte(s) of memory", "Min", "Max"));
WriteLine(String.Format("{0,10}", "---------------------------------------------------------------------------"));
WriteLine(String.Format("{0,-10}{1,-5}{2,30}{3,30}", "sbyte", sizeof(sbyte), sbyte.MinValue, sbyte.MaxValue));
WriteLine(String.Format("{0,-10}{1,-5}{2,30}{3,30}", "byte", sizeof(byte), byte.MinValue, byte.MaxValue));
WriteLine(String.Format("{0,-10}{1,-5}{2,30}{3,30}", "short", sizeof(short), short.MinValue, short.MaxValue));
WriteLine(String.Format("{0,-10}{1,-5}{2,30}{3,30}", "ushort", sizeof(ushort), ushort.MinValue, ushort.MaxValue));
WriteLine(String.Format("{0,-10}{1,-5}{2,30}{3,30}", "int", sizeof(int), int.MinValue, int.MaxValue));
WriteLine(String.Format("{0,-10}{1,-5}{2,30}{3,30}", "uint", sizeof(uint), uint.MinValue, uint.MaxValue));
WriteLine(String.Format("{0,-10}{1,-5}{2,30}{3,30}", "long", sizeof(long), long.MinValue, long.MaxValue));
WriteLine(String.Format("{0,-10}{1,-5}{2,30}{3,30}", "ulong", sizeof(ulong), ulong.MinValue, ulong.MaxValue));
WriteLine(String.Format("{0,-10}{1,-5}{2,30}{3,30}", "float", sizeof(float), float.MinValue, float.MaxValue));
WriteLine(String.Format("{0,-10}{1,-5}{2,30}{3,30}", "double", sizeof(double), double.MinValue, double.MaxValue));
WriteLine(String.Format("{0,-10}{1,-5}{2,30}{3,30}", "decimal", sizeof(decimal), decimal.MinValue, decimal.MaxValue));
WriteLine(String.Format("{0,10}", "---------------------------------------------------------------------------"));