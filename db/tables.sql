use ivillia;

CREATE TABLE IF NOT EXISTS users (
    id char(16) PRIMARY KEY,
    username varchar(60),
    password_hash binary,
    password_salt binary
);

CREATE TABLE IF NOT EXISTS games (
    id char(16) PRIMARY KEY,
    title varchar(60),
    console varchar (10)
)

CREATE TABLE IF NOT EXISTS games_loaned (
    id char(16) PRIMARY KEY,
    id_user char(16),
    id_game char(16),
    loan_date date,
    return_date date,
    FOREIGN KEY (id_user) REFERENCES users(id)
    FOREIGN KEY (id_game) REFERENCES games(id)
)