# TvojFilm-RS2

**TvojFilm** je aplikacija krairana u edukativne svrhe za predmet Razvoj Softvera 2. Osnovna funkcija aplikacije je dodavanje i pregled filmskog sadržaja. Aplikacija se sastoji od tri osnovna dijela:
-	web API,
-	desktop aplikacija koja služi dodavanju sadržaja,
-	mobilna aplikacija namijenjena korisnicima za pregled i interakciju.

## Kredencijali za prijavu   


- Administrator (login za desktop dio / winForms)

    ```
    Korisnicko ime: admin           
    Lozinka: test                             
    ```
         
    
- Korisnik (login za mobilni dio / flutter)

    ```
    Korisnicko ime: korisnik1                       Korisnicko ime 2: korisnik2
    Lozinka: test                                   Lozinka: test 
    ```    


## Pokretanje aplikacija
1. Kloniranje repozitorija

    ```
    git clone https://github.com/AndrejMarjanovic/TvojFilm-RS2.git
    ```
2. Otvoriti klonirani repozitoriji u konzoli

3. Pokretanje dokerizovanog API-ja i DB-a

    ```
    docker-compose up --build
    ```
    
4. Otovriti tvojfilmmobile folder u vs code 


5. Dohvatanje dependecy-a

    ```
    flutter pub get
    ```
    
6. Pokretanje mobilne aplikacije

    ```
    flutter run
    ```   
    
7. Pokretanje desktop aplikacije

    ```
    1. Otvoriti solution u Visual Studiu
    2. Desni klik na solution
    3. Set Startup Projects
    4. Multiple startup projects
    5. TvojFilm.WinUI - Start
    6. OK
    7. CTRL + F5
    ```    