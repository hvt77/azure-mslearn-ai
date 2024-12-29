using System.Text;

using Microsoft.CognitiveServices.Speech;

using Microsoft.CognitiveServices.Speech.Audio;

string azureKey = "";
string azureLocation = "westeurope";
string textFile = "Shakespeare.txt";
string ssmlFile = "Shakespeare.xml";
string waveFile = "Shakespeare.wav";
string waveFilessml = "Shakespeare.ssml.wav";

try
{
    FileInfo fileInfo = new FileInfo(textFile);
    if (fileInfo.Exists)
    {
        string textContent = File.ReadAllText(fileInfo.FullName);
        var speechConfig = SpeechConfig.FromSubscription(azureKey, azureLocation);
        using var speechSynthesizer = new SpeechSynthesizer(speechConfig, null);
        var speechResult = await speechSynthesizer.SpeakTextAsync(textContent);
        using var audioDataStream = AudioDataStream.FromResult(speechResult);
        await audioDataStream.SaveToWaveFileAsync(waveFile);       
    }
    FileInfo ssmlfileInfo = new FileInfo(ssmlFile);
    if (ssmlfileInfo.Exists)
    {
        string ssmlContent = File.ReadAllText(ssmlfileInfo.FullName);
        var speechConfig = SpeechConfig.FromSubscription(azureKey, azureLocation);
        using var speechSynthesizer = new SpeechSynthesizer(speechConfig, null);
        var speechResult = await speechSynthesizer.SpeakSsmlAsync(ssmlContent);
        using var audioDataStream = AudioDataStream.FromResult(speechResult);
        await audioDataStream.SaveToWaveFileAsync(waveFilessml);       
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);

}