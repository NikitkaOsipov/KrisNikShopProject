# OsipogShopProject
## Kā palaist OsipogShop programmu

Rekomendējam izmantot Visual studio code un Visual studio 2022

Lietojot Visual Studio 2022:
1. noteikti instalējiet jaunāko Visual Studio versiju ar "ASP.NET and web development" workload (izmantojot Visual Studio Installer)
2. noklikšķiniet uz atvērt "project/solution" un atveriet KrisNikShopProject.sln
3. lai palaistu projektu, augšējā panelī jānoklikšķina uz zaļās trīsstūra pogas vai "Debug/Start Debugging".

Lietojot Visual Studio Code:
1. lai palaistu programmu, jāinstalē papildinājums. Jums jānoklikšķina uz pogas ar četriem kvadrātiem ar nosaukumu “Еxtensions”, meklēšanas joslā ievadiet "C# Dev Kit" un noklikšķiniet uz “Install”
2. noklikšķiniet uz "Open folder" un atveriet projekta mapi
3. lai palaistu projektu, augšējā panelī jānoklikšķina uz pogas "Run/Start Debugging". Vai ir jāatver jebkurš fails ar paplašinājumu ".cs" (Piemēram "KrisNikShopProject\Program.cs") un augšējā labajā stūrī jānoklikšķina uz pogas "run project associated with this file" (trijstūris ar vaboli)

Projekta struktūra:
-Darbs notika tikai mapē "KrisNikShopProject\Components" un ar failu "KrisNikShopProject\Program.cs"
-Failā "KrisNikShopProject\Program.cs" tiek pievienoti servisa singletoni (Piemēram "UserRegistrationService") lai būtu vieglāk strādāt ar tiem un izmantot vienu pašreizējā lietotāja mainīgo (CurrentUser) visam projektam, pakalpojumā "UserRegistrationService"
-Mapē "KrisNikShopProject\Components\Collections" CSV un JSON faili tiek glabāti, lai saglabātu datus par lietotājiem un produktiem
-Mapē "KrisNikShopProject\Components\Data" ir visi C# faili, modeļi un pakalpojumi
-Mapē "KrisNikShopProject\Components\Layout" ir visi komponenti, kas saistīti ar vietnes augšējo un kreiso paneli
-Mapē "KrisNikShopProject\Components\Pages" ir Razor faili, kas saistīti tieši ar vietnes lapām
