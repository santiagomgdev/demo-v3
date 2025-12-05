# Propuesta

- Ahora q
- Revisar como aplicar el estandar de formato de respuesta para request / response
- Los enums tambien deben ir en base de datos como tabalas?
- Endpoints restantes del crud

1. Snake_case JSON (fixing PascalCase → snake_case)

  In .NET Core 9, you need to configure the JSON serializer to use snake_case. Add this to your Program.cs:

● Update(src/Application/Program.cs)
  ⎿  Updated src/Application/Program.cs with 5 additions
       11    builder.Services.AddEndpointsApiExplorer();
       12    builder.Services.AddSwaggerGen();
       13
       14 +  builder.Services.ConfigureHttpJsonOptions(options =>
       15 +  {
       16 +      options.SerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.SnakeCaseLower;
       17 +  });
       18 +  
       19    builder.Services.AddInfrastructure(builder.Configuration);
       20
       21    // builder.Services.AddSingleton<EstadoRepository>();

● Done! Now your JSON properties will automatically be serialized/deserialized in snake_case format.

2. Enumerations in the database

  Short answer: It depends on your use case, but generally NO, you don't need to create a table for enumerations.

  Here are your options:

- Store as integer/string (Most common): Just store the enum value directly in your entity table. EF Core handles this automatically. This is simpler and faster.
- Create a lookup table (Use when):
  - You need to add descriptions/metadata to enum values
  - Enum values might change frequently
  - You need referential integrity constraints
  - Non-technical users need to manage the values

  For most scenarios with domain enums (like status, type, category), storing the value directly is cleaner. If you want, I can show you how to configure either approach in your project - just let me know if
  you have a specific enum you're working with!
