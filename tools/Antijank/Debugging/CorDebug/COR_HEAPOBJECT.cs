using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace Antijank.Debugging {

  [StructLayout(LayoutKind.Sequential, Pack = 4)]
  [PublicAPI]
  public struct COR_HEAPOBJECT {

    public ulong address; // The address (in heap) of the object.

    public ulong size; // The total size of the object.

    public COR_TYPEID type; // The fully instantiated type of the object.

  }

}