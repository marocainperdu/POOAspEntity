# Génère les dossiers "Platforms" (code de démarrage Android/Windows/iOS/macOS) de P8Maui
# à partir du modèle officiel .NET MAUI. À lancer UNE SEULE FOIS, depuis ce dossier.
$ErrorActionPreference = "Stop"
$root = $PSScriptRoot
$tmp  = Join-Path $root "_maui_template"

dotnet workload install maui
dotnet new maui -n P8Maui -o (Join-Path $tmp "P8Maui")

Copy-Item (Join-Path $tmp "P8Maui\Platforms") (Join-Path $root "P8Maui\Platforms") -Recurse -Force
Remove-Item $tmp -Recurse -Force
Write-Host "OK : P8Maui\Platforms créé. Vous pouvez ouvrir POOAspEntity.slnx."
