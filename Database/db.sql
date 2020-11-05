begin;
    if not exists(select 1 from sys.databases where name='Pokeemon')
        CREATE DATABASE [Pokeemon];
end;

USE Pokeemon;

CREATE TABLE Users (
    id              int identity primary key not null,
    administrator   bit not null,
    pseudo          varchar(20) not null,
    email           varchar(320) not null,
    password        binary(64) not null,
    money           int not null default 120
);

CREATE TABLE Monsters (
    id              int identity primary key not null,
    name            varchar(64) not null,
    stereotype      varchar(64) not null,
    level           int not null,
);

create table UserMonsters(
    idUser         int not null,
    idMonster      int not null,

    foreign key (idUser) references Users,
    foreign key (idMonster) references Monsters
    
    primary key (idUser, idMonster),
);

create table UserItems(
    idUser          int not null,
    nameItem        varchar(64) not null,
    quantity        int not null,

    foreign key (idUser) references Users,

    primary key (idUser, nameItem)
);
