---
schema_version: 2
type: library
file_count: 245
delete_recommendation_percent: 5
generated_date: 2026-09-30
generated_time: 15:10:38
---

## Description

Jádrové utility vyčleněné z monolitu `SunamoDevCode`: práce s csproj soubory v solution (filtrování, konstanty), parsování výstupu `dotnet build`, kódování zpětných lomítek a generování boilerplate kódu.
Balíček je self-contained: kód dříve referencovaných balíčků (DevCodeBase, CSharp, SolutionsIndexer) je zkopírován do `Internal\` jako internal a jiné Sunamo balíčky nereferencuje.
