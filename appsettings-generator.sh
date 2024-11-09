#!/bin/bash

echo "{
  \"Logging\": {
    \"LogLevel\": {
      \"Default\": \"Information\",
      \"Microsoft.AspNetCore\": \"Warning\"
    }
  },
  \"ConnectionStrings\": {
    \"RecipesContext\": \"Host=db;Port=5432;Database=postgres;Username=${POSTGRES_USER};Password=${POSTGRES_PASSWORD};Trust Server Certificate=true;\"
  },
  \"AllowedHosts\": \"*\"
}" > ./FinalProject/appsettings.json

cd ./FinalProject

# Ask the user if they want to run the database update
read -p "Run 'dotnet ef database update'? [y/N]: " user_input

# If the user types 'y' or 'Y', proceed with the update
if [[ "$user_input" =~ ^[Yy]$ ]]; then
    echo "Running database update..."
    dotnet ef database update --connection "Host=db;Port=5432;Database=postgres;Username=${POSTGRES_USER};Password=${POSTGRES_PASSWORD};Trust Server Certificate=true;"
else
    echo "Database update skipped."
fi