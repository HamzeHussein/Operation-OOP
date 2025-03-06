# Individuell Inlämningsuppgift – OOP, Arv/Komposition & Enklare Algoritmer

**Översikt:**  
Du får ett färdigt API-projekt som grund, där tre endpoints finns klara för hantering av bonsaiträd. Din uppgift är att skapa ett klassbibliotek och integrera detta med API:t genom att:

1. **Utöka logiken** (flera klasser, använd arv eller komposition från den existerande Bonsai-klassen eller skapa helt egna klasser och interface(exempelvis `IEntity`).  
2. **Implementera enkel algoritmisk funktion** (sök, sortering, filtrering eller enklare beräkning).  
3. **Lägga till nya endpoints** i API:t som använder din logik.  

Uppgiften är tänkt att visa din förmåga inom:  
- **Algoritmiskt tankesätt och logiska tillvägagångssätt vid utformande av algoritmer** och hur du strukturerar logik.  
- **Analys och strukturering av applikationer**.  
- **Objektorienterad programmeringsteknik och begrepp** (arv, komposition, inkapsling, etc.).  

För att vara exakt så är detta kursmålen:
- 1, Begrepp inom objektorienterad programmering
- 2, Algoritmiskt tankesätt och logiska tillvägagångssätt vid utformande av algoritmer
- 4, Analysering och strukturering av applikationer
- 5, Strukturerad och objektorienterad programmeringsteknik vid

## Steg-för-steg-instruktioner

1. **Hämta det befintliga API-projektet**  
   - Starta med den kod du fått, testa att dina tre Bonsai-endpoints fungerar:
     - GET /api/bonsai - Hämtar alla bonsaiträd
     - GET /api/bonsai/{id} - Hämtar ett specifikt bonsaiträd
     - POST /api/bonsai - Skapar ett nytt bonsaiträd
   - Bekanta dig med hur projektet är uppdelat (Program.cs, Bonsai.cs, endpoints, etc.).

2. **Skapa/utöka klassbiblioteket**  
   - Utgå från den existerande Bonsai-klassen i `OperationOOP.Core/Models/Bonsai.cs`.
   - Lägg till minst tre nya klasser i klassbiblioteket som kompletterar Bonsai-hanteringen (eller skapa en helt ny idé).
   - Använd **arv** eller **komposition** från Bonsai-klassen eller skapa en abstrakt klass (t.ex. `Plant`) och ett gemensamt Interface(exempelvis `IEntity`).  
   - I klasserna ska du:  
     - Använda **inkapsling** (public/private/protected).  
     - Fundera på **designprinciper** (t.ex. “Single 
     Responsibility”, “Komposition över arv när det passar” 
     etc.).  

3. **Implementera en eller flera metoder** med enklare algoritmik  
   - Exempel:  
     - Filtrera en lista på produkter för att hitta de med lågt lager.  
     - Sök bland djur på zoo efter namn eller art.  
     - Beräkna en totalsumma eller sortera objekt efter någonting (pris, antal, namn).  
   - Metoden ska sedan anropas från API:t.  

4. **Lägg till endpoints i API**  
   - Se till att ha minst 2–3 nya endpoints, t.ex.:  
     - GET för att lista eller filtrera objekt.  
     - POST för att skapa ett nytt objekt i din in-memory-samling.  
   - Endpoint-koden ska anropa klassbibliotekets logik.  
   - Använd gärna **Dependency Injection** om du vill (ej krav, men bra övning).  

5. **Testa och demonstrera**  
   - Du behöver inte skriva enhetstester om det inte efterfrågas, men testa att dina endpoints fungerar – till exempel i en webbläsare, Postman, eller via inbyggda Swagger-sidor.  
   - Säkerställ att dina algoritmiska metoder faktiskt fungerar (t.ex. att du får rätt filtrering eller sortering).  

## Exempel på idéer

1. **Recept-hantering**
   - Klasser: Recipe (bas), Ingredient, CookingStep
   - Algoritmer: 
     - Filtrera recept baserat på tillagningstid eller svårighetsgrad
     - Sök recept som innehåller specifika ingredienser
     - Beräkna portioner och skala om ingrediensmängder
   - Möjliga endpoints: GET /recipes, GET /recipes/search, POST /recipes

2. **Träningspass-system**
   - Klasser: Workout (bas), CardioWorkout, StrengthWorkout, Exercise
   - Algoritmer:
     - Beräkna total träningstid och kaloriförbränning
     - Filtrera övningar efter muskelgrupp
     - Sortera pass efter intensitetsnivå
   - Möjliga endpoints: GET /workouts, GET /workouts/muscle-group/{group}, POST /workouts

3. **Spelkaraktärs-hantering**
   - Klasser: Character (bas), Warrior, Mage, Equipment, Skill
   - Algoritmer:
     - Beräkna total skada eller försvar
     - Filtrera karaktärer efter klass eller level
     - Sortera utrustning efter värde eller sällsynthet
   - Möjliga endpoints: GET /characters, GET /characters/class/{class}, POST /characters

4. **Växt-hantering**
   - Klasser: Plant (bas), IndoorPlant, OutdoorPlant, WateringSchedule
   - Algoritmer:
     - Beräkna nästa vattningsdatum
     - Filtrera växter efter skötselsvårighet
     - Sortera efter hälsostatus eller vattenbehov
   - Möjliga endpoints: GET /plants, GET /plants/care-level/{level}, POST /plants

5. **Film-bibliotek**
   - Klasser: Movie (bas), Review, Director, Genre
   - Algoritmer:
     - Beräkna genomsnittsbetyg
     - Filtrera filmer efter genre eller årtal
     - Sortera efter betyg eller utgivningsdatum
   - Möjliga endpoints: GET /movies, GET /movies/genre/{genre}, POST /movies

Varje exempel ger möjlighet att demonstrera:
- Arv och/eller komposition
- Inkapsling av data
- Algoritmisk behandling av data (sökning, filtrering, sortering)
- REST API-design
- Dependency Injection (valfritt)

## Redovisning

1. **Kod**  
   - Lämna in din lösning (länk till GitHub-repo).  
   - Kommentera gärna koden kortfattat för att visa ditt tänkande.  

2. **Kort videogenomgång** (valfritt format)  
   - Förklara hur du löst uppgiften, i en 5–10 minuters video där du delar skärmen och diskuterar koden.  
   - Beskriv vilka klasser du skapade, om du använde arv/komposition & varför du valde detta.  
   - Visa hur din algoritm fungerar (ex. "Så här filtreras produkterna").  
   - Resonera kring eventuella designprinciper du använt (t.ex. "komposition över arv").  

## Tips för högre nivå (VG-kriterier)
Enligt kursmålen så ska du:
- Självständigt analysera och kombinera olika begrepp inom objektorienterad programmering
- Se samband och värdera alternativa lösningar vid val av programmeringsteknik
- Självständigt ta fram och utvärdera information i förkodade lösningar i ramverk ochklassbibliotek


- **Självständigt analysera och kombinera OOP-begrepp**  
  - Diskutera t.ex. polymorfism, arv, interface, abstrakta klasser, etc.  
- **Värdera alternativ**  
  - Varför valde du just arv i stället för komposition (eller tvärtom)?  
  - Vilka andra designmönster eller principer skulle kunna vara relevanta?  
- **Förkodade lösningar i ramverk/klassbibliotek**  
  - Utvärdera hur .NET (t.ex. Minimal API, DI, Collections, LINQ) hjälper din lösning.  
  - Hur hade du kunnat använda designmönster som Repository eller Strategy? (inte nödvändigt)  

## Hjälp för dig som vill göra mer

- **Utöka ditt klassbibliotek** med fler klasser eller extra funktioner (t.ex. hantering av kategorier, relaterade objekt, etc.).  
- **Implementera designpriciper** tydligare (SOLID, DIP/IoC, etc.).  
- **Ökad algoritmisk komplexitet** (mer avancerad beräkning/validering).  
- **Fler endpoints** eller integration med en extern fil/databas (om tid och kunskap finns).  

---

**Lycka till!**  
Den här uppgiften är perfekt för att träna på hur man använder objektorienterad design i praktiken, hur man skiljer på klassbibliotek och API, och hur man skapar enkla algoritmer för filtrering/sök/beräkning. Var inte rädd att fråga om du kör fast eller vill bolla designfrågor!