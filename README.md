# Réservation de salles

Application .NET MAUI de réservation de salles.
Projet – Phase 1 du cours **Développement d'application de bureau (IFM30739)** – Automne 2026.

## Équipe
- John
- Hamza

## Description
L'application permet à un utilisateur de consulter les salles disponibles et de
réserver une salle pour une date et une plage horaire données.
Cette première phase est centrée sur l'ergonomie, l'interface, les contrôles MAUI,
le XAML et la navigation. Aucune base de données n'est utilisée : les données sont
simulées directement dans le code (`Salle.cs`).

## Écrans
| # | Écran | Contenu | Contrôles principaux |
|---|-------|---------|----------------------|
| 1 | Tableau de bord | Nom de l'application, nombre de salles disponibles, nombre de réservations simulées, menu de navigation | Label, Button, Grid |
| 2 | Liste des salles | Nom, capacité, localisation, disponibilité | CollectionView, Label, Image, Button |
| 3 | Détail d'une salle | Informations détaillées, capacité, équipements, retour à la liste | Label, Image, Button |
| 4 | Réservation | Nom, date, plage horaire, salle, validation simple | Entry, DatePicker, Picker, Button |


## Fonctionnalités
- **Navigation** : menu hamburger (Shell) et boutons entre les écrans.
- **Passage de paramètres** : l'identifiant de la salle passe de la liste vers le détail,
  puis du détail vers le formulaire de réservation (`QueryProperty`).
- **Validation** : le nom, la salle et la plage horaire sont obligatoires.
- **Règles simples** : une salle occupée ne peut pas être réservée ; la date ne peut pas
  être dans le passé.
- **Ergonomie** : styles et couleurs partagés, textes lisibles, boutons cohérents.