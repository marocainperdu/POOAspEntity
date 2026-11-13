<img width="1920" height="913" alt="image" src="https://github.com/user-attachments/assets/c48bb101-d20d-4842-858e-948c52b57efe" />
<img width="1920" height="913" alt="image" src="https://github.com/user-attachments/assets/5bc99453-4090-4e3e-aace-10b4b1cbf934" />


# POOAspEntity — TD .NET (ESP / UCAD, 2026-2027)

Solution contenant deux projets :

| Projet | Contenu | Module Microsoft Learn |
|---|---|---|
| **P5AspEntity** | API minimale ASP.NET Core + Entity Framework Core + SQLite (CRUD sur des pizzas) | *Utiliser une base de données avec une API minimale, Entity Framework Core et ASP.NET Core* |
| **P8Maui** | Application .NET MAUI de prise de notes (liste, création, modification, suppression, À propos) | *Création d'application mobile .NET MAUI* |

## Prérequis
- SDK **.NET 10** (`dotnet --version`)
- Pour P8Maui : charge de travail MAUI (`dotnet workload install maui`), Android SDK / émulateur ou Windows 10+

## P5AspEntity (API)
```bash
cd P5AspEntity
dotnet run --launch-profile http      # http://localhost:5080
```
La base `Pizzas.db` (SQLite) est créée et alimentée au premier démarrage.

| Méthode | Route | Rôle | Réponses |
|---|---|---|---|
| GET | `/pizzas` | Lister | 200 |
| GET | `/pizzas/{id}` | Lire | 200 / 404 |
| POST | `/pizzas` | Créer | 201 / 400 |
| PUT | `/pizzas/{id}` | Modifier | 204 / 400 / 404 |
| DELETE | `/pizzas/{id}` | Supprimer | 204 / 404 |

- Description OpenAPI : `http://localhost:5080/openapi/v1.json`
- Requêtes prêtes à l'emploi : `P5AspEntity/P5AspEntity.http` (VS / VS Code REST Client / Rider)

### Architecture (modulaire)
```
P5AspEntity/
├─ Program.cs                    composition uniquement
├─ Models/Pizza.cs               entité + validation (DataAnnotations)
├─ Data/PizzaDb.cs               DbContext EF Core
├─ Data/DatabaseInitializer.cs   création + données de départ
├─ Services/IPizzaService.cs     contrat CRUD
├─ Services/PizzaService.cs      implémentation EF Core
├─ Endpoints/PizzaEndpoints.cs   routes (MapGroup)
├─ Filters/ValidationFilter.cs   validation réutilisable (400)
└─ Extensions/                   enregistrement des services / pipeline
```

### Migrations EF Core (optionnel)
Le projet utilise `EnsureCreated`. Pour passer aux migrations :
```bash
dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialCreate
dotnet ef database update
```
puis remplacer `EnsureCreatedAsync()` par `MigrateAsync()` dans `DatabaseInitializer.cs`.

## P8Maui (application mobile)
**Étape unique** : générer les dossiers `Platforms` avec le modèle officiel.
```powershell
./setup-maui.ps1        # Windows
./setup-maui.sh         # macOS / Linux
```
Puis ouvrir `POOAspEntity.slnx` (ou `POOAspEntity.sln`, voir plus bas), choisir **Android Emulator**
ou **Windows Machine** et lancer. En ligne de commande :
```bash
dotnet build P8Maui -f net10.0-android
```

### Architecture (MVVM)
```
P8Maui/
├─ MauiProgram.cs, App, AppShell     démarrage et navigation (onglets Notes / À propos)
├─ Models/Note.cs
├─ Services/                         INoteRepository + FileNoteRepository (fichiers texte),
│                                    INavigationService, IDialogService (+ implémentations Shell)
├─ ViewModels/                       NotesViewModel, NoteViewModel, AboutViewModel
├─ Views/                            NotesPage, NotePage, AboutPage
├─ Navigation/Routes.cs              constantes de routes
├─ Extensions/                       enregistrement des dépendances
└─ Resources/                        icône, splash, styles (thème clair/sombre)
```

## Si votre IDE ne reconnaît pas le format `.slnx`
```bash
dotnet new sln -n POOAspEntity --format sln
dotnet sln POOAspEntity.sln add P5AspEntity/P5AspEntity.csproj P8Maui/P8Maui.csproj
```

## Livrables du TD
1. Terminer les deux modules sur Microsoft Learn avec **votre** compte, puis faire la copie d'écran
   (photo, titre de la formation, points XP) pour chaque module.
2. Publier le code sur GitHub :
```bash
git init && git add . && git commit -m "TD .NET : POOAspEntity (P5AspEntity + P8Maui)"
git branch -M main
git remote add origin https://github.com/<votre-compte>/POOAspEntity.git
git push -u origin main
```
3. Rendre : les copies d'écran + le lien du dépôt.
