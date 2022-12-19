REFAKTORERING
Programmet har delats upp i ett 'main' Game objekt samt ett antal 'Handlers' med olika ansvarsområden.
Game-objektet innehåller den huvudsakliga game-loopen där spelet spelas och håller koll på hur många gånger den loopar men har i övrigt ingen logik.
De 'Handlers' som skapats är: en för att hantera User Input, en för att hantera spelets grafiska Output, en för att hantera spel-logiken och till sist en som hanterar Topplistan.
Samtliga Handlers är självständiga och implementerar ett eget Interface med tydligt namngivna funktioner som uför endast 1 uppgift vardera.

DESIGN MÖNSTER
Dependency Injection mönstret är implementerat och samtliga Handlers är injektade i Game objekt.
Detta sker i Program klassens Main metod med .NETs egna ServiceCollection och ServiceProvider klasser.
Alla Handlers är Singletons.
Builder mönster används iom en StringBuilder nu för att skapa Topplistan som är en potentiellt stor sträng. 

BUGFIXAR
Även om det garanterat är bara unika siffror i det Goal som skapas så finns inga explicita krav på utformningen av en Guess.
Detta ledde till att i fall en Guess innehöll dupletter så kunda Bulls och Cows bli fel; t ex om Goal är '1234' och Guess är '1111' så blev svaret 'B,CCC' vilket är missvisande.
Detta är åtgärdat och nu visar samma senario 'B,' istället.

FELHANTERING
Istället för att kasta Exceptions så är InputHandlern väldigt förlåtande och accepterar all input som valid, inkluderat null.
Detta är nog inte jättebra då missklicks kan leda till oavsiktliga gissningar eller tomma Usernames. 
Mer input validering med user-feedback kunde ha implementerats.

TESTING
Ett testprojekt byggt med MSTest är skapat för att köra Unit Tests.
Testklasser för Handlers är skapade där deras funktioner testas.
Mock-object som implementerar varje Handler Interface med förbestämd data används för att testa en kort körning av Game klassen.