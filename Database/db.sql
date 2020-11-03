begin;
    if not exists(select 1 from sys.databases where name='Palermon')
        CREATE DATABASE [Palermon];
end;

USE Palermon;

CREATE TABLE Users (
    id              int identity primary key not null,
    administrator   bit not null,
    pseudo          varchar(20) not null,
    email           varchar(320) not null,
    password        binary(64) not null 
);

CREATE TABLE Monsters (
    id              int identity primary key not null,
    name            varchar(64) not null,
    stereotype      varchar(64) not null,
    level           int not null
);

create table User_monsters(
    id              int identity primary key not null,
    id_user         int not null,
    id_monster      int not null,
    foreign key (id_user) references Users,
    foreign key (id_monster) references Monsters
);

CREATE TABLE Stereotype (
    id              int identity primary key not null,
    stereotypeName  varchar(64) not null,
    baseHealth      decimal(7,2) not null,
    baseAttack      decimal(7,2) not null,
    baseDefense     decimal(7,2) not null,
    baseSpeed       decimal(7,2) not null
);

CREATE TABLE Items(
    id              int identity primary key not null,
    itemName        varchar(64) not null,
    value           decimal not null
);

CREATE TABLE Attack(
    id              int identity primary key not null,
    name            varchar(64) not null,
    damage          decimal(7,2) not null
);
