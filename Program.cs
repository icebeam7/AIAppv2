using AIApp.Services;

AIService ai = new AIService();
//string prompt = "Tell me a joke";
//string answer = await ai.Ask(prompt);
//Console.WriteLine(answer);

string imagePrompt = "A mammoth enjoying the summer drinking hot tea";
string imageUrl = await ai.GenerateImage(imagePrompt);
Console.WriteLine(imageUrl);

Console.WriteLine(imageUrl);
