using System;

namespace PersonRepository.CSV.Tests
{
    public static class TestData
    {
        public static string WithGoodRecords =
            "1,John,Koenig,1975/10/17,6," + Environment.NewLine +
            "3,Leela,Turanga,1999/3/28,8,{1} {0}" + Environment.NewLine;

        public static string WithGoodAndBadRecords =
            "1,John,Koenig,1975/10/17,6," + Environment.NewLine +
            "INVALID DATA" + Environment.NewLine +
            "3,Leela,Turanga,1999/3/28,8,{1} {0}" + Environment.NewLine +
            "MORE INVALID DATA" + Environment.NewLine;

        public static string WithOnlyBadRecords =
            "INVALID DATA" + Environment.NewLine +
            "MORE INVALID DATA" + Environment.NewLine;

    }
}
