use invillia;

CREATE TABLE IF NOT EXISTS users (
    id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
    username varchar(60) not null,
    password_hash blob not null,
    password_salt blob not null,
	created date not null
);

CREATE TABLE IF NOT EXISTS games_user (
    id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
	id_user int not null,
    title varchar(60) not null,
    console varchar (10) not null,
	created date not null,
	FOREIGN KEY (id_user) REFERENCES users(id)
);

CREATE TABLE IF NOT EXISTS friends_user (
    id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
	id_user int not null,
    name_friend varchar(60) not null,
	created date not null,
	FOREIGN KEY (id_user) REFERENCES users(id)
);

CREATE TABLE IF NOT EXISTS games_loaned (
    id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
    id_friend int not null,
    id_game int not null,
	created date not null,
    return_date date null,	
    FOREIGN KEY (id_friend) REFERENCES friends_user(id),
    FOREIGN KEY (id_game) REFERENCES games_user(id)
);