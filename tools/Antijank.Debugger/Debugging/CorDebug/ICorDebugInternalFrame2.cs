﻿using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;


namespace Antijank.Debugging {

  [Guid("C0815BDC-CFAB-447E-A779-C116B454EB5B")]
  [SuppressUnmanagedCodeSecurity]
  [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
  [ComImport]
  
  public interface ICorDebugInternalFrame2 {

    [MethodImpl(MethodImplOptions.InternalCall)]
    void GetAddress(out ulong pAddress);

    [MethodImpl(MethodImplOptions.InternalCall)]
    void IsCloserToLeaf([MarshalAs(UnmanagedType.Interface)] [In]
      ICorDebugFrame pFrameToCompare, out int pIsCloser);

  }

}