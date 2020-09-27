# borrow-game-control
Web application to control games loaned to friends


**How to run the application**

Inside the root folder of the project run the below commands:
*docker-compose build*
*docker-compose up*

Obs: I found some problems using *docker-compose build*. Sometimes it shows the error *"Cannot locate specified Dockerfile: db.Dockerfile"* even though the file is there.
 
**How to test the API**

obs: On windows you must substitute localhost for the current IP of the PC.

**REGISTER**: Registe an user

curl --location --request POST 'http://localhost:5002/auth/register' \
--header 'Content-Type: application/json' \
--data-raw '{
    "username": "Lucas",
    "password": "12345"
}'


**LOGIN**: Get the token

curl --location --request POST 'http://localhost:5002/auth/login' \
--header 'Content-Type: application/json' \
--data-raw '{
    "username": "Lucas",
    "password": "12345"
}'

**ADD A GAME**: Add the token after th 'Bearer' word

curl --location --request POST 'http://localhost:5002/games' \
--header 'Authorization: Bearer INSERT_TOKEN' \
--header 'Content-Type: application/json' \
--data-raw '[
    {
        "title": "The Witcher 3",
        "console": "ps4",
        "idUser": 1
    },
    {
        "title": "Mass Effect",
        "console": "pc",
        "idUser": 1
    }
]'

**ADD FRIENDS TO USER**: Add the token after th 'Bearer' word

curl --location --request POST 'http://localhost:5002/friendsuser' \
--header 'Authorization: Bearer INSERT_TOKEN' \
--header 'Content-Type: application/json' \
--data-raw '[
    {
        "nameFriend": "Faustão",
        "idUser": 1
    },
    {
        "nameFriend": "Kakaroto",
        "idUser": 1
    }
]'

**LEND A GAME**: Add the token after th 'Bearer' word

curl --location --request POST 'http://localhost:5002/gameloan/2' \
--header 'Authorization: Bearer INSERT_TOKEN' \
--header 'Content-Type: application/json' \
--data-raw '[
    {
        "idGame": 1
    },
    {
        "idGame": 2
    }
]'

**RETURN GAME**: Add the token after th 'Bearer' word

curl --location --request POST 'http://localhost:5002/gameloan/return' \
--header 'Authorization: Bearer INSERT_TOKEN' \
--header 'Content-Type: application/json' \
--data-raw '[
    {
        "idGame": 1
    }
]'