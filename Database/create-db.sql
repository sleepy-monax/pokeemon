CREATE DATABASE Pokeemon;

GO

USE Pokeemon;

CREATE TABLE Users (
    id              int identity primary key not null,
    administrator   bit not null default 0,
    pseudo          varchar(20) not null,
    email           varchar(320) not null,
    password        varchar(64) not null,
    money           int not null default 120
);

CREATE TABLE Creatures (
    id              int identity primary key not null,
    name            varchar(64),
    stereotype      varchar(64) not null,
    xp              int not null,
    pickable        bit not null default 0
);

create table UserCreatures(
    idUser         int not null,
    idCreature      int not null,

    foreign key (idUser) references Users,
    foreign key (idCreature) references Creatures,

    primary key (idUser, idCreature)
);

create table UserItems(
    id              int identity primary key not null,
    idUser          int not null,
    nameItem        varchar(64) not null,
    quantity        int not null,

    foreign key (idUser) references Users,
);
