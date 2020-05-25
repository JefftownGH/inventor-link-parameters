////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) Autodesk, Inc. All rights reserved 
// Written by Jan Liska & Philippe Leefsma 2011 - ADN/Developer Technical Services
//
// This software is provided as is, without any warranty that it will work. You choose to use this tool at your own risk.
// Neither Autodesk nor the authors can be taken as responsible for any damage this tool can cause to 
// your data. Please always make a back up of your data prior to use this tool.
//
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LinkParameters
{
    class WinUtilities : IWin32Window
    {
        public WinUtilities(IntPtr handle)
        {
            Handle = handle;
        }

        public IntPtr Handle 
        { 
            get; 
            private set; 
        }
    }

    sealed class PictureDispConverter
    {
        [DllImport("OleAut32.dll", 
            EntryPoint = "OleCreatePictureIndirect", 
            ExactSpelling = true, 
            PreserveSig = false)]
        private static extern stdole.IPictureDisp 
            OleCreatePictureIndirect(
                [MarshalAs(UnmanagedType.AsAny)] object picdesc,
                ref Guid iid,
                [MarshalAs(UnmanagedType.Bool)] bool fOwn);

        static Guid iPictureDispGuid = typeof(stdole.IPictureDisp).GUID;

        private static class PICTDESC
        {
          //Picture Types
          public const short PICTYPE_UNINITIALIZED = -1;
          public const short PICTYPE_NONE = 0;
          public const short PICTYPE_BITMAP = 1;
          public const short PICTYPE_METAFILE = 2;
          public const short PICTYPE_ICON = 3;
          public const short PICTYPE_ENHMETAFILE = 4;

          [StructLayout(LayoutKind.Sequential)]
          public class Icon
          {
            internal int cbSizeOfStruct = Marshal.SizeOf(typeof(PICTDESC.Icon));
            internal int picType = PICTDESC.PICTYPE_ICON;
            internal IntPtr hicon = IntPtr.Zero;
            internal int unused1;
            internal int unused2;

            internal Icon(System.Drawing.Icon icon)
            {
              this.hicon = icon.ToBitmap().GetHicon();
            }
          }

          [StructLayout(LayoutKind.Sequential)]
          public class Bitmap
          {
            internal int cbSizeOfStruct = Marshal.SizeOf(typeof(PICTDESC.Bitmap));
            internal int picType = PICTDESC.PICTYPE_BITMAP;
            internal IntPtr hbitmap = IntPtr.Zero;
            internal IntPtr hpal = IntPtr.Zero;
            internal int unused;

            internal Bitmap(System.Drawing.Bitmap bitmap)
            {
              this.hbitmap = bitmap.GetHbitmap();
            }
          }
        }

        public static stdole.IPictureDisp ToIPictureDisp(System.Drawing.Icon icon)
        {
          PICTDESC.Icon pictIcon = new PICTDESC.Icon(icon);

          return OleCreatePictureIndirect(pictIcon, ref iPictureDispGuid, true);
        }
    }
}
