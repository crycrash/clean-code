namespace Markdown;

public class Md
{
    public string Render(string markdownString){
        var tokens = ParseToTokens(markdownString);
        var result = ProcessingTokens(tokens);
        return result;
    }
    
    private List<Token> ParseToTokens(string markdownString){
        var tokenizer = new Tokenizer().Tokenize(markdownString);
        return tokenizer;
    }

    private string ProcessingTokens(List<Token> tokens){
        var processingString = new ConverterHtml().ConvertTokens(tokens);
        return processingString;
    }
}