using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;

namespace Weekly_Budget
{
    class Program
    {
        private static readonly string[] Scopes =
        {
            SheetsService.Scope.Spreadsheets
        };
        private const string SpreadsheetId = "1EwagxQMH91RU4lnrgaSH8Hzyd95uocv56dK1oJX6i6I";
        private const string GoogleCredentialsFileName = "google-credentials.json";
        private const string ReadRange = "Sheet1!A:C";

        async static Task Main(string[] args)
        {
            var serviceValues = GetSheetsService().Spreadsheets.Values;
            await ReadAsync(serviceValues);
        }

        private static SheetsService GetSheetsService()
        {
            using (var stream = new FileStream(GoogleCredentialsFileName, FileMode.Open))
            // using (var stream = new FileStream(File.OpenRead(GoogleCredentialsFileName)))
            {
                var serviceInitializer = new BaseClientService.Initializer
                {
                    HttpClientInitializer = GoogleCredential.FromStream(stream).CreateScoped(Scopes)
                };
                return new SheetsService(serviceInitializer);
            }
        }

        private static async Task ReadAsync(SpreadsheetsResource.ValuesResource valuesResource)
        {
            var response = await valuesResource.Get(SpreadsheetId, ReadRange).ExecuteAsync();
            var values = response.Values;

            if (values == null || !values.Any())
            {
                Console.WriteLine("No Data Found!");
                return;
            }

            var header = string.Join(" ", values.First().Select(r => r.ToString()));
            Console.WriteLine($"Header: {header}");

            foreach (var row in values.Skip(1))
            {
                var res = string.Join(" ", row.Select(r => r.ToString()));
                Console.WriteLine(res);
            }
        }
    }
}
