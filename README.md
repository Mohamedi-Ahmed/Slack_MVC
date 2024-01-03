# Mon Projet Angular et ASP.NET Core

Ce projet est une application web composée d'un frontend développé avec Angular et d'un backend utilisant ASP.NET Core. Le frontend Angular est une application web interactive tandis que le backend ASP.NET Core sert d'API pour le traitement des données.

## Prérequis

Pour exécuter l'application, vous devez avoir les outils suivants installés :
- **.NET Core SDK** : Nécessaire pour exécuter le backend ASP.NET Core. Disponible à [cette adresse](https://dotnet.microsoft.com/download).
- **Node.js et npm** : Requis pour exécuter l'application Angular. Node.js est accompagné de npm (Node Package Manager) et peut être téléchargé à partir de [nodejs.org](https://nodejs.org/).

## Installation et Configuration

### Backend ASP.NET Core

1. **Ouverture du projet** :
   - Ouvrez un terminal.
   - Naviguez vers le dossier contenant le projet backend (le dossier où se trouve le fichier `.csproj`).

2. **Restauration des dépendances** :
   - Exécutez `dotnet restore` pour restaurer les dépendances nécessaires au projet.

3. **Lancement du serveur backend** :
   - Exécutez `dotnet run` pour démarrer le serveur ASP.NET Core.
   - Le serveur devrait démarrer et écouter sur un port spécifié (habituellement `http://localhost:5048`).

### Frontend Angular

1. **Préparation du frontend** :
   - Ouvrez un nouveau terminal.
   - Naviguez vers le dossier du frontend (où se trouve le fichier `package.json`).

2. **Installation des packages npm** :
   - Exécutez `npm install` pour installer les dépendances définies dans `package.json`.

3. **Démarrage du serveur de développement Angular** :
   - Lancez le serveur en exécutant `ng serve`.
   - Une fois le serveur démarré, ouvrez votre navigateur à `http://localhost:4200`.

## Utilisation de l'Application

Après avoir lancé les serveurs backend et frontend, vous pouvez interagir avec votre application Angular via le navigateur à l'adresse `http://localhost:4200`. L'application communiquera avec le backend ASP.NET Core pour les opérations de données.

## Configuration Supplémentaire

- Assurez-vous que toutes les configurations spécifiques (telles que les variables d'environnement ou les chaînes de connexion de base de données) sont correctement définies dans les fichiers de configuration de votre projet.
- Si votre application nécessite des étapes de configuration supplémentaires, détaillez-les ici.

## Contributions

Si vous souhaitez contribuer à ce projet, veuillez suivre les conventions de code standard et soumettre vos Pull Requests pour révision.
