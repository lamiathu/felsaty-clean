using System;

namespace Sarfati.Core.Exception_handler;

public class BusinessException : Exception
{
    public string ArabicMessage { get; }

    public BusinessException(string englishMessage, string arabicMessage) : base(englishMessage)
    {
        ArabicMessage = arabicMessage;
    }
}