using Collections;

Console.WriteLine("==========================================================================");
Console.WriteLine("     Task 2.3 — Extension Methods With Regular Expressions Test Table    ");
Console.WriteLine("==========================================================================\n");

Console.WriteLine("--- Testing IsValidEgyptianPhone() ---");
var phoneTestCases = new (string? Input, bool Expected, string Note)[]
{
    ("01012345678", true, "Standard valid Egyptian mobile number (010)"),
    ("+201512345678", true, "Valid Egyptian mobile number with +20 prefix (+2015)"),
    ("01312345678", false, "013 is not a valid prefix"),
    ("0101234567", false, "only 10 digits"),
    ("0101234567a", false, "contains a letter"),
    (null, false, "null string returns false"),
    ("", false, "empty string returns false"),
    ("   ", false, "spaces return false")
};

foreach (var test in phoneTestCases)
{
    string inputDisplay = test.Input == null ? "null" : $"\"{test.Input}\"";
    bool actual = test.Input.IsValidEgyptianPhone();
    bool passed = actual == test.Expected;
    string mark = passed ? "[PASS]" : "[FAIL]";

    Console.WriteLine($"{mark} Input: {inputDisplay,-18} | Method: IsValidEgyptianPhone | Expected: {test.Expected,-5} | Actual: {actual,-5} | Note: {test.Note}");
}

Console.WriteLine("\n--- Testing IsValidEgyptianNationalId() ---");
var nationalIdTestCases = new (string? Input, bool Expected, string Note)[]
{
    ("29901011234567", true, "Valid 14 digits starting with 2"),
    ("19901011234567", false, "must start with 2 or 3"),
    ("2990101123456", false, "only 13 digits"),
    ("30101011234567", true, "Valid 14 digits starting with 3 (century 2000+)"),
    ("2990101123456a", false, "contains non-digit character"),
    (null, false, "null string returns false"),
    ("", false, "empty string returns false"),
    ("   ", false, "spaces return false")
};

foreach (var test in nationalIdTestCases)
{
    string inputDisplay = test.Input == null ? "null" : $"\"{test.Input}\"";
    bool actual = test.Input.IsValidEgyptianNationalId();
    bool passed = actual == test.Expected;
    string mark = passed ? "[PASS]" : "[FAIL]";

    Console.WriteLine($"{mark} Input: {inputDisplay,-18} | Method: IsValidEgyptianNationalId | Expected: {test.Expected,-5} | Actual: {actual,-5} | Note: {test.Note}");
}

Console.WriteLine("\nAll tests completed successfully!");
