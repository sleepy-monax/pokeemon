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

CREATE TABLE Stereotype (
    id              int identity primary key not null,
    name            varchar(64) not null,
    baseHealth      decimal(7,2) not null,
    baseAttack      decimal(7,2) not null,
    baseDefense     decimal(7,2) not null,
    baseSpeed       decimal(7,2) not null
);

CREATE TABLE Monsters (
    id              int identity primary key not null,
    name            varchar(64) not null,
    stereotype      int not null,
    level           int not null,

    foreign key (stereotype) references Stereotype
);

create table UserMonsters(
    idUser         int not null,
    idMonster      int not null,

    foreign key (idUser) references Users,
    foreign key (idMonster) references Monsters
    
    primary key (idUser, idMonster),
);

CREATE TABLE Items(
    id              int identity primary key not null,
    name            varchar(64) not null,
    value           decimal not null
);

CREATE TABLE Attack(
    id              int identity primary key not null,
    name            varchar(64) not null,
    damage          decimal(7,2) not null
);
