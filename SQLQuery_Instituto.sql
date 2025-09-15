create database db_instituto
use dh_Instituto

--crear table tb_carrera
create table tb_carrera
(cod_carrera int not null primary key,
nom_carrera varchar (30) not null )

--crear table tb_curso
create table tb_curso
(cod_curso int not null primary key,
nom_curso varchar (30) not null,
cred_curso int not null)

--crear table tb_profesor
create table tb_profesor
(cod_profesor int not null primary key,
nom_profesor varchar (50) not null,
dir_profesor varchar (50) not null,
tef_profesor varchar (15) not null,
hor_profesor varchar (10) not null)

--crear table tb_estudiante
create table tb_estudiante
(cod_estudiante int not null primary key,
nom_estudiante varchar (50) not null,
sem_estudiante int not null,
edad_estudiante int not null,
gen_estudianter char (1) not null,
cod_carrera int not null)

--crear table tb_estud_prof
create table tb_estud_prof
(cod_estudiante int not null,
cod_profesor int not null)

--crear table tb_curso_prof
create table tb_curso_prof
(cod_curso int not null,
cod_profesor int not null)

--crear table tb_curso_estud
create table tb_curso_estud
(cod_curso int not null,
cod_estudiante int not null)

alter table tb_estudiante
add constraint fk_estudiante_carrera
foreign key (cod_carrera) references tb_carrera(cod_carrera) 
---------------------------
alter table tb_estud_prof
add constraint fk_estudiante_profesor
foreign key (cod_estudiante) references tb_estudiante(cod_estudiante) 

alter table tb_estud_prof
add constraint fk_profesor_estudiante
foreign key (cod_profesor) references tb_profesor(cod_profesor) 
-----------------------------
alter table tb_curso_prof
add constraint fk_curso_profesor
foreign key (cod_curso) references tb_curso(cod_curso) 

alter table tb_curso_prof
add constraint fk_profesor_curso
foreign key (cod_profesor) references tb_profesor(cod_profesor) 
-----------------------------
alter table tb_curso_estud
add constraint fk_curso_estud
foreign key (cod_curso) references tb_curso(cod_curso) 

alter table tb_curso_estud
add constraint fk_estud_curso
foreign key (cod_estudiante) references tb_estudiante(cod_estudiante) 


