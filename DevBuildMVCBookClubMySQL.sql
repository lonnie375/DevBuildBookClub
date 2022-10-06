create database bookclub; 

use bookclub; 

create table Person ( 
	id int primary key auto_increment, 
    firstname varchar(50), 
    lastname varchar(50), 
    email varchar(50)
);

create table Presentation (
	id int primary key auto_increment, 
    person_id int, 
    Foreign Key (person_id) references person(id), 
    presentationdate datetime, 
    booktitle varchar(50),
    bookauthor varchar(50),
	genre varchar(25)
);


desc presentation; 
use bookclub; 
/*Lets add some information here*/
insert into person (firstname, lastname, email) 
values("Michael", "Jordan", "MJ@gmail.com"); 
select * from person; 

insert into presentation (person_id, presentationdate, booktitle, bookauthor, genre) 
values (3, '2022-10-31 12:15:00', 'Bio of MJ', 'MJ', 'Bio'); 
select * from presentation; 

insert into presentation (person_id, presentationdate, booktitle, bookauthor, genre) 
values (4, '2022-10-31 12:15:00', 'Bio of MJ', 'MJ', 'Bio'); 
insert into presentation (person_id, presentationdate, booktitle, bookauthor, genre) 
values (5, '2022-10-31 13:15:00', 'Bio of IT', 'IT', 'Bio'); 
insert into presentation (person_id, presentationdate, booktitle, bookauthor, genre) 
values (6, '2022-10-31 14:15:00', 'Harry Potter', 'HP', 'Drama'); 
insert into presentation (person_id, presentationdate, booktitle, bookauthor, genre) 
values (7, '2022-10-31 15:15:00', 'Holy Bible', 'MJ', 'Suspese'); 
insert into presentation (person_id, presentationdate, booktitle, bookauthor, genre) 
values (8, '2022-10-31 16:15:00', 'Jack Reacher', 'MJ', 'Horror'); 
insert into presentation (person_id, presentationdate, booktitle, bookauthor, genre) 
values (9, '2022-10-31 17:15:00', 'Color Purple', 'HP', 'Romance'); 
insert into presentation (person_id, presentationdate, booktitle, bookauthor, genre) 
values (20, '2022-10-31 18:15:00', 'A Raisin in the sun', 'CM', 'Suspense'); 

select * from presentation;
select * from presentation 
where person_id in (select id from person); 

select * from presentation 
where person_id = 3; 
use bookclub; 
drop table presentation; 
drop table person; 

create table Presentation (
	id int primary key auto_increment, 
    person_id int, 
    Foreign Key (person_id) references person(id) on delete cascade, 
    presentationdate datetime, 
    booktitle varchar(50),
    bookauthor varchar(50),
	genre varchar(25)
);

select * from person; 

insert into presentation (person_id, presentationdate, booktitle, bookauthor, genre) 
values (4, '2022-10-31 12:15:00', 'Bio of MJ', 'MJ', 'Bio'); 
insert into presentation (person_id, presentationdate, booktitle, bookauthor, genre) 
values (5, '2022-10-31 13:15:00', 'Bio of IT', 'IT', 'Bio'); 
insert into presentation (person_id, presentationdate, booktitle, bookauthor, genre) 
values (6, '2022-10-31 14:15:00', 'Harry Potter', 'HP', 'Drama'); 
insert into presentation (person_id, presentationdate, booktitle, bookauthor, genre) 
values (7, '2022-10-31 15:15:00', 'Holy Bible', 'MJ', 'Suspese'); 

alter table presentation 
add constraint updatepresentation
foreign key (person_id) 
references person(id)
on update cascade; 