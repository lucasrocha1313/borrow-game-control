use vivara;

CREATE TABLE IF NOT EXISTS users (
    id char(16) PRIMARY KEY,
    username varchar(60)
);

CREATE TABLE IF NOT EXISTS games (
    id char(16) PRIMARY KEY,
    title varchar(60),
    console varchar (10)
)

CREATE TABLE IF NOT EXISTS games_loaned (
    id char(16) PRIMARY KEY,
    id_user char(16),
    id_game char(16)
    FOREIGN KEY (id_user) REFERENCES users(id)
    FOREIGN KEY (id_game) REFERENCES games(id)
)