## ASN file validation tool
### Usage
```csharp
var passesValidation = AsnValidator.Validate("xmlSchema.xsd", "xmlFile.xml", out var validationExceptionMessage);

if (!passesValidation) {
  Console.WriteLine("Validation failed");
  Console.WriteLine(validationExceptionMessage);
} else
{
  Console.WriteLine("XML file is valid");
}
```
