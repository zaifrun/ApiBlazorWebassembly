Der er 4 projekter:

Et Shared: Bruges til DTOer
Et BlazorWebAssembly project : her er blazor koden inklusiv services.
Et Persistance project : Indeholder repositories som APIen bruger
Et ShopAPI project : Indeholder REST Shopping APIen (er et ASP.NET Core WebApi Project).

Bemærk at man skal køre BÅDE ShopAPI projektet og BlazorWebassembly projektet på samme tid (ellers kan webappen ikke bruge apien jo).
Der ligger en run configuration som hedder "Api and client" som man kan vælge oppe i menuen ved siden af run knappen ("start up project). 

Hvis man skal have det til at køre på sin egen computer skal man lige ind og tilrette port numre i forhold til localhost.
Så man kan gøre projekterne og så få de port numre som APIen og Webassembly kører på.
Derefter skal man rette 2 steder og så køre det igen : 

1. I BlazorWebassembly i ShoppingService.cs skal denne linje rettes til jeres url til APIen (det er samme url man ville bruge i POSTMan til at teste apien) :
     private string baseAPIURL = "https://localhost:7021/";
   (man kan finde denne url i terminal vinduet som starter når API projektet køres)

2. I API projektet i Program.cs :
   Der står  policy.WithOrigins("https://localhost:7216").
   Denne url skal være url til jeres blazor projekt - I kan få denne URL fra browseren hvor jeres blazor projektet køres.
   Hvis man ikke gør dette, så vil det stadig virke i PostMan at få adgang til jeres API, men BlazorWebassembly fra browseren KAN IKKKE
   på grund af sikkerhed få adgang til jeres API (Dette er noget som hedder CORS policy, som browseren bruger, men som Postman ikke bruger som default).







