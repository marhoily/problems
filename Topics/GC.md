At which moment the memory allocated for objects o1 and o2 in functions F1 and F2 is going to be released?

class Class : IDisposable { /* … */ }
struct Struct : IDisposable { /* … */ }

void F1(Class o2)
{
  Class o1 = new Class();
  // here o1 and o2 are being used
  o1.Dispose();
  o1 = null;
  o2.Dispose();
  o2 = null;
}

void F2(Struct o2)
{
  Struct o1 = new Struct();
  // here o1 and o2 are being used
  o1.Dispose();
  o1 = null;
  o2.Dispose();
  o2 = null;
}

