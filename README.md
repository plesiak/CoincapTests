# CoincapTests

Zajęło to ponad 2h.
Architektonicznie jest sporo do poprawy: 
<br> -> DI ze wstrzyknięciem klienta do klas testowych <br />
-> deserializacja zrobiona jest na szybko <br />
-> jest to małe pokrycie testami, małe komentarze wewnątrz klas testowych co do tego <br />
-> proste wyciąganie z configa wartości <br />
-> destructive testów nie ma <br />
-> mógłbym pozbyć się modeli, które zawierają jedynie listę z Data <br />
-> brak pokrycia niektórych endpointów <br />
-> RestRequest również mógłby być zrobiony za pomocą DI, teraz na sztywno wszędzie wrzucam końcówki <br />
 
Sporo tu brakuje, takie rozwiązanie się nadaje na pokazanie jak działa RestSharp najwyżej. :)
