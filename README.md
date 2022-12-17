# CoincapTests

Zajęło to ponad 2h.
Architektonicznie jest sporo do poprawy: 
 -> DI ze wstrzyknięciem klienta do klas testowych
 -> deserializacja zrobiona jest na szybko
 -> jest to małe pokrycie testami, małe komentarze wewnątrz klas testowych co do tego
 -> proste wyciąganie z configa wartości
 -> destructive testów nie ma
 -> mógłbym pozbyć się modeli, które zawierają jedynie listę z Data
 -> brak pokrycia niektórych endpointów
 -> RestRequest również mógłby być zrobiony za pomocą DI, teraz na sztywno wszędzie wrzucam końcówki
 
Sporo tu brakuje, takie rozwiązanie się nadaje na pokazanie jak działa RestSharp najwyżej. :)
