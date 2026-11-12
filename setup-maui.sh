#!/usr/bin/env bash
# Génère les dossiers "Platforms" de P8Maui à partir du modèle officiel .NET MAUI.
# À lancer UNE SEULE FOIS, depuis ce dossier.
set -euo pipefail
root="$(cd "$(dirname "$0")" && pwd)"
tmp="$root/_maui_template"

dotnet workload install maui
dotnet new maui -n P8Maui -o "$tmp/P8Maui"

cp -R "$tmp/P8Maui/Platforms" "$root/P8Maui/Platforms"
rm -rf "$tmp"
echo "OK : P8Maui/Platforms créé. Vous pouvez ouvrir POOAspEntity.slnx."
