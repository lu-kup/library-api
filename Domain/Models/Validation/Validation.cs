using System.ComponentModel.DataAnnotations;
using System;
using System.Text.RegularExpressions;

namespace Domain.Models.Validation;

public static class BookValidation
{
    private const string MatchPatternISBN = @"^(?=(?:\D*\d){10}(?:(?:\D*\d){3})?$)[\d-]+$";

    private static readonly Regex _regexISBN = new(MatchPatternISBN, RegexOptions.Compiled);

    public static void ValidateISBN(string isbn)
    {
        if (!_regexISBN.IsMatch(isbn))
        {
            throw new ValidationException();
        }
    }

    public static void ValidatePublicationYear(int publicationYear)
    {
        if (publicationYear > DateTime.UtcNow.Year)
        {
            throw new ValidationException();  
        }
    }

    public static void ValidateIsNullOrEmpty(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ValidationException();
        }
    }
}