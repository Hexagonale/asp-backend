# Pogram ASP.NET - proste forum
Prosty projekt forum internetowego. Backend jest napisany przy pomocy technologi ASP.NET Core w C# oraz używa Entity Framework jako ORM. Frontend jest napisany przy pomocy technologii Razor oraz przy wsparciu JavaScript do dynamicznego generowania treści.

## Uruchamianie projektu
- Komend cd `src` - Wejście do katalogu projektu.
- Komenda `dotnet ef database update` - Utworzenie bazy danych.
- Komenda `dotnet watch` - Uruchamia projekt oraz otwiera okno przeglądarki.

## Początkowe dane
Na początku jest dodanych dwóch użytkowników:
- Administrator: login: `admin`, hasło: `admin`
- Zwykły użytkownik: login: `user`, hasło: `user`

## Korzystanie z projektu
Na stronie startowej w nagłówku znajdują się 2 przyciski `Zarejestruj` oraz `Zaloguj`. Prowadzą one do dwóch formularzy zgodnie z ich nazwą.

![login](https://github.com/Hexagonale/asp-backend/blob/master/images/login.png?raw=true)

![login form](https://github.com/Hexagonale/asp-backend/blob/master/images/login-form.png?raw=true)

![register form](https://github.com/Hexagonale/asp-backend/blob/master/images/register-form.png?raw=true)

Po zalogowaniu na użytkownika lub administratora można dodawać posty. W nagłówku widnieją wtedy przyciski `Dodaj nowy post` oraz `Wyloguj`. Ten drugi kończy sesję natomiast pierwszy prowadzi do kolejnego formularza.

![after login](https://github.com/Hexagonale/asp-backend/blob/master/images/after-login.png?raw=true)

Dodawać posty może każdy zalogowany użytkownik lub administrator. Należy podać w formularzu tytuł oraz zawartość posta. Po dodaniu posta zostajemy przekierowani na stronę główną.

![add post form](https://github.com/Hexagonale/asp-backend/blob/master/images/add-post-form.png?raw=true)

Kiedy w systemie znajdują się posty, pojawia się ich lista na stronie głównej. Lista jest posortowana od najnowszego posta do najstarszego. Listę tę widzi każdy, nawet nie zalogowani. Zawartość każdego posta na liście jest ograniczona do 150 znaków. W szczegóły posta można wejść poprzez kliknięcie w jego tytuł.

![posts list](https://github.com/Hexagonale/asp-backend/blob/master/images/posts-list.png?raw=true)

W szczegóły posta może wejść każdy. Jednak tylko zalogowani użytkownicy lub administratorzy mogą czytać lub tworzyć komentarze. Jeśli jesteśmy zalogowani pod postem widnieje formularz do dodawania komentarza. Aby dodać formularz należy wypełnić pole jego treści oraz kliknąć skomentuj. Po Dodaniu komentarza strona odświeża się automatycznie.

![add comment form](https://github.com/Hexagonale/asp-backend/blob/master/images/add-comment-form.png?raw=true)

Zwykły użytkownik może usuwać tylko swoje posty, administrator może usuwać każdy. Aby to z robić należy w szczegółach posta kliknąć przycisk `Usuń`. Po usunięciu posta zostajemy przekierowani na stronę główną.
