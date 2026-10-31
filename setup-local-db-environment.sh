#!/usr/bin/env bash

set -e

PROJECT_PATH="./AutoCore"
DB_NAME="autocore"

PASSWORD=$(openssl rand -base64 12 | tr -d '/+=')

echo "Setting up a local database environment..."

CONNECTION_STRING="Host=127.0.0.1;Port=5432;Database=$DB_NAME;Username=postgres;Password=$PASSWORD;"

echo "-> Applying User Secrets in the project..."
dotnet user-secrets --project "$PROJECT_PATH" init > /dev/null 
dotnet user-secrets --project "$PROJECT_PATH" set "ConnectionStrings:DefaultConnection" > /dev/null "$CONNECTION_STRING"

echo "-> Generating .env file..."
cat << EOF > .env
DB_NAME=$DB_NAME
DB_PASSWORD=$PASSWORD
EOF

echo "Local database environment configured successfully."