namespace PersonRepository.CSV.Tests
{
    public class FakeFileLoader : ICSVFileLoader
    {
        private string dataType;

        public FakeFileLoader(string dataType)
        {
            this.dataType = dataType;
        }

        public string LoadFile()
        {
            switch (dataType)
            {
                case "Good": return TestData.WithGoodRecords;
                case "Mixed": return TestData.WithGoodAndBadRecords;
                case "Bad": return TestData.WithOnlyBadRecords;
                case "Empty": return string.Empty;
                default: return TestData.WithGoodRecords;
            }
        }
    }
}
