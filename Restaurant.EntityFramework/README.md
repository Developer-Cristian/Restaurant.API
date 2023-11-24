# Esecuzione di Entity Framework migration 
- aprire console di gestione pacchetti e spostarsi nella cartella della web api contenente l app settings con la connstring
- lanciare "Add-Migration Initials"


# per gli aggiornamenti
- aprire console di gestione pacchetti e spostarsi nella cartella della web api contenente l app settings con la connstring
- lanciare "Update-Database"

# Utilizzo user secret con EF
La funzione dei user secret è quella di poter accedere a info sensibili solo in ambiente di Development, 
quindi bisogna assicurarsi che la variabile ASPNETCORE_ENVIRONMENT della macchina abbia valore "Development" 
o il comando di update non funzionerà.

# Seed di entità relazionte uno a molti
Si consiglia di creare prima le tabelle con una migrazione e solo successivamente creare una nuova migrazione con il seed dei dati relazionati

# Riferimenti
[Uso di un progetto di migrazione separato](https://learn.microsoft.com/it-it/ef/core/managing-schemas/migrations/projects?tabs=dotnet-core-cli)
[CRUD with a .NET 6 Web API & Entity Framework Core](https://www.youtube.com/watch?v=Fbf_ua2t6v4)