create database if not exists musicPlayerBD;

use musicPlayerBD;

create table if not exists Users (
	Id int auto_increment,
    `Name` varchar(30) not null,
    Email varchar(50) unique,
    Pwd varchar(255) not null,
    Visual_theme varchar(30) not null,
    primary key(Id)
    );
    
create table if not exists Songs(
	Id int auto_increment,
    NameSong varchar(100) not null,
    Singer varchar(100) not null,
    `Path` varchar(250) unique,
    Owner_id int not null,
    Genre_id int not null,
    SongStatus int not null,
    primary key(Id)
    );

create table if not exists SongGenre(
	Id int auto_increment,
    Name varchar(50) not null,
    primary key(Id)
    );

create table if not exists PlayList(
	Id int auto_increment,
    `Name` varchar(100) not null,
    User_id int not null,
    ListStatus int not null,
    primary key(Id)
    );

create table if not exists PlayListSong(
	Id int auto_increment,
    PlayList_id int not null,
    Song_id int not null,
    primary key(Id)
    );
    
create table if not exists SongStatus(
	Id int auto_increment,
    `Name` varchar(100) not null,
    primary key(Id)
    );
create table if not exists ListStatus(
	Id int auto_increment,
    `Name` varchar(100) not null,
    primary key(Id)
    );

alter table songs add constraint FK_Owner foreign key (Owner_id) references users (id);
alter table songs add constraint FK_Genre foreign key (Genre_id) references SongGenre (id);
alter table songs add constraint FK_Status_Songs foreign key (SongStatus) references SongStatus (id);
alter table PlayList add constraint FK_User foreign key (User_id) references users (id);
alter table PlayList add constraint FK_Status_Playlist foreign key (ListStatus) references ListStatus (id);
alter table PlayListSong add constraint FK_PlayList foreign key (PlayList_id) references PlayList (id);
alter table PlayListSong add constraint FK_Songs foreign key (Song_id) references Songs (id);