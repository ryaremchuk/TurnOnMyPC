using System.Diagnostics;

namespace TurnOnMyPC.Logic
{
    public class MacAddressRetriever
    {
        public string GetMacAddress(string ipAddress)
        {
            var macAddress = string.Empty;

            var processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = "nbtstat";
            processStartInfo.RedirectStandardInput = false;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.Arguments = "-a " + ipAddress;
            processStartInfo.UseShellExecute = false;
            var process = Process.Start(processStartInfo);

            var macCalculated = false;

            while (!macCalculated)
            {
                macAddress = process.StandardOutput.ReadLine();
                macCalculated = macAddress.Trim().IndexOf("mac address", 0, System.StringComparison.OrdinalIgnoreCase) > -1;
            }
            process.WaitForExit();


            macAddress = macAddress
                .ToUpper()
                .Replace("mac address = ".ToUpper(), string.Empty)
                .Replace("-", string.Empty)
                .Replace(":", string.Empty)
                .Trim();

            return macAddress;
        }
    }
}