namespace Hid.Net.Windows
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RangeStruct
    {
        byte  UsageMin;
        byte  UsageMax;
        ushort StringMin;
        ushort StringMax;
        ushort DesignatorMin;
        ushort DesignatorMax;
        ushort DataIndexMin;
        ushort DataIndexMax;
        
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct NotRangeStruct
    {
        byte  Usage;
        byte  Reserved1;
        ushort StringIndex;
        ushort Reserved2;
        ushort DesignatorIndex;
        ushort Reserved3;
        ushort DataIndex;
        ushort Reserved4;
    }

    [StructLayout(LayoutKind.Explicit)]
    unsafe public struct HIDButtonCaps
    {
        [FieldOffset(0)]byte  UsagePage;
        [FieldOffset(1)]byte  ReportID;
        [FieldOffset(2)]byte  IsAlias; 
        [FieldOffset(3)]ushort BitField;
        [FieldOffset(5)]ushort LinkCollection;
        [FieldOffset(7)]byte  LinkUsage;
        [FieldOffset(8)]byte LinkUsagePage;
        [FieldOffset(9)]byte IsRange;
        [FieldOffset(10)]byte IsStringRange;
        [FieldOffset(11)]byte IsDesignatorRange;
        [FieldOffset(12)]byte IsAbsolute;
        [FieldOffset(13)]ushort  ReportCount;
        [FieldOffset(15)]ushort  Reserved2;
        [FieldOffset(17)]fixed ulong Reserved[9]; // 4 bytes *9 = 36 bytes
        // union
        [FieldOffset(53)] private RangeStruct Range;
        [FieldOffset(53)] private RangeStruct NotRange;
    }
}