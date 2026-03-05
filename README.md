Der er 4 projekter:

Et Shared: Bruges til DTOer  

Et BlazorWebAssembly project : her er blazor koden inklusiv services.  

Et Persistance project : Indeholder repositories som APIen bruger  

Et ShopAPI project : Indeholder REST Shopping APIen (er et ASP.NET Core WebApi Project).  


Bemærk at man skal køre BÅDE ShopAPI projektet og BlazorWebassembly projektet på samme tid (ellers kan webappen ikke bruge apien jo).
Der ligger en run configuration som hedder "Api and client" som man kan vælge oppe i menuen ved siden af run knappen ("start up project). 
I modsætning til Blazor server kommer de to projekter til at køre på hver sin port - dvs. helt seperat.

Hvis man skal have det til at køre på sin egen computer skal man lige ind og tilrette port numre i forhold til localhost.
Så man kan gøre projekterne og så få de port numre som APIen og Webassembly kører på.
Derefter skal man rette 2 steder og så køre det igen : 

1. I BlazorWebassembly i ShoppingService.cs skal denne linje rettes til jeres url til APIen (det er samme url man ville bruge i POSTMan til at teste apien) :
     private string baseAPIURL = "https://localhost:7021/";
   
   (man kan finde denne url i terminal vinduet som starter når API projektet køres)

3. I API projektet i Program.cs :
   Der står  policy.WithOrigins("https://localhost:7216").
   
   Denne url skal være url til jeres blazor projekt - I kan få denne URL fra browseren hvor jeres blazor projektet køres.
   Hvis man ikke gør dette, så vil det stadig virke i PostMan at få adgang til jeres API, men BlazorWebassembly fra browseren KAN IKKKE
   på grund af sikkerhed få adgang til jeres API (Dette er noget som hedder CORS policy, som browseren bruger, men som Postman ikke bruger som default).


   Information om login systemet.

   Der er lavet et login system ved brug af JWT.
   I API projektet, så kan opsætning ses i program.cs, samt API endpoints i LoginController.cs

   På client siden i BlazorWebAssembly projectet, så kan opsætningen ses i program.cs :

   
     builder.Services.AddScoped<ILoginService, LoginService>();

     builder.Services.AddScoped<CustomAuthStateProvider>();
     builder.Services.AddScoped<AuthenticationStateProvider>(provider => provider.GetRequiredService<CustomAuthStateProvider>());


     builder.Services.AddBlazoredSessionStorage();

     //de to politikker nedenunder bruges med AuthStateProvideren.
    builder.Services.AddAuthorizationCore(options =>
     {
         options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
         options.AddPolicy("User", policy => policy.RequireRole("Admin").RequireRole("User"));
     
     });

     Der bliver brugt en nugetpakke (https://github.com/mmsoftpl/Blazor.Storage) til at gemme JWT i sessionstorage.

     Der er også lavet en CustomAuthStateProvider - se filen under Models i client projectet og se hvordan den bruges i på f.eks.
     Login.razor siden. Et eksempel på dette i Login.razor siden er f.eks. her:

      await sessionStorage.SetItemAsync("jwtToken", loginResponse.JWTToken);
      AuthStateProvider.update();

      Efter at have fået JWT token fra API efter login succes så gemmes det token og AuthStateProvider kaldes.

      Strengt taget behøver man ikke en AuthStateProvider, men hvis man implmentere en sådan en, som jeg har gjort her, så giver
      det nogle cool muligheder i Blazor (det følgende kræver lidt setup (man kan kopiere fra App.Razor) - her vist på profile.razor siden:

      <AuthorizeView Roles="Admin">
    <Authorized>
        I am authorized as admin
    </Authorized>
    <NotAuthorized>
        <p>You are not authorized as admin.</p>
    </NotAuthorized>
    </AuthorizeView>

     Vi kan nu bruge <AuthorizeView> til at indikere at noget content på en side kun skal være tilgængelig hvis man er logget ind som f.eks. admin eller andet.
     Man behøver ikke yderligere check her, da AuthStateProvider bliver kaldt automatisk af Blazor for at tjekke hvilken rolle man har!!
     Det er jo ret nice. 






