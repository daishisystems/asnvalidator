## ASN file validation tool
### Usage
```csharp
var passesValidation = AsnValidator.Validate("xmlSchema.xsd", "xmlFile.xml", out var validationExceptionMessage);

if (!passesValidation) {
  Console.Writeline("Validation failed");
  Console.Writeline(validationExceptionMessage);
} else
{
  Console.Writeline("XML file is valid");
}
```
